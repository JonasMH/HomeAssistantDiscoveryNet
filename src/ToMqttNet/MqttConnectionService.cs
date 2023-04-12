using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;

namespace ToMqttNet
{
	public class MqttConnectionService : BackgroundService, IMqttConnectionService
	{
		private readonly ILogger<MqttConnectionService> _logger;
		private string _instanceId = Guid.NewGuid().ToString();

		public MqttConnectionOptions MqttOptions { get; }
		private IManagedMqttClient? _mqttClient;

		public event EventHandler<MqttApplicationMessageReceivedEventArgs>? OnApplicationMessageReceived;
		public event EventHandler<EventArgs>? OnConnect;
		public event EventHandler<EventArgs>? OnDisconnect;

		public MqttConnectionService(
			ILogger<MqttConnectionService> logger,
			IOptions<MqttConnectionOptions> mqttOptions)
		{
			_logger = logger;
			MqttOptions = mqttOptions.Value;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var clientOptionsBuilder = new MqttClientOptionsBuilder()
					.WithClientId(MqttOptions.ClientId + "-" + _instanceId)
					.WithWillPayload("0")
					.WithWillTopic($"{MqttOptions.NodeId}/connected")
					.WithWillRetain();

			if(!string.IsNullOrWhiteSpace(MqttOptions.BrokerUrl)) {
				clientOptionsBuilder = clientOptionsBuilder.WithConnectionUri(MqttOptions.BrokerUrl);
			} else {
				clientOptionsBuilder = clientOptionsBuilder.WithTcpServer(MqttOptions.Server, MqttOptions.Port);
			}

			var clientOptions = clientOptionsBuilder;


			var optionsBuilder = new ManagedMqttClientOptionsBuilder()
				.WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
				.WithClientOptions(clientOptions);

			var options = optionsBuilder.Build();

			_mqttClient = new MqttFactory()
				.CreateManagedMqttClient();

			_mqttClient.ConnectedAsync += async (evnt) =>
			{
				_logger.LogInformation("Connected to mqtt: {reason}", evnt.ConnectResult.ReasonString);

				await _mqttClient.EnqueueAsync(
					new MqttApplicationMessageBuilder()
						.WithPayload("2")
						.WithTopic($"{MqttOptions.NodeId}/connected")
						.WithRetainFlag()
						.Build());

				OnConnect?.Invoke(this, new EventArgs());
			};

			_mqttClient.DisconnectedAsync += async (evnt) =>
			{
				_logger.LogInformation(evnt.Exception, "Disconnected from mqtt: {reason}", evnt.Reason);
				OnDisconnect?.Invoke(this, new EventArgs());
			};

			_mqttClient.ApplicationMessageReceivedAsync += async (evnt) =>
			{
				_logger.LogTrace("{topic}: {message}", evnt.ApplicationMessage.Topic, evnt.ApplicationMessage.ConvertPayloadToString());
				OnApplicationMessageReceived?.Invoke(this, evnt);
			};

			await _mqttClient.StartAsync(options);
		}

		public Task PublishAsync(MqttApplicationMessage applicationMessages)
		{
			return _mqttClient!.EnqueueAsync(applicationMessages);
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
}
