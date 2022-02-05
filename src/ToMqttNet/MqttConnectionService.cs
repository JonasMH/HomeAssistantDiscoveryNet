using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;

namespace ToMqttNet
{
	public class MqttConnectionService : BackgroundService, IMqttConnectionService
	{
		private readonly ILogger<MqttConnectionService> _logger;
		public MqttConnectionOptions MqttOptions { get; }
		private IManagedMqttClient? _mqttClient;

		public event EventHandler<MqttApplicationMessageReceivedEventArgs> OnApplicationMessageReceived = null!;

		public MqttConnectionService(
			ILogger<MqttConnectionService> logger,
			IOptions<MqttConnectionOptions> mqttOptions)
		{
			_logger = logger;
			MqttOptions = mqttOptions.Value;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var options = new ManagedMqttClientOptionsBuilder()
				.WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
				.WithClientOptions(new MqttClientOptionsBuilder()
					.WithClientId(MqttOptions.ClientId)
					.WithTcpServer(MqttOptions.Server, MqttOptions.Port)
					.WithWillMessage(
						new MqttApplicationMessageBuilder()
							.WithPayload("0")
							.WithTopic($"{MqttOptions.NodeId}/connected")
							.Build()
					)
					.Build()
				)
				.Build();

			_mqttClient = new MqttFactory()
				.CreateManagedMqttClient();

			_mqttClient.UseConnectedHandler((evnt) =>
			{
				_logger.LogInformation("Connected to mqtt: {reason}", evnt.ConnectResult.ReasonString);
			});

			_mqttClient.UseDisconnectedHandler((evnt) =>
			{
				_logger.LogInformation(evnt.Exception, "Disconnected from mqtt: {reason}", evnt.Reason);
			});

			_mqttClient.UseApplicationMessageReceivedHandler((evnt) =>
			{
				_logger.LogTrace("{topic}: {message}", evnt.ApplicationMessage.Topic, evnt.ApplicationMessage.ConvertPayloadToString());
				OnApplicationMessageReceived?.Invoke(this, evnt);
			});

			await _mqttClient.StartAsync(options);
			await SubscribeAsync(new MqttTopicFilterBuilder().WithTopic($"{MqttOptions.NodeId}/#").Build());
			await _mqttClient.PublishAsync(
				new MqttApplicationMessageBuilder()
					.WithPayload("2")
					.WithTopic($"{MqttOptions.NodeId}/connected")
					.Build());
		}


		public Task PublishAsync(params MqttApplicationMessage[] applicationMessages)
		{
			return _mqttClient!.PublishAsync(applicationMessages);
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
