using System.Text.Json.Serialization;

namespace ToMqttNet;

public interface IMqttDiscoveryConfigParser
{
	MqttDiscoveryConfig? Parse(string topic, string message, JsonSerializerContext? jsonContext = null);
}