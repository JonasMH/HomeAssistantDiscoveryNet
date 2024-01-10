using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

public interface IMqttDiscoveryConfigParser
{
	MqttDiscoveryConfig? Parse(string topic, string message, JsonSerializerContext? jsonContext = null);
}