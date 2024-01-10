using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt valve platform allows you to control an MQTT valve (such a gas or water valve).
/// </summary>
public class MqttValveDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "valve";

	///<summary>
	/// Defines a template to generate the payload to send to command_topic.
	///</summary> 
	[JsonPropertyName("command_template")]
	public string? CommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to control the valve. The value sent can be a value defined by payload_open, payload_close or payload_stop. If reports_position is set to true, a numeric value will be published instead.
	///</summary> 
	[JsonPropertyName("command_topic")]
	public string? CommandTopic { get; set; }

	///<summary>
	/// Sets the class of the device, changing the device state and icon that is displayed on the frontend. The device_class can be null.
	/// , default: None
	///</summary> 
	[JsonPropertyName("device_class")]
	public string? DeviceClass { get; set; }

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
	/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic. A usage example can be found in the MQTT sensor documentation.
	///</summary> 
	[JsonPropertyName("json_attributes_template")]
	public string? JsonAttributesTemplate { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. A usage example can be found in MQTT sensor documentation.
	///</summary> 
	[JsonPropertyName("json_attributes_topic")]
	public string? JsonAttributesTopic { get; set; }

	///<summary>
	/// Used instead of name to have the entity_id generated automatically.
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// Flag that defines if a switch works in optimistic mode.
	/// Default: 
	///
	///false if the state or position topic is defined; true otherwise.
	///</summary> 
	[JsonPropertyName("optimistic")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Optimistic { get; set; }

	///<summary>
	/// The payload that represents the online state.
	/// , default: online
	///</summary> 
	[JsonPropertyName("payload_available")]
	public string? PayloadAvailable { get; set; }

	///<summary>
	/// The command payload that closes the valve. Is only used when reports_position is set to false (default). The payload_close is not allowed if reports_position is set to true. Can be set to null to disable the valve’s close option.
	/// , default: CLOSE
	///</summary> 
	[JsonPropertyName("payload_close")]
	public string? PayloadClose { get; set; }

	///<summary>
	/// The payload that represents the offline state.
	/// , default: offline
	///</summary> 
	[JsonPropertyName("payload_not_available")]
	public string? PayloadNotAvailable { get; set; }

	///<summary>
	/// The command payload that opens the valve. Is only used when reports_position is set to false (default). The payload_open is not allowed if reports_position is set to true. Can be set to null to disable the valve’s open option.
	/// , default: OPEN
	///</summary> 
	[JsonPropertyName("payload_open")]
	public string? PayloadOpen { get; set; }

	///<summary>
	/// The command payload that stops the valve. When not configured, the valve will not support the valve.stop service.
	///</summary> 
	[JsonPropertyName("payload_stop")]
	public string? PayloadStop { get; set; }

	///<summary>
	/// Number which represents closed position. The valve’s position will be scaled to the(position_closed…position_open) range when a service is called and scaled back when a value is received.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("position_closed")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? PositionClosed { get; set; }

	///<summary>
	/// Number which represents open position. The valve’s position will be scaled to (position_closed…position_open) range when a service is called and scaled back when a value is received.
	/// , default: 100
	///</summary> 
	[JsonPropertyName("position_open")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? PositionOpen { get; set; }

	///<summary>
	/// The maximum QoS level to be used when receiving and publishing messages.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? Qos { get; set; }

	///<summary>
	/// Set to true if the value reports the position or supports setting the position. Enabling the reports_position option will cause the position to be published instead of a payload defined by payload_open, payload_close or payload_stop. When receiving messages, state_topic will accept numeric payloads or one of the following state messages: open, opening, closed, or closing.
	/// , default: false
	///</summary> 
	[JsonPropertyName("reports_position")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? ReportsPosition { get; set; }

	///<summary>
	/// Defines if published messages should have the retain flag set.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Retain { get; set; }

	///<summary>
	/// The payload that represents the closed state. Is only allowed when reports_position is set to False (default).
	/// , default: closed
	///</summary> 
	[JsonPropertyName("state_closed")]
	public string? StateClosed { get; set; }

	///<summary>
	/// The payload that represents the closing state.
	/// , default: closing
	///</summary> 
	[JsonPropertyName("state_closing")]
	public string? StateClosing { get; set; }

	///<summary>
	/// The payload that represents the open state. Is only allowed when reports_position is set to False (default).
	/// , default: open
	///</summary> 
	[JsonPropertyName("state_open")]
	public string? StateOpen { get; set; }

	///<summary>
	/// The payload that represents the opening state.
	/// , default: opening
	///</summary> 
	[JsonPropertyName("state_opening")]
	public string? StateOpening { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive valve state messages. State topic accepts a state payload (open, opening, closed, or closing) or, if reports_position is supported, a numeric value representing the position. In a JSON format with variables state and position both values can received together.
	///</summary> 
	[JsonPropertyName("state_topic")]
	public string? StateTopic { get; set; }

	///<summary>
	/// Defines a template that can be used to extract the payload for the state_topic topic. The rendered value should be a defined state payload or, if reporting a position is supported and reports_position is set to true, a numeric value is expected representing the position. See also state_topic.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
