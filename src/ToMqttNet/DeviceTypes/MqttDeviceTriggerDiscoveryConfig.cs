using System.Text.Json.Serialization;

namespace ToMqttNet;

/// <summary>
/// The mqtt device trigger platform uses an MQTT message payload to generate device trigger events.
/// </summary>
public class MqttDeviceTriggerDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "device_trigger";

	///<summary>
	/// The type of automation, must be ‘trigger’.
	///</summary> 
	[JsonPropertyName("automation_type")]
	public string AutomationType { get; set; } = null!;

	///<summary>
	/// Optional payload to match the payload being sent over the topic.
	///</summary> 
	[JsonPropertyName("payload")]
	public string? Payload { get; set; }

	///<summary>
	/// The maximum QoS level to be used when receiving messages.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	public long? Qos { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive trigger events.
	///</summary> 
	[JsonPropertyName("topic")]
	public string Topic { get; set; } = null!;

	///<summary>
	/// The type of the trigger, e.g. button_short_press. Entries supported by the frontend: button_short_press, button_short_release, button_long_press, button_long_release, button_double_press, button_triple_press, button_quadruple_press, button_quintuple_press. If set to an unsupported value, will render as subtype type, e.g. button_1 spammed with type set to spammed and subtype set to button_1
	///</summary> 
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	///<summary>
	/// The subtype of the trigger, e.g. button_1. Entries supported by the frontend: turn_on, turn_off, button_1, button_2, button_3, button_4, button_5, button_6. If set to an unsupported value, will render as subtype type, e.g. left_button pressed with type set to button_short_press and subtype set to left_button
	///</summary> 
	[JsonPropertyName("subtype")]
	public string Subtype { get; set; } = null!;

	///<summary>
	/// Defines a template to extract the value.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
