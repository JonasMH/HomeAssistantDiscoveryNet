using System.Text.Json.Serialization;

namespace ToMqttNet;

/// <summary>
/// The mqtt light platform lets you control your MQTT enabled lights through one of the supported message schemas, default, json or template.
/// 
/// This is the json template
/// </summary>
public class MqttJsonLightDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "light";

	///<summary>
	/// Flag that defines if the light supports brightness.
	/// , default: false
	///</summary> 
	[JsonPropertyName("brightness")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Brightness { get; set; }

	///<summary>
	/// Defines the maximum brightness value (i.e., 100%) of the MQTT device.
	/// , default: 255
	///</summary> 
	[JsonPropertyName("brightness_scale")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? BrightnessScale { get; set; }

	///<summary>
	/// Flag that defines if the light supports color modes.
	/// , default: false
	///</summary> 
	[JsonPropertyName("color_mode")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? ColorMode { get; set; }

	///<summary>
	/// The MQTT topic to publish commands to change the light’s state.
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
	/// Flag that defines if the light supports effects.
	/// , default: false
	///</summary> 
	[JsonPropertyName("effect")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public bool? Effect { get; set; }

	///<summary>
	/// The list of effects the light supports.
	///</summary> 
	[JsonPropertyName("effect_list")]
	public List<string>? EffectList { get; set; }

	///<summary>
	/// The duration, in seconds, of a “long” flash.
	/// , default: 10
	///</summary> 
	[JsonPropertyName("flash_time_long")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? FlashTimeLong { get; set; }

	///<summary>
	/// The duration, in seconds, of a “short” flash.
	/// , default: 2
	///</summary> 
	[JsonPropertyName("flash_time_short")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? FlashTimeShort { get; set; }

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
	/// The maximum color temperature in mireds.
	///</summary> 
	[JsonPropertyName("max_mireds")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? MaxMireds { get; set; }

	///<summary>
	/// The minimum color temperature in mireds.
	///</summary> 
	[JsonPropertyName("min_mireds")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public long? MinMireds { get; set; }

	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// Flag that defines if the light works in optimistic mode.
	/// Default: 
	///
	///true if no state topic defined, else false.
	///</summary> 
	[JsonPropertyName("optimistic")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
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
	/// The schema to use. Must be json to select the JSON schema.
	///</summary> 
	[JsonPropertyName("schema")]
	public string? Schema { get; } = "json";

	///<summary>
	/// The MQTT topic subscribed to receive state updates.
	///</summary> 
	[JsonPropertyName("state_topic")]
	public string? StateTopic { get; set; }

	///<summary>
	/// A list of color modes supported by the list. This is required if color_mode is True. Possible color modes are onoff, brightness, color_temp, hs, xy, rgb, rgbw, rgbww.
	///</summary> 
	[JsonPropertyName("supported_color_modes")]
	public List<string>? SupportedColorModes { get; set; }

}
