using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt Select platform allows you to integrate devices that might expose configuration options through MQTT into Home Assistant as a Select. Every time a message under the topic in the configuration is received, the select entity will be updated in Home Assistant and vice-versa, keeping the device and Home Assistant in sync.
/// </summary>
public class MqttLawnMowerDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "lawn_mower";

	///<summary>
	/// The MQTT topic subscribed to receive an update of the activity. Valid activities are mowing, paused, docked, and error. Use value_template to extract the activity state from a custom payload. When payload none is received, the activity state will be reset to unknown.
	///</summary> 
	[JsonPropertyName("activity_state_topic")]
	public string? ActivityStateTopic { get; set; }

	///<summary>
	/// Defines a template to extract the value.
	///</summary> 
	[JsonPropertyName("activity_value_template")]
	public string? ActivityValueTemplate { get; set; }

	///<summary>
	/// Defines a template to generate the payload to send to dock_command_topic. The value parameter in the template will be set to dock.
	///</summary> 
	[JsonPropertyName("dock_command_template")]
	public string? DockCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic that publishes commands when the service lawn_mower.dock service call is executed. The value dock is published when the service is called. Use a dock_command_template to publish a custom format.
	///</summary> 
	[JsonPropertyName("dock_command_topic")]
	public string? DockCommandTopic { get; set; }

	///<summary>
	/// Flag which defines if the entity should be enabled when first added.
	/// , default: true
	///</summary> 
	[JsonPropertyName("enabled_by_default")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? EnabledByDefault { get; set; }

	///<summary>
	/// The encoding of the payloads received and published messages. Set to "" to disable decoding of the incoming payload.
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
	/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic.
	///</summary> 
	[JsonPropertyName("json_attributes_template")]
	public string? JsonAttributesTemplate { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as entity attributes. Implies force_update of the current activity state when a message is received on this topic.
	///</summary> 
	[JsonPropertyName("json_attributes_topic")]
	public string? JsonAttributesTopic { get; set; }

	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// Flag that defines if the lawn mower works in optimistic mode.
	/// Default: 
	///
	///true if no activity_state_topic defined, else false.
	///</summary> 
	[JsonPropertyName("optimistic")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Optimistic { get; set; }

	///<summary>
	/// Defines a template to generate the payload to send to pause_command_topic. The value parameter in the template will be set to pause.
	///</summary> 
	[JsonPropertyName("pause_command_template")]
	public string? PauseCommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic that publishes commands when the service lawn_mower.pause service call is executed. The value pause is published when the service is called. Use a pause_command_template to publish a custom format.
	///</summary> 
	[JsonPropertyName("pause_command_topic")]
	public string? PauseCommandTopic { get; set; }

	///<summary>
	/// The maximum QoS level to be used when receiving and publishing messages.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? Qos { get; set; }

	///<summary>
	/// Defines a template to generate the payload to send to dock_command_topic. The value parameter in the template will be set to dock.
	///</summary> 
	[JsonPropertyName("start_mowing_template")]
	public string? StartMowingTemplate { get; set; }

	///<summary>
	/// The MQTT topic that publishes commands when the service lawn_mower.start_mowing service call is executed. The value start_mowing is published when the service is called. Use a start_mowing_command_template to publish a custom format.
	///</summary> 
	[JsonPropertyName("start_mowing_command_topic")]
	public string? StartMowingCommandTopic { get; set; }

	///<summary>
	/// If the published message should have the retain flag on or not.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Retain { get; set; }
}
