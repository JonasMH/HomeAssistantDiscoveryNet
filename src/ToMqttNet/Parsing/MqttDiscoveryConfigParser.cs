using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ToMqttNet;

public class MqttDiscoveryConfigParser : IMqttDiscoveryConfigParser
{
	public static ReadOnlyDictionary<string, Type> OfficalDiscoveryConfigTypes = new(new Dictionary<string, Type>()
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
		{ "light", typeof(MqttLightDiscoveryConfig) },
		{ "lock", typeof(MqttLockDiscoveryConfig) },
		{ "number", typeof(MqttNumberDiscoveryConfig) },
		{ "scene", typeof(MqttSceneDiscoveryConfig) },
		{ "select", typeof(MqttSelectDiscoveryConfig) },
		{ "sensor", typeof(MqttSensorDiscoveryConfig) },
		{ "switch", typeof(MqttSwitchDiscoveryConfig) },
		{ "tag", typeof(MqttTagScannerDiscoveryConfig) },
		{ "vacuum", typeof(MqttVacuumDiscoveryConfig) },
	});

	private readonly ILogger<MqttDiscoveryConfigParser> _logger;
	private readonly Dictionary<string, Type> _discoveryConfigMap;

	public MqttDiscoveryConfigParser(
		ILogger<MqttDiscoveryConfigParser> logger,
		IEnumerable<CustomMqttDiscoveryConfigType> customConfigTypes)
	{
		_logger = logger;

		_discoveryConfigMap = OfficalDiscoveryConfigTypes
			.Concat(customConfigTypes.Select(x => new KeyValuePair<string, Type>(x.Key, x.Type)))
			.ToDictionary(x => x.Key, x => x.Value);
	}

	public MqttDiscoveryConfig? Parse(string topic, string message)
	{
		var componentType = topic.Split("/")[1];

		if (componentType == null)
		{
			_logger.LogWarning("Failed to parse discovery document, componentType was null");
			return null;
		}

		if (_discoveryConfigMap.TryGetValue(componentType, out var discoveryConfigType))
		{
			return (MqttDiscoveryConfig?)JsonConvert.DeserializeObject(message, discoveryConfigType, MqttDiscoveryConfigExtensions.DiscoveryJsonSettings);
		}

		_logger.LogWarning("Received document with unknown component {component}", componentType);
		return null;
	}
}