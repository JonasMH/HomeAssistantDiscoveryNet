using System.Text.Json.Serialization;

namespace ToMqttNet;

/// <summary>
/// The mqtt camera platform allows you to integrate the content of an image file sent through MQTT into Home Assistant as a camera. Every time a message under the topic in the configuration is received, the image displayed in Home Assistant will also be updated.
/// </summary>
public class MqttCameraDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "camera";

	///<summary>
	/// Flag which defines if the entity should be enabled when first added.
	/// , default: true
	///</summary> 
	[JsonPropertyName("enabled_by_default")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? EnabledByDefault { get; set; }

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
	/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Implies force_update of the current sensor state when a message is received on this topic.
	///</summary> 
	[JsonPropertyName("json_attributes_topic")]
	public string? JsonAttributesTopic { get; set; }

	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// The MQTT topic to subscribe to.
	///</summary> 
	[JsonPropertyName("topic")]
	public string Topic { get; set; } = null!;
}
