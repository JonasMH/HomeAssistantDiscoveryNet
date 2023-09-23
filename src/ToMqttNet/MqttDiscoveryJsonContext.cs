using System.Text.Json.Serialization;

namespace ToMqttNet;

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
[JsonSerializable(typeof(MqttSwitchDiscoveryConfig))]
[JsonSerializable(typeof(MqttTagScannerDiscoveryConfig))]
[JsonSerializable(typeof(MqttTemplateLightDiscoveryConfig))]
[JsonSerializable(typeof(MqttVacuumDiscoveryConfig))]
[JsonSourceGenerationOptions(
	WriteIndented = true,
	PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class MqttDiscoveryJsonContext : JsonSerializerContext
{

}
