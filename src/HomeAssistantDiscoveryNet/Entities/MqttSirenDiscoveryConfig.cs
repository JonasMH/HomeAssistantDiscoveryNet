using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt siren platform lets you control your MQTT enabled sirens and text based notification devices.
/// </summary>
public class MqttSirenDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "siren";


	///<summary>
	/// A list of available tones the siren supports. When configured, this enables the support for setting a tone and enables the tone state attribute.
	///</summary> 
	[JsonPropertyName("available_tones")]
	public List<string>? AvailableTones { get; set; }

	///<summary>
	/// Defines a template to generate a custom payload to send to command_topic. The variable value will be assigned with the configured payload_on or payload_off setting. The siren turn on service parameters tone, volume_level or duration can be used as variables in the template. When operation in optimistic mode the corresponding state attributes will be set. Turn on parameters will be filtered if a device misses the support.
	///</summary> 
	[JsonPropertyName("command_template")]
	public string? CommandTemplate { get; set; }

	///<summary>
	/// Defines a template to generate a custom payload to send to command_topic when the siren turn off service is called. By default command_template will be used as template for service turn off. The variable value will be assigned with the configured payload_off setting.
	///</summary> 
	[JsonPropertyName("command_off_template")]
	public string? CommandOffTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the siren state. Without command templates, a default JSON payload like {"state":"ON", "tone": "bell", "duration": 10, "volume_level": 0.5 } is published. When the siren turn on service is called, the startup parameters will be added to the JSON payload. The state value of the JSON payload will be set to the the payload_on or payload_off configured payload.
	///</summary> 
	[JsonPropertyName("command_topic")]
	public string? CommandTopic { get; set; }

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
	/// Flag that defines if siren works in optimistic mode.
	/// Default: 
	///
	///true if no state_topic defined, else false.
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
	/// The payload that represents off state. If specified, will be used for both comparing to the value in the state_topic (see value_template and state_off for details) and sending as off command to the command_topic.
	/// , default: OFF
	///</summary> 
	[JsonPropertyName("payload_off")]
	public string? PayloadOff { get; set; }

	///<summary>
	/// The payload that represents on state. If specified, will be used for both comparing to the value in the state_topic (see value_template and state_on for details) and sending as on command to the command_topic.
	/// , default: ON
	///</summary> 
	[JsonPropertyName("payload_on")]
	public string? PayloadOn { get; set; }

	///<summary>
	/// The maximum QoS level to be used when receiving and publishing messages.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	public long? Qos { get; set; }

	///<summary>
	/// If the published message should have the retain flag on or not.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	public bool? Retain { get; set; }

	///<summary>
	/// The payload that represents the off state. Used when value that represents off state in the state_topic is different from value that should be sent to the command_topic to turn the device off.
	/// Default: 
	///
	///payload_off if defined, else 'OFF'
	///</summary> 
	[JsonPropertyName("state_off")]
	public string? StateOff { get; set; }

	///<summary>
	/// The payload that represents the on state. Used when value that represents on state in the state_topic is different from value that should be sent to the command_topic to turn the device on.
	/// Default: 
	///
	///payload_on if defined, else 'ON'
	///</summary> 
	[JsonPropertyName("state_on")]
	public string? StateOn { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive state updates. The state update may be either JSON or a simple string. When a JSON payload is detected, the state value of the JSON payload should supply the payload_on or payload_off defined payload to turn the siren on or off. Additionally, the state attributes duration, tone and volume_level can be updated. Use value_template to transform the received state udpate to a compliant JSON payload. Attributes will only be set if the function is supported by the device and a valid value is supplied. When a non JSON payload is detected, it should be either of the payload_on or payload_off defined payloads or None to reset the siren’s state to unknown. The initial state will be unknown. The state will be reset to unknown if a None payload or null JSON value is received as a state update.
	///</summary> 
	[JsonPropertyName("state_topic")]
	public string? StateTopic { get; set; }

	///<summary>
	/// Defines a template to extract device’s state from the state_topic. To determine the siren’s state result of this template will be compared to state_on and state_off. Alternatively value_template can be used to render to a valid JSON payload.
	///</summary> 
	[JsonPropertyName("state_value_template")]
	public string? StateValueTemplate { get; set; }

	///<summary>
	/// Set to true if the MQTT siren supports the duration service turn on parameter and enables the duration state attribute.
	/// , default: true
	///</summary> 
	[JsonPropertyName("support_duration")]
	public bool? SupportDuration { get; set; }

	///<summary>
	/// Set to true if the MQTT siren supports the volume_set service turn on parameter and enables the volume_level state attribute.
	/// , default: true
	///</summary> 
	[JsonPropertyName("support_volume_set")]
	public bool? SupportVolumeSet { get; set; }
}
