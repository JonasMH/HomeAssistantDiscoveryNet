using MQTTnet;
using Newtonsoft.Json;

namespace ToMqttNet
{
	public interface IMqttConnectionService
	{
		event EventHandler<MqttApplicationMessageReceivedEventArgs> OnApplicationMessageReceived;
		MqttConnectionOptions MqttOptions { get; }

		Task PublishAsync(params MqttApplicationMessage[] applicationMessages);
		Task SubscribeAsync(params MqttTopicFilter[] topics);
		Task UnsubscribeAsync(params string[] topics);
	}
}
