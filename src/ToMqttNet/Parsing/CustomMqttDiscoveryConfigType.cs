namespace ToMqttNet;

public class CustomMqttDiscoveryConfigType<T> : CustomMqttDiscoveryConfigType where T : MqttDiscoveryConfig
{
	public CustomMqttDiscoveryConfigType(string key) : base(key, typeof(T))
	{
	}
}
