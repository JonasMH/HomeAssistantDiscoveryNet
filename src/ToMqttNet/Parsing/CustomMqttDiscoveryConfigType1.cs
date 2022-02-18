namespace ToMqttNet;

public abstract class CustomMqttDiscoveryConfigType
{
	public CustomMqttDiscoveryConfigType(string key, Type type)
	{
		Key = key;
		Type = type;
	}

	public string Key { get; set; }
	public Type Type { get; set; }
}
