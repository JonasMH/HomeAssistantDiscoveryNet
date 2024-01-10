using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt tag scanner platform uses an MQTT message payload to generate tag scanned events.
/// </summary>
public class MqttWaterHeaterDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "water_heater";

	///<summary>
	/// A template with which the value received on current_temperature_topic will be rendered.
	///</summary> 
	[JsonPropertyName("current_temperature_template")]
	public string? CurrentTemperatureTemplate { get; set; }

	///<summary>
	/// The MQTT topic on which to listen for the current temperature. A "None" value received will reset the current temperature. Empty values (''') will be ignored.
	///</summary> 
	[JsonPropertyName("current_temperature_topic")]
	public string? CurrentTemperatureTopic { get; set; }

	///<summary>
	/// Flag which defines if the entity should be enabled when first added.
	/// , default: true
	///</summary> 
	[JsonPropertyName("enabled_by_default")]
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
	/// Set the initial target temperature. The default value depends on the temperature unit, and will be 43.3°C or 110°F.
	///</summary> 
	[JsonPropertyName("initial")]
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
	/// Maximum set point available. The default value depends on the temperature unit, and will be 60°C or 140°F.
	///</summary> 
	[JsonPropertyName("max_temp")]
	public double? MaxTemp { get; set; }

	///<summary>
	/// Minimum set point available. The default value depends on the temperature unit, and will be 43.3°C or 110°F.
	///</summary> 
	[JsonPropertyName("min_temp")]
	public double? MinTemp { get; set; }

	///<summary>
	/// A template to render the value sent to the mode_command_topic with.
	///</summary> 
	[JsonPropertyName("mode_command_template")]
	public string? ModeCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the water heater operation mode.
	///</summary> 
	[JsonPropertyName("mode_command_topic")]
	public string? ModeCommandTopic { get; set; }

	///<summary>
	/// A template to render the value received on the mode_state_topic with.
	///</summary> 
	[JsonPropertyName("mode_state_template")]
	public string? ModeStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes of the water heater operation mode. If this is not set, the operation mode works in optimistic mode (see below).
	///</summary> 
	[JsonPropertyName("mode_state_topic")]
	public string? ModeStateTopic { get; set; }

	///<summary>
	/// A list of supported modes. Needs to be a subset of the default values.
	/// Default: 
	///
	///[“off”, “eco”, “electric”, “gas”, “heat_pump”, “high_demand”, “performance”]
	///</summary> 
	[JsonPropertyName("modes")]
	public List<string>? Modes { get; set; }

	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// Flag that defines if the water heater works in optimistic mode
	/// Default: 
	///
	///true if no state topic defined, else false.
	///</summary> 
	[JsonPropertyName("optimistic")]
	public bool? Optimistic { get; set; }

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
	/// A template to render the value sent to the power_command_topic with. The value parameter is the payload set for payload_on or payload_off.
	///</summary> 
	[JsonPropertyName("power_command_template")]
	public string? PowerCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the water heater power state. Sends the payload configured with payload_on if the water heater is turned on via the water_heater.turn_on, or the payload configured with payload_off if the water heater is turned off via the water_heater.turn_off service. Note that optimistic mode is not supported through water_heater.turn_on and water_heater.turn_off services. When called, these services will send a power command to the device but will not optimistically update the state of the water heater. The water heater device should report its state back via mode_state_topic.
	///</summary> 
	[JsonPropertyName("power_command_topic")]
	public string? PowerCommandTopic { get; set; }

	///<summary>
	/// The desired precision for this device. Can be used to match your actual water heater’s precision. Supported values are 0.1, 0.5 and 1.0.
	/// Default: 
	///
	///0.1 for Celsius and 1.0 for Fahrenheit.
	///</summary> 
	[JsonPropertyName("precision")]
	public double? Precision { get; set; }

	///<summary>
	/// The maximum QoS level to be used when receiving and publishing messages.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	public long? Qos { get; set; }

	///<summary>
	/// Defines if published messages should have the retain flag set.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	public bool? Retain { get; set; }

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
	/// A template to render the value received on the temperature_state_topic with.
	///</summary> 
	[JsonPropertyName("temperature_state_template")]
	public string? TemperatureStateTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe for changes in the target temperature. If this is not set, the target temperature works in optimistic mode (see below). A "None" value received will reset the temperature set point. Empty values (''') will be ignored.
	///</summary> 
	[JsonPropertyName("temperature_state_topic")]
	public string? TemperatureStateTopic { get; set; }

	///<summary>
	/// Defines the temperature unit of the device, C or F. If this is not set, the temperature unit is set to the system temperature unit.
	///</summary> 
	[JsonPropertyName("temperature_unit")]
	public string? TemperatureUnit { get; set; }

	///<summary>
	/// Default template to render the payloads on all *_state_topics with.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
