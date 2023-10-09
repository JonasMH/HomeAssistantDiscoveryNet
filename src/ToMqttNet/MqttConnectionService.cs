using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using System.Text;

namespace ToMqttNet;

public class MqttConnectionService : BackgroundService, IMqttConnectionService
{
	private readonly ILogger<MqttConnectionService> _logger;
	private readonly MqttCounters _counters;
	private string _instanceId = Guid.NewGuid().ToString();

	public MqttConnectionOptions MqttOptions { get; }
	private readonly IManagedMqttClient _mqttClient;

	public event EventHandler<MqttApplicationMessageReceivedEventArgs>? OnApplicationMessageReceived;
	public event EventHandler<EventArgs>? OnConnect;
	public event EventHandler<EventArgs>? OnDisconnect;

	public MqttConnectionService(
		ILogger<MqttConnectionService> logger,
		IOptions<MqttConnectionOptions> mqttOptions,
		[FromKeyedServices(typeof(MqttConnectionService))] IManagedMqttClient managedMqttClient,
		MqttCounters counters)
	{
		_logger = logger;
		_counters = counters;
		_mqttClient = managedMqttClient;
		MqttOptions = mqttOptions.Value;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		var options = MqttOptions.ClientOptions;

		if(string.IsNullOrEmpty(options.ClientId))
            {
                options.ClientId = MqttOptions.NodeId + "-" + _instanceId;
            }

		options.WillPayload = Encoding.UTF8.GetBytes("0");
		options.WillTopic = $"{MqttOptions.NodeId}/connected";
		options.WillRetain = true;

		if(options.ChannelOptions == null) {
			options.ChannelOptions = new MqttClientTcpOptions
                {
                    Server = "mosquitto",
				Port = 1883
                };
		}

		var optionsBuilder = new ManagedMqttClientOptionsBuilder()
			.WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
			.WithClientOptions(options);

		_mqttClient.ConnectedAsync += async (evnt) =>
		{
			_logger.LogInformation("Connected to mqtt: {reason}", evnt.ConnectResult.ReasonString);

			await _mqttClient.EnqueueAsync(
				new MqttApplicationMessageBuilder()
					.WithPayload("2")
					.WithTopic($"{MqttOptions.NodeId}/connected")
					.WithRetainFlag()
					.Build());

			_counters.SetConnections(1);
			OnConnect?.Invoke(this, new EventArgs());
		};

		_mqttClient.DisconnectedAsync += (evnt) =>
		{
			_logger.LogInformation(evnt.Exception, "Disconnected from mqtt: {reason}", evnt.Reason);
			_counters.SetConnections(0);
			OnDisconnect?.Invoke(this, new EventArgs());
			return Task.CompletedTask;
		};

		_mqttClient.ApplicationMessageReceivedAsync += (evnt) =>
		{
			try
			{
				if(_logger.IsEnabled(LogLevel.Trace))
				{
					_logger.LogTrace("{topic}: {message}", evnt.ApplicationMessage.Topic, evnt.ApplicationMessage.ConvertPayloadToString());
				}
				
				OnApplicationMessageReceived?.Invoke(this, evnt);
			}catch(Exception e)
			{
				_logger.LogWarning(e, "Failed to handle message to topic {topic}", evnt.ApplicationMessage.Topic);
				_counters.IncreaseMessagesHandled(false);
				return Task.CompletedTask;
			}
			_counters.IncreaseMessagesHandled(true);
			return Task.CompletedTask;
		};

		await _mqttClient.StartAsync(optionsBuilder.Build());
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
}
