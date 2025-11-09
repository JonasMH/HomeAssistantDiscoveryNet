using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

public class HomeAssistantTemplateStringConverter : JsonConverter<string?>
{
	public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.TokenType switch
		{
			JsonTokenType.String => reader.GetString(),
			JsonTokenType.True => "true",
			JsonTokenType.False => "false",
			JsonTokenType.Null => null,
			_ => throw new JsonException($"Unexpected token {reader.TokenType}")
		};
	}

	public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value);
	}
}

[JsonSerializable(typeof(MqttAlarmControlPanelDiscoveryConfig))]
[JsonSerializable(typeof(MqttBinarySensorDiscoveryConfig))]
[JsonSerializable(typeof(MqttButtonDiscoveryConfig))]
[JsonSerializable(typeof(MqttCameraDiscoveryConfig))]
[JsonSerializable(typeof(MqttClimateDiscoveryConfig))]
[JsonSerializable(typeof(MqttCoverDiscoveryConfig))]
[JsonSerializable(typeof(MqttDefaultLightDiscoveryConfig))]
[JsonSerializable(typeof(MqttDeviceTrackerDiscoveryConfig))]
[JsonSerializable(typeof(MqttDeviceTriggerDiscoveryConfig))]
[JsonSerializable(typeof(MqttEventDiscoveryConfig))]
[JsonSerializable(typeof(MqttFanDiscoveryConfig))]
[JsonSerializable(typeof(MqttHumidifierDiscoveryConfig))]
[JsonSerializable(typeof(MqttJsonLightDiscoveryConfig))]
[JsonSerializable(typeof(MqttLockDiscoveryConfig))]
[JsonSerializable(typeof(MqttNumberDiscoveryConfig))]
[JsonSerializable(typeof(MqttSceneDiscoveryConfig))]
[JsonSerializable(typeof(MqttSelectDiscoveryConfig))]
[JsonSerializable(typeof(MqttSensorDiscoveryConfig))]
[JsonSerializable(typeof(MqttSirenDiscoveryConfig))]
[JsonSerializable(typeof(MqttSwitchDiscoveryConfig))]
[JsonSerializable(typeof(MqttTagScannerDiscoveryConfig))]
[JsonSerializable(typeof(MqttTemplateLightDiscoveryConfig))]
[JsonSerializable(typeof(MqttVacuumDiscoveryConfig))]
[JsonSerializable(typeof(MqttImageDiscoveryConfig))]
[JsonSerializable(typeof(MqttLawnMowerDiscoveryConfig))]
[JsonSerializable(typeof(MqttUpdateDiscoveryConfig))]
[JsonSerializable(typeof(MqttTextDiscoveryConfig))]
[JsonSerializable(typeof(MqttValveDiscoveryConfig))]
[JsonSerializable(typeof(MqttWaterHeaterDiscoveryConfig))]
[JsonSerializable(typeof(MqttNotifyDiscoveryConfig))]
[JsonSerializable(typeof(MqttDeviceDiscoveryConfig))]
[JsonSerializable(typeof(JsonObject))]
[JsonSourceGenerationOptions(
	WriteIndented = true,
	PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class MqttDiscoveryJsonContext : JsonSerializerContext
{

}