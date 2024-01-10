using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt image platform allows you to integrate the content of an image file sent through MQTT into Home Assistant as an image. The image platform is a simplified version of the camera platform that only accepts images. Every time a message under the image_topic in the configuration is received, the image displayed in Home Assistant will also be updated. Messages received on image_topic should contain the full contents of an image file, for example, a JPEG image, without any additional encoding or metadata.
/// </summary>
public class MqttImageDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "image";

	///<summary>
	/// The content type of and image data message received on image_topic. This option cannot be used with the url_topic because the content type is derived when downloading the image.
	/// , default: image/jpeg
	///</summary> 
	[JsonPropertyName("content_type")]
	public string? ContentType { get; set; }

	///<summary>
	/// Flag which defines if the entity should be enabled when first added.
	/// , default: true
	///</summary> 
	[JsonPropertyName("enabled_by_default")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? EnabledByDefault { get; set; }

	///<summary>
	/// The encoding of the payloads received. Set to "" to disable decoding of incoming payload. Use image_encoding to enable Base64 decoding on image_topic.
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
	/// The encoding of the image payloads received. Set to "b64" to enable base64 decoding of image payload. If not set, the image payload must be raw binary data.
	/// , default: None
	///</summary> 
	[JsonPropertyName("image_encoding")]
	public string? ImageEncoding { get; set; }

	///<summary>
	/// The MQTT topic to subscribe to receive the image payload of the image to be downloaded. Ensure the content_type type option is set to the corresponding content type. This option cannot be used together with the url_topic option. But at least one of these option is required.
	///</summary> 
	[JsonPropertyName("image_topic")]
	public string? ImageTopic { get; set; }

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
	/// Defines a template to extract the image URL from a message received at url_topic.
	///</summary> 
	[JsonPropertyName("url_template")]
	public string? UrlTemplate { get; set; }

	///<summary>
	/// The MQTT topic to subscribe to receive an image URL. A url_template option can extract the URL from the message. The content_type will be derived from the image when downloaded. This option cannot be used together with the image_topic option, but at least one of these options is required.
	///</summary> 
	[JsonPropertyName("url_topic")]
	public string? UrlTopic { get; set; }
}


