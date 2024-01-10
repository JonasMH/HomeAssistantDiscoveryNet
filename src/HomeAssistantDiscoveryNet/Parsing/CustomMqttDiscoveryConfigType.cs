namespace HomeAssistantDiscoveryNet;

public class CustomMqttDiscoveryConfigType<T>(string key) : CustomMqttDiscoveryConfigType(key, typeof(T)) where T : MqttDiscoveryConfig
{
}
