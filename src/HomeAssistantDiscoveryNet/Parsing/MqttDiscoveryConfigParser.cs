using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

public class MqttDiscoveryConfigParser(
	ILoggerFactory loggerFactory,
	IEnumerable<CustomMqttDiscoveryConfigType> customConfigTypes) : IMqttDiscoveryConfigParser
{
	public static ReadOnlyDictionary<string, Type> OfficalDiscoveryConfigTypes { get; } = new(new Dictionary<string, Type>()
	{
		// Official
		{ "alarm_control_panel", typeof(MqttAlarmControlPanelDiscoveryConfig) },
		{ "binary_sensor", typeof(MqttBinarySensorDiscoveryConfig) },
		{ "button", typeof(MqttButtonDiscoveryConfig) },
		{ "camera", typeof(MqttCameraDiscoveryConfig) },
		{ "device_tracker", typeof(MqttDeviceTrackerDiscoveryConfig) },
		{ "device_trigger", typeof(MqttDeviceTriggerDiscoveryConfig) },
		{ "fan", typeof(MqttFanDiscoveryConfig) },
		{ "humidifier", typeof(MqttHumidifierDiscoveryConfig) },
		{ "climate", typeof(MqttClimateDiscoveryConfig) },
		{ "lock", typeof(MqttLockDiscoveryConfig) },
		{ "number", typeof(MqttNumberDiscoveryConfig) },
		{ "scene", typeof(MqttSceneDiscoveryConfig) },
		{ "select", typeof(MqttSelectDiscoveryConfig) },
		{ "sensor", typeof(MqttSensorDiscoveryConfig) },
		{ "switch", typeof(MqttSwitchDiscoveryConfig) },
		{ "tag", typeof(MqttTagScannerDiscoveryConfig) },
		{ "vacuum", typeof(MqttVacuumDiscoveryConfig) },
		{ "event", typeof(MqttEventDiscoveryConfig) },
		{ "image", typeof(MqttImageDiscoveryConfig) },
		{ "lawn_mower", typeof(MqttLawnMowerDiscoveryConfig) },
		{ "siren", typeof(MqttSirenDiscoveryConfig) },
		{ "update", typeof(MqttUpdateDiscoveryConfig) },
		{ "text", typeof(MqttTextDiscoveryConfig) },
		{ "valve", typeof(MqttValveDiscoveryConfig) },
		{ "water_heater", typeof(MqttWaterHeaterDiscoveryConfig) },
	});

	private readonly ILogger<MqttDiscoveryConfigParser> _logger = loggerFactory.CreateLogger<MqttDiscoveryConfigParser>();
	private readonly Dictionary<string, Type> _discoveryConfigMap = OfficalDiscoveryConfigTypes
			.Concat(customConfigTypes.Select(x => new KeyValuePair<string, Type>(x.Key, x.Type)))
			.ToDictionary(x => x.Key, x => x.Value);

	/// <summary>
	/// Returns null if unable to parse it
	/// </summary>
	public MqttDiscoveryConfig? Parse(string topic, string message, JsonSerializerContext? jsonContext = null)
	{
		jsonContext ??= MqttDiscoveryJsonContext.Default;

		var componentType = topic.Split("/")[1];

		if (componentType == null)
		{
			_logger.LogWarning("Failed to parse discovery document, componentType was null");
			return null;
		}

		if (componentType == "light")
		{
			return ParseLight(message, jsonContext);
		}

		if (_discoveryConfigMap.TryGetValue(componentType, out var discoveryConfigType))
		{
			var jsonTypeInfo = jsonContext.GetTypeInfo(discoveryConfigType) ?? throw new InvalidOperationException("The JsonTypeInfo for " + discoveryConfigType.FullName + " was not found in the provided JsonSerializerContext. If you have a custom Discovery Document you might need to provide your own JsonSerializerContext");
			return (MqttDiscoveryConfig?)JsonSerializer.Deserialize(message, jsonTypeInfo);
		}

		_logger.LogWarning("Received document with unknown component {component}", componentType);
		return null;
	}

	private MqttDiscoveryConfig? ParseLight(string message, JsonSerializerContext jsonContext)
	{
		var jToken = JsonSerializer.Deserialize(message, MqttDiscoveryJsonContext.Default.JsonObject);
		var schema = "default";

        if (jToken != null && jToken.TryGetPropertyValue("schema", out var val))
        {
			schema = val?.GetValue<string>() ?? "default";
        }

        switch (schema)
		{
			case "default":
				return (MqttDiscoveryConfig?)JsonSerializer.Deserialize(message, jsonContext.Options.GetTypeInfo(typeof(MqttDefaultLightDiscoveryConfig)));
			case "json":
				return (MqttDiscoveryConfig?)JsonSerializer.Deserialize(message, jsonContext.Options.GetTypeInfo(typeof(MqttJsonLightDiscoveryConfig)));
			case "template":
				return (MqttDiscoveryConfig?)JsonSerializer.Deserialize(message, jsonContext.Options.GetTypeInfo(typeof(MqttTemplateLightDiscoveryConfig)));
		}

		_logger.LogWarning("Does not support light with schema {schema}", schema);
		return null;
	}
}