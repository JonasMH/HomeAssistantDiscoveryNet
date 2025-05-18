using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ToMqttNet;

public class MqttConnectionService(
	ILogger<MqttConnectionService> logger,
	IOptions<MqttConnectionOptions> mqttOptions,
	[FromKeyedServices(typeof(MqttConnectionService))] IManagedMqttClient managedMqttClient,
	MqttCounters counters,
	IServiceProvider serviceProvider) : BackgroundService, IMqttConnectionService
{
	private readonly ILogger<MqttConnectionService> _logger = logger;
	private readonly MqttCounters _counters = counters;
	private readonly string _instanceId = Guid.NewGuid().ToString();
	private WatchingMqttCertificateProvider? _certificateWatcher;

	public MqttConnectionOptions MqttOptions { get; } = mqttOptions.Value;
	private readonly IManagedMqttClient _mqttClient = managedMqttClient;

	public event Func<MqttApplicationMessageReceivedEventArgs, Task>? OnApplicationMessageReceivedAsync;
	public event Func<MqttClientConnectedEventArgs, Task>? OnConnectAsync;
	public event Func<MqttClientDisconnectedEventArgs, Task>? OnDisconnectAsync;

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation("Executing {backgroundService}", GetType().FullName);

		var optionsBuilder = new MqttClientOptionsBuilder()
			.WithClientId($"{MqttOptions.NodeId}-{_instanceId}")
			.WithWillPayload(Encoding.UTF8.GetBytes("0"))
			.WithWillTopic($"{MqttOptions.NodeId}/connected")
			.WithWillRetain();
		
		if (!string.IsNullOrEmpty(MqttOptions.Username) && !string.IsNullOrEmpty(MqttOptions.Password))
		{
			optionsBuilder.WithCredentials(MqttOptions.Username, MqttOptions.Password);
		}

		SetupChannelOptions(optionsBuilder);
		
		var options = optionsBuilder.Build();

		var managedOptions = new ManagedMqttClientOptionsBuilder()
			.WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
			.WithClientOptions(options)
			.Build();
		
		_counters.SetPendingMessages(() => _mqttClient.PendingApplicationMessagesCount);

		_mqttClient.ConnectionStateChangedAsync += (evnt) =>
		{
			_counters.SetConnections(_mqttClient.IsConnected ? 1 : 0);
			return Task.CompletedTask;
		};

		_mqttClient.ConnectingFailedAsync += (evnt) =>
		{
			_logger.LogWarning(evnt.Exception, "Connection to mqtt failed");

			_counters.SetConnections(0);
			return Task.CompletedTask;
		};

		_mqttClient.ConnectedAsync += async (evnt) =>
		{
			_counters.NewConnection();
			_logger.LogInformation("Connected to mqtt: {reason}", evnt.ConnectResult.ReasonString);
			await _mqttClient.EnqueueAsync(
				new MqttApplicationMessageBuilder()
					.WithPayload("2")
					.WithTopic($"{MqttOptions.NodeId}/connected")
					.WithRetainFlag()
					.Build());

			if (OnConnectAsync != null)
			{
				await OnConnectAsync(evnt);
			}
		};

		_mqttClient.DisconnectedAsync += async (evnt) =>
		{
			_logger.LogInformation(evnt.Exception, "Disconnected from mqtt: {reason}", evnt.Reason);
			if (OnDisconnectAsync != null)
			{
				await OnDisconnectAsync(evnt);
			}
		};

		_mqttClient.ApplicationMessageReceivedAsync += async (evnt) =>
		{
			try
			{
				if (_logger.IsEnabled(LogLevel.Trace))
				{
					_logger.LogTrace("{topic}: {message}", evnt.ApplicationMessage.Topic, evnt.ApplicationMessage.ConvertPayloadToString());
				}
				if (OnApplicationMessageReceivedAsync != null)
				{
					await OnApplicationMessageReceivedAsync(evnt);
				}
			}
			catch (Exception e)
			{
				_logger.LogWarning(e, "Failed to handle message to topic {topic}", evnt.ApplicationMessage.Topic);
				_counters.IncreaseMessagesHandled(success: false);
			}
			_counters.IncreaseMessagesHandled(success: true);
		};

		_logger.LogInformation("Starting mqttclient");
		await _mqttClient.StartAsync(managedOptions);
	}

	public async Task PublishAsync(MqttApplicationMessage applicationMessages)
	{
		await _mqttClient!.EnqueueAsync(applicationMessages);
		_counters.IncreaseMessagesSent();
	}

	public Task SubscribeAsync(params MqttTopicFilter[] topics)
	{
		return _mqttClient!.SubscribeAsync(topics);
	}

	public Task UnsubscribeAsync(params string[] topics)
	{
		return _mqttClient!.UnsubscribeAsync(topics);
	}

	private MqttClientOptionsBuilder SetupChannelOptions(MqttClientOptionsBuilder optionsBuilder)
	{
		optionsBuilder.WithTcpServer(MqttOptions.Server ?? "mosquitto", MqttOptions.Port ?? 1883);

		if (MqttOptions.UseTls)
		{
			_certificateWatcher = ActivatorUtilities.CreateInstance<WatchingMqttCertificateProvider>(serviceProvider);
			optionsBuilder.WithTlsOptions(new MqttClientTlsOptions
			{
				UseTls = true,
				SslProtocol = System.Security.Authentication.SslProtocols.Tls12,
				ClientCertificatesProvider = _certificateWatcher,
				CertificateValidationHandler = (certContext) =>
				{
					X509Chain chain = new();
					chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
					chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
					chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
					chain.ChainPolicy.VerificationTime = DateTime.Now;
					chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
					chain.ChainPolicy.CustomTrustStore.Add(_certificateWatcher.CaCertificate!);
					chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;

					// convert provided X509Certificate to X509Certificate2
					var x5092 = new X509Certificate2(certContext.Certificate);

					return chain.Build(x5092);
				}
			});
		}

		return optionsBuilder;
	}
}
