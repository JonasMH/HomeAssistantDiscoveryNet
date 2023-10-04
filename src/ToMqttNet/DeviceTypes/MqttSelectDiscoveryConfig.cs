using System.Text.Json.Serialization;

namespace ToMqttNet;

/// <summary>
/// The mqtt Select platform allows you to integrate devices that might expose configuration options through MQTT into Home Assistant as a Select. Every time a message under the topic in the configuration is received, the select entity will be updated in Home Assistant and vice-versa, keeping the device and Home Assistant in sync.
/// </summary>
public class MqttSelectDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "select";

	///<summary>
	/// Defines a template to generate the payload to send to command_topic.
	///</summary> 
	[JsonPropertyName("command_template")]
	public string? CommandTemplate { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the selected option.
	///</summary> 
	[JsonPropertyName("command_topic")]
	public string CommandTopic { get; set; } = null!;

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
	/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic.
	///</summary> 
	[JsonPropertyName("json_attributes_template")]
	public string? JsonAttributesTemplate { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as entity attributes. Implies force_update of the current select state when a message is received on this topic.
	///</summary> 
	[JsonPropertyName("json_attributes_topic")]
	public string? JsonAttributesTopic { get; set; }

	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// Flag that defines if the select works in optimistic mode.
	/// Default: 
	///
	///true if no state_topic defined, else false.
	///</summary> 
	[JsonPropertyName("optimistic")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Optimistic { get; set; }

	///<summary>
	/// List of options that can be selected. An empty list or a list with a single item is allowed.
	///</summary> 
	[JsonPropertyName("options")]
	public List<string> Options { get; set; } = null!;

	///<summary>
	/// The maximum QoS level of the state topic. Default is 0 and will also be used to publishing messages.
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
	/// The MQTT topic subscribed to receive update of the selected option.
	///</summary> 
	[JsonPropertyName("state_topic")]
	public string? StateTopic { get; set; }

	///<summary>
	/// Defines a template to extract the value.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
