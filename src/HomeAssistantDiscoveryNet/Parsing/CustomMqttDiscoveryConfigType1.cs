namespace HomeAssistantDiscoveryNet;

public abstract class CustomMqttDiscoveryConfigType(string key, Type type)
{
	public string Key { get; set; } = key;
	public Type Type { get; set; } = type;
}
