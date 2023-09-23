using MQTTnet;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToMqttNet;


public static class MqttDiscoveryConfigExtensions
{
	public static string ToJson<T>(this T config, JsonSerializerContext? ctx = null) where T : MqttDiscoveryConfig
	{
		ctx = ctx ?? MqttDiscoveryJsonContext.Default;
		var jsonTypeInfo = ctx.GetTypeInfo(typeof(T));

		if (jsonTypeInfo == null)
		{
			throw new InvalidOperationException("The JsonTypeInfo for " + config.GetType().FullName + " was not found in the provided JsonSerializerContext. If you have a custom Discovery Document you might need to provide your own JsonSerializerContext");
		}

		return JsonSerializer.Serialize(config, jsonTypeInfo);
	}
}

public static class MqttConnectionServiceExtensions
{
	public static Task PublishDiscoveryDocument<T>(this IMqttConnectionService connection, T config, JsonSerializerContext? ctx = null) where T : MqttDiscoveryConfig
	{
		return connection.PublishAsync(
			new MqttApplicationMessageBuilder()
				.WithTopic($"homeassistant/{config.Component}/{connection.MqttOptions.NodeId}/{config.UniqueId}/config")
				.WithRetainFlag()
				.WithPayload(config.ToJson(ctx))
				.Build());
	}
}
