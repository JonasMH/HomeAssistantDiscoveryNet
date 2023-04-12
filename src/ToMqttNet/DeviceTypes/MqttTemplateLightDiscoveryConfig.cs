using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt light platform lets you control your MQTT enabled lights through one of the supported message schemas, default, json or template.
	/// 
	/// This is the template template
	/// </summary>
	public class MqttTemplateLightDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "light";

		///<summary>
		/// Template to extract blue color from the state payload value. Expected result of the template is an integer from 0-255 range.
		///</summary> 
		[JsonProperty("blue_template")]
		public string? BlueTemplate { get; set; }

		///<summary>
		/// Template to extract brightness from the state payload value. Expected result of the template is an integer from 0-255 range.
		///</summary> 
		[JsonProperty("brightness_template")]
		public string? BrightnessTemplate { get; set; }

		///<summary>
		/// Template to extract color temperature from the state payload value. Expected result of the template is an integer representing mired units.
		///</summary> 
		[JsonProperty("color_temp_template")]
		public string? ColorTempTemplate { get; set; }

		///<summary>
		/// The template for off state changes. Available variables: state and transition.
		///</summary> 
		[JsonProperty("command_off_template")]
		public string CommandOffTemplate { get; set; }

		///<summary>
		/// The template for on state changes. Available variables: state, brightness, color_temp, red, green, blue, flash, transition and effect. Values red, green, blue, brightness are provided as integers from range 0-255. Value of color_temp is provided as integer representing mired units.
		///</summary> 
		[JsonProperty("command_on_template")]
		public string CommandOnTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the light’s state.
		///</summary> 
		[JsonProperty("command_topic")]
		public string CommandTopic { get; set; }

		///<summary>
		/// Flag which defines if the entity should be enabled when first added.
		/// , default: true
		///</summary> 
		[JsonProperty("enabled_by_default")]
		public bool? EnabledByDefault { get; set; }

		///<summary>
		/// The encoding of the payloads received and published messages. Set to "" to disable decoding of incoming payload.
		/// , default: utf-8
		///</summary> 
		[JsonProperty("encoding")]
		public string? Encoding { get; set; }

		///<summary>
		/// The category of the entity.
		/// , default: None
		///</summary> 
		[JsonProperty("entity_category")]
		public string? EntityCategory { get; set; }

		///<summary>
		/// List of possible effects.
		///</summary> 
		[JsonProperty("effect_list")]
		public List<string> EffectList { get; set; }

		///<summary>
		/// Template to extract effect from the state payload value.
		///</summary> 
		[JsonProperty("effect_template")]
		public string? EffectTemplate { get; set; }

		///<summary>
		/// Template to extract green color from the state payload value. Expected result of the template is an integer from 0-255 range.
		///</summary> 
		[JsonProperty("green_template")]
		public string? GreenTemplate { get; set; }

		///<summary>
		/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic. Usage example can be found in MQTT sensor documentation.
		///</summary> 
		[JsonProperty("json_attributes_template")]
		public string? JsonAttributesTemplate { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Usage example can be found in MQTT sensor documentation.
		///</summary> 
		[JsonProperty("json_attributes_topic")]
		public string? JsonAttributesTopic { get; set; }

		///<summary>
		/// The maximum color temperature in mireds.
		///</summary> 
		[JsonProperty("max_mireds")]
		public long? MaxMireds { get; set; }

		///<summary>
		/// The minimum color temperature in mireds.
		///</summary> 
		[JsonProperty("min_mireds")]
		public long? MinMireds { get; set; }

		///<summary>
		/// Used instead of name for automatic generation of entity_id
		///</summary> 
		[JsonProperty("object_id")]
		public string? ObjectId { get; set; }

		///<summary>
		/// Flag that defines if the light works in optimistic mode.
		/// Default: 
		///
		///true if no state topic or state template is defined, else false.
		///</summary> 
		[JsonProperty("optimistic")]
		public bool? Optimistic { get; set; }

		///<summary>
		/// The payload that represents the available state.
		/// , default: online
		///</summary> 
		[JsonProperty("payload_available")]
		public string? PayloadAvailable { get; set; }

		///<summary>
		/// The payload that represents the unavailable state.
		/// , default: offline
		///</summary> 
		[JsonProperty("payload_not_available")]
		public string? PayloadNotAvailable { get; set; }

		///<summary>
		/// The maximum QoS level of the state topic.
		/// , default: 0
		///</summary> 
		[JsonProperty("qos")]
		public long? Qos { get; set; }

		///<summary>
		/// Template to extract red color from the state payload value. Expected result of the template is an integer from 0-255 range.
		///</summary> 
		[JsonProperty("red_template")]
		public string? RedTemplate { get; set; }

		///<summary>
		/// The schema to use. Must be template to select the template schema.
		///</summary> 
		[JsonProperty("schema")]
		public string? Schema { get; } = "template";

		///<summary>
		/// Template to extract state from the state payload value.
		///</summary> 
		[JsonProperty("state_template")]
		public string? StateTemplate { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive state updates.
		///</summary> 
		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }
	}
}
