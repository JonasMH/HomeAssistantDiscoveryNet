using System.Text.Json.Serialization;

namespace ToMqttNet;

/// <summary>
/// The mqtt climate platform lets you control your MQTT enabled HVAC devices.
/// </summary>
public class MqttClimateDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "climate";

	///<summary>
	/// A template to render the value received on the action_topic with.
	///</summary> 
	[JsonPropertyName("action_template")]
	public string? ActionTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes of the current action. If this is set, the climate graph uses the value received as data source. Valid values: off, heating, cooling, drying, idle, fan.
	///</summary> 
	[JsonPropertyName("action_topic")]
	public string? ActionTopic { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to switch auxiliary heat.
	///</summary> 
	[JsonPropertyName("aux_command_topic")]
	public string? AuxCommandTopic { get; set; }

	///<summary>
	/// A template to render the value received on the aux_state_topic with.
	///</summary> 
	[JsonPropertyName("aux_state_template")]
	public string? AuxStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes of the auxiliary heat mode. If this is not set, the auxiliary heat mode works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("aux_state_topic")]
	public string? AuxStateTopic { get; set; }

	///<summary>
	/// A template with which the value received on current_temperature_topic will be rendered.
	///</summary> 
	[JsonPropertyName("current_temperature_template")]
	public string? CurrentTemperatureTemplate { get; set; }

	///<summary>
	/// The MQTT topic on which to listen for the current temperature.
	///</summary> 
	[JsonPropertyName("current_temperature_topic")]
	public string? CurrentTemperatureTopic { get; set; }

	///<summary>
	/// Flag which defines if the entity should be enabled when first added.
	/// , default: true
	///</summary> 
	[JsonPropertyName("enabled_by_default")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? EnabledByDefault { get; set; }

	///<summary>
	/// The encoding of the payloads received and published messages. Set to "" to disable decoding of incoming payload.
	/// , default: utf-8
	///</summary> 
	[JsonPropertyName("encoding")]
	public string? Encoding { get; set; }

	///<summary>
	/// The category of the entity.
	/// , default: None
	///</summary> 
	[JsonPropertyName("entity_category")]
	public string? EntityCategory { get; set; }

	///<summary>
	/// A template to render the value sent to the fan_mode_command_topic with.
	///</summary> 
	[JsonPropertyName("fan_mode_command_template")]
	public string? FanModeCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the fan mode.
	///</summary> 
	[JsonPropertyName("fan_mode_command_topic")]
	public string? FanModeCommandTopic { get; set; }

	///<summary>
	/// A template to render the value received on the fan_mode_state_topic with.
	///</summary> 
	[JsonPropertyName("fan_mode_state_template")]
	public string? FanModeStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes of the HVAC fan mode. If this is not set, the fan mode works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("fan_mode_state_topic")]
	public string? FanModeStateTopic { get; set; }

	///<summary>
	/// A list of supported fan modes.
	/// Default: 
	///
	///[“auto”, “low”, “medium”, “high”]
	///</summary> 
	[JsonPropertyName("fan_modes")]
	public List<string>? FanModes { get; set; }

	///<summary>
	/// Set the initial target temperature.
	/// , default: 21
	///</summary> 
	[JsonPropertyName("initial")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? Initial { get; set; }

	///<summary>
	/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic. Usage example can be found in MQTT sensor documentation.
	///</summary> 
	[JsonPropertyName("json_attributes_template")]
	public string? JsonAttributesTemplate { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Usage example can be found in MQTT sensor documentation.
	///</summary> 
	[JsonPropertyName("json_attributes_topic")]
	public string? JsonAttributesTopic { get; set; }

	///<summary>
	/// Maximum set point available.
	///</summary> 
	[JsonPropertyName("max_temp")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public double? MaxTemp { get; set; }

	///<summary>
	/// Minimum set point available.
	///</summary> 
	[JsonPropertyName("min_temp")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public double? MinTemp { get; set; }

	///<summary>
	/// A template to render the value sent to the mode_command_topic with.
	///</summary> 
	[JsonPropertyName("mode_command_template")]
	public string? ModeCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the HVAC operation mode.
	///</summary> 
	[JsonPropertyName("mode_command_topic")]
	public string? ModeCommandTopic { get; set; }

	///<summary>
	/// A template to render the value received on the mode_state_topic with.
	///</summary> 
	[JsonPropertyName("mode_state_template")]
	public string? ModeStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes of the HVAC operation mode. If this is not set, the operation mode works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("mode_state_topic")]
	public string? ModeStateTopic { get; set; }

	///<summary>
	/// A list of supported modes. Needs to be a subset of the default values.
	/// Default: 
	///
	///[“auto”, “off”, “cool”, “heat”, “dry”, “fan_only”]
	///</summary> 
	[JsonPropertyName("modes")]
	public List<string>? Modes { get; set; }

	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// The payload that represents the available state.
	/// , default: online
	///</summary> 
	[JsonPropertyName("payload_available")]
	public string? PayloadAvailable { get; set; }

	///<summary>
	/// The payload that represents the unavailable state.
	/// , default: offline
	///</summary> 
	[JsonPropertyName("payload_not_available")]
	public string? PayloadNotAvailable { get; set; }

	///<summary>
	/// The payload that represents disabled state.
	/// , default: OFF
	///</summary> 
	[JsonPropertyName("payload_off")]
	public string? PayloadOff { get; set; }

	///<summary>
	/// The payload that represents enabled state.
	/// , default: ON
	///</summary> 
	[JsonPropertyName("payload_on")]
	public string? PayloadOn { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the power state. This is useful if your device has a separate power toggle in addition to mode.
	///</summary> 
	[JsonPropertyName("power_command_topic")]
	public string? PowerCommandTopic { get; set; }

	///<summary>
	/// The desired precision for this device. Can be used to match your actual thermostat’s precision. Supported values are 0.1, 0.5 and 1.0.
	/// Default: 
	///
	///0.1 for Celsius and 1.0 for Fahrenheit.
	///</summary> 
	[JsonPropertyName("precision")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public double? Precision { get; set; }

	///<summary>
	/// Defines a template to generate the payload to send to preset_mode_command_topic.
	///</summary> 
	[JsonPropertyName("preset_mode_command_template")]
	public string? PresetModeCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the preset mode.
	///</summary> 
	[JsonPropertyName("preset_mode_command_topic")]
	public string? PresetModeCommandTopic { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive climate speed based on presets. When preset ‘none’ is received or None the preset_mode will be reset.
	///</summary> 
	[JsonPropertyName("preset_mode_state_topic")]
	public string? PresetModeStateTopic { get; set; }

	///<summary>
	/// Defines a template to extract the preset_mode value from the payload received on preset_mode_state_topic.
	///</summary> 
	[JsonPropertyName("preset_mode_value_template")]
	public string? PresetModeValueTemplate { get; set; }

	///<summary>
	/// List of preset modes this climate is supporting. Common examples include eco, away, boost, comfort, home, sleep and activity.
	/// , default: []
	///</summary> 
	[JsonPropertyName("preset_modes")]
	public List<string>? PresetModes { get; set; }

	///<summary>
	/// The maximum QoS level to be used when receiving and publishing messages.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? Qos { get; set; }

	///<summary>
	/// Defines if published messages should have the retain flag set.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Retain { get; set; }

	///<summary>
	/// A template to render the value sent to the swing_mode_command_topic with.
	///</summary> 
	[JsonPropertyName("swing_mode_command_template")]
	public string? SwingModeCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the swing mode.
	///</summary> 
	[JsonPropertyName("swing_mode_command_topic")]
	public string? SwingModeCommandTopic { get; set; }

	///<summary>
	/// A template to render the value received on the swing_mode_state_topic with.
	///</summary> 
	[JsonPropertyName("swing_mode_state_template")]
	public string? SwingModeStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes of the HVAC swing mode. If this is not set, the swing mode works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("swing_mode_state_topic")]
	public string? SwingModeStateTopic { get; set; }

	///<summary>
	/// A list of supported swing modes.
	/// , default: [“on”, “off”]
	///</summary> 
	[JsonPropertyName("swing_modes")]
	public List<string>? SwingModes { get; set; }

	///<summary>
	/// A template to render the value sent to the temperature_command_topic with.
	///</summary> 
	[JsonPropertyName("temperature_command_template")]
	public string? TemperatureCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the target temperature.
	///</summary> 
	[JsonPropertyName("temperature_command_topic")]
	public string? TemperatureCommandTopic { get; set; }

	///<summary>
	/// A template to render the value sent to the temperature_high_command_topic with.
	///</summary> 
	[JsonPropertyName("temperature_high_command_template")]
	public string? TemperatureHighCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the high target temperature.
	///</summary> 
	[JsonPropertyName("temperature_high_command_topic")]
	public string? TemperatureHighCommandTopic { get; set; }

	///<summary>
	/// A template to render the value received on the temperature_high_state_topic with.
	///</summary> 
	[JsonPropertyName("temperature_high_state_template")]
	public string? TemperatureHighStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes in the target high temperature. If this is not set, the target high temperature works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("temperature_high_state_topic")]
	public string? TemperatureHighStateTopic { get; set; }

	///<summary>
	/// A template to render the value sent to the temperature_low_command_topic with.
	///</summary> 
	[JsonPropertyName("temperature_low_command_template")]
	public string? TemperatureLowCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the target low temperature.
	///</summary> 
	[JsonPropertyName("temperature_low_command_topic")]
	public string? TemperatureLowCommandTopic { get; set; }

	///<summary>
	/// A template to render the value received on the temperature_low_state_topic with.
	///</summary> 
	[JsonPropertyName("temperature_low_state_template")]
	public string? TemperatureLowStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes in the target low temperature. If this is not set, the target low temperature works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("temperature_low_state_topic")]
	public string? TemperatureLowStateTopic { get; set; }

	///<summary>
	/// A template to render the value received on the temperature_state_topic with.
	///</summary> 
	[JsonPropertyName("temperature_state_template")]
	public string? TemperatureStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes in the target temperature. If this is not set, the target temperature works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("temperature_state_topic")]
	public string? TemperatureStateTopic { get; set; }

	///<summary>
	/// Defines the temperature unit of the device, C or F. If this is not set, the temperature unit is set to the system temperature unit.
	///</summary> 
	[JsonPropertyName("temperature_unit")]
	public string? TemperatureUnit { get; set; }

	///<summary>
	/// Step size for temperature set point.
	/// , default: 1
	///</summary> 
	[JsonPropertyName("temp_step")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public double? TempStep { get; set; }

	///<summary>
	/// Default template to render the payloads on all *_state_topics with.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
