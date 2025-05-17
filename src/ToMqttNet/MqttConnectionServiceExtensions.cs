using HomeAssistantDiscoveryNet;
using MQTTnet;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToMqttNet;


public static class MqttDiscoveryConfigExtensions
{
	public static string ToJson<T>(this T config, JsonSerializerContext? ctx = null) where T : MqttDiscoveryConfig
	{
		ctx ??= MqttDiscoveryJsonContext.Default;
		var jsonTypeInfo = ctx.GetTypeInfo(config.GetType()) ?? throw new InvalidOperationException("The JsonTypeInfo for " + config.GetType().FullName + " was not found in the provided JsonSerializerContext. If you have a custom Discovery Document you might need to provide your own JsonSerializerContext");
		return JsonSerializer.Serialize(config, jsonTypeInfo);
	}
	
	public static string ToJson(this MqttDeviceDiscoveryConfig deviceConfig, JsonSerializerContext? ctx = null)
	{
		ctx ??= MqttDiscoveryJsonContext.Default;
		var jsonTypeInfo = ctx.GetTypeInfo(deviceConfig.GetType()) ?? throw new InvalidOperationException("The JsonTypeInfo for " + deviceConfig.GetType().FullName + " was not found in the provided JsonSerializerContext. If you have a custom Discovery Document you might need to provide your own JsonSerializerContext");
		return JsonSerializer.Serialize(deviceConfig, jsonTypeInfo);
	}
}

public static class MqttConnectionServiceExtensions
{
	/// <summary>
	/// Publishes the given discovery document.
	/// 
	/// If <paramref name="config"/>.Origin is null, it will be set to MqttOptions.Origin if set.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="connection"></param>
	/// <param name="config"></param>
	/// <param name="ctx"></param>
	/// <returns></returns>
	public static Task PublishDiscoveryDocument<T>(this IMqttConnectionService connection, T config, JsonSerializerContext? ctx = null) where T : MqttDiscoveryConfig
	{
		config.Origin ??= connection.MqttOptions.OriginConfig;

		return connection.PublishAsync(
			new MqttApplicationMessageBuilder()
				.WithTopic($"homeassistant/{config.Component}/{connection.MqttOptions.NodeId}/{config.UniqueId}/config")
				.WithRetainFlag()
				.WithPayload(config.ToJson(ctx))
				.Build());
	}
	
	/// <summary>
	/// Publishes the given device discovery document.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="connection"></param>
	/// <param name="deviceConfig"></param>
	/// <param name="ctx"></param>
	/// <returns></returns>
	public static Task PublishDiscoveryDocument(this IMqttConnectionService connection, MqttDeviceDiscoveryConfig deviceConfig, JsonSerializerContext? ctx = null)
	{
		return connection.PublishAsync(
			new MqttApplicationMessageBuilder()
				.WithTopic($"homeassistant/device/{connection.MqttOptions.NodeId}/{deviceConfig.Device.Identifiers!.First()}/config")
				.WithRetainFlag()
				.WithPayload(deviceConfig.ToJson(ctx))
				.Build());
	}
}
