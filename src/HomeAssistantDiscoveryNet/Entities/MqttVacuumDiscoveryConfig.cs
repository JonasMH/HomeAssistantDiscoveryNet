using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt vacuum integration allows you to control your MQTT-enabled vacuum. There are two possible message schemas - legacy and state, chosen by setting the schema configuration parameter. New installations should use the state schema as legacy is deprecated and might be removed someday in the future. The state schema is preferred because the vacuum will then be represented as a StateVacuumDevice which is the preferred parent vacuum entity.
/// </summary>
public class MqttVacuumDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "vacuum";

	///<summary>
	/// The MQTT topic to publish commands to control the vacuum.
	///</summary> 
	[JsonPropertyName("command_topic")]
	public string? CommandTopic { get; set; }

	///<summary>
	/// The encoding of the payloads received and published messages. Set to "" to disable decoding of incoming payload.
	/// , default: utf-8
	///</summary> 
	[JsonPropertyName("encoding")]
	public string? Encoding { get; set; }

	///<summary>
	/// List of possible fan speeds for the vacuum.
	///</summary> 
	[JsonPropertyName("fan_speed_list")]
	public List<string> FanSpeedList { get; set; } = null!;

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
	/// The payload to send to the command_topic to begin a spot cleaning cycle.
	/// , default: clean_spot
	///</summary> 
	[JsonPropertyName("payload_clean_spot")]
	public string? PayloadCleanSpot { get; set; }

	///<summary>
	/// The payload to send to the command_topic to locate the vacuum (typically plays a song).
	/// , default: locate
	///</summary> 
	[JsonPropertyName("payload_locate")]
	public string? PayloadLocate { get; set; }

	///<summary>
	/// The payload that represents the unavailable state.
	/// , default: offline
	///</summary> 
	[JsonPropertyName("payload_not_available")]
	public string? PayloadNotAvailable { get; set; }

	///<summary>
	/// The payload to send to the command_topic to pause the vacuum.
	/// , default: pause
	///</summary> 
	[JsonPropertyName("payload_pause")]
	public string? PayloadPause { get; set; }

	///<summary>
	/// The payload to send to the command_topic to tell the vacuum to return to base.
	/// , default: return_to_base
	///</summary> 
	[JsonPropertyName("payload_return_to_base")]
	public string? PayloadReturnToBase { get; set; }

	///<summary>
	/// The payload to send to the command_topic to begin the cleaning cycle.
	/// , default: start
	///</summary> 
	[JsonPropertyName("payload_start")]
	public string? PayloadStart { get; set; }

	///<summary>
	/// The payload to send to the command_topic to stop cleaning.
	/// , default: stop
	///</summary> 
	[JsonPropertyName("payload_stop")]
	public string? PayloadStop { get; set; }

	///<summary>
	/// The maximum QoS level of the state topic.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? Qos { get; set; }

	///<summary>
	/// If the published message should have the retain flag on or not.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Retain { get; set; }

	///<summary>
	/// The schema to use. Must be state to select the state schema.
	/// , default: legacy
	///</summary> 
	[JsonPropertyName("schema")]
	public string? Schema { get; set; }

	///<summary>
	/// The MQTT topic to publish custom commands to the vacuum.
	///</summary> 
	[JsonPropertyName("send_command_topic")]
	public string? SendCommandTopic { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to control the vacuum’s fan speed.
	///</summary> 
	[JsonPropertyName("set_fan_speed_topic")]
	public string? SetFanSpeedTopic { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive state messages from the vacuum. Messages received on the state_topic must be a valid JSON dictionary, with a mandatory state key and optionally battery_level and fan_speed keys as shown in the example.
	///</summary> 
	[JsonPropertyName("state_topic")]
	public string? StateTopic { get; set; }

	///<summary>
	/// List of features that the vacuum supports (possible values are start, stop, pause, return_home, battery, status, locate, clean_spot, fan_speed, send_command).
	/// Default: 
	///
	///start, stop, return_home, status, battery, clean_spot
	///</summary> 
	[JsonPropertyName("supported_features")]
	public List<string> SupportedFeatures { get; set; } = null!;
}
