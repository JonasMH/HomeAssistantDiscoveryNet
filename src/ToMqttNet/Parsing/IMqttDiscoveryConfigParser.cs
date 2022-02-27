namespace ToMqttNet
{
	public interface IMqttDiscoveryConfigParser
	{
		MqttDiscoveryConfig? Parse(string topic, string message);
	}
}