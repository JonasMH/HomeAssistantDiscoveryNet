using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt tag scanner platform uses an MQTT message payload to generate tag scanned events.
/// </summary>
public class MqttUpdateDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "update";


	///<summary>
	/// The MQTT topic to publish payload_install to start installing process.
	///</summary> 
	[JsonPropertyName("command_topic")]
	public string? CommandTopic { get; set; }

	///<summary>
	/// The type/class of the update to set the icon in the frontend. The device_class can be null.
	/// , default: None
	///</summary> 
	[JsonPropertyName("device_class")]
	public string? DeviceClass { get; set; }

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
	/// Picture URL for the entity.
	///</summary> 
	[JsonPropertyName("entity_picture")]
	public string? EntityPicture { get; set; }

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
	/// Defines a template to extract the latest version value.
	///</summary> 
	[JsonPropertyName("latest_version_template")]
	public string? LatestVersionTemplate { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive an update of the latest version.
	///</summary> 
	[JsonPropertyName("latest_version_topic")]
	public string? LatestVersionTopic { get; set; }


	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// The MQTT payload to start installing process.
	///</summary> 
	[JsonPropertyName("payload_install")]
	public string? PayloadInstall { get; set; }

	///<summary>
	/// The maximum QoS level to be used when receiving and publishing messages.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	public long? Qos { get; set; }

	///<summary>
	/// Summary of the release notes or changelog. This is suitable a brief update description of max 255 characters.
	///</summary> 
	[JsonPropertyName("release_summary")]
	public string? ReleaseSummary { get; set; }

	///<summary>
	/// URL to the full release notes of the latest version available.
	///</summary> 
	[JsonPropertyName("release_url")]
	public string? ReleaseUrl { get; set; }

	///<summary>
	/// If the published message should have the retain flag on or not.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	public bool? Retain { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive state updates. The state update may be either JSON or a simple string with installed_version value. When a JSON payload is detected, the state value of the JSON payload should supply the installed_version and can optional supply: latest_version, title, release_summary, release_url or an entity_picture URL.
	///</summary> 
	[JsonPropertyName("state_topic")]
	public string? StateTopic { get; set; }

	///<summary>
	/// Title of the software, or firmware update. This helps to differentiate between the device or entity name versus the title of the software installed.
	///</summary> 
	[JsonPropertyName("title")]
	public string? Title { get; set; }

	///<summary>
	/// Defines a template to extract the installed_version state value or to render to a valid JSON payload on from the payload received on state_topic.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
