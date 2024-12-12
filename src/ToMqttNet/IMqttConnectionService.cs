using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;

namespace ToMqttNet;

public interface IMqttConnectionService
{
	event Func<MqttApplicationMessageReceivedEventArgs, Task>? OnApplicationMessageReceivedAsync;
	event Func<MqttClientConnectedEventArgs, Task>? OnConnectAsync;
	event Func<MqttClientDisconnectedEventArgs, Task>? OnDisconnectAsync;

	MqttConnectionOptions MqttOptions { get; }

	Task PublishAsync(MqttApplicationMessage applicationMessages);
	Task SubscribeAsync(params MqttTopicFilter[] topics);
	Task UnsubscribeAsync(params string[] topics);
}
