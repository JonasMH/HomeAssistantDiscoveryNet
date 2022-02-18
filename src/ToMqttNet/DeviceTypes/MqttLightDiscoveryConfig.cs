using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt light platform lets you control your MQTT enabled lights through one of the supported message schemas, default, json or template.
	/// 
	/// This is the default template
	/// </summary>
	public class MqttLightDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "light";

		///<summary>
		/// The MQTT topic to publish commands to change the light’s brightness.
		///</summary> 
		[JsonProperty("brightness_command_topic")]
		public string? BrightnessCommandTopic { get; set; }

		///<summary>
		/// Defines the maximum brightness value (i.e., 100%) of the MQTT device.
		/// , default: 255
		///</summary> 
		[JsonProperty("brightness_scale")]
		public long? BrightnessScale { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive brightness state updates.
		///</summary> 
		[JsonProperty("brightness_state_topic")]
		public string? BrightnessStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the brightness value.
		///</summary> 
		[JsonProperty("brightness_value_template")]
		public string? BrightnessValueTemplate { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive color mode updates. If this is not configured, color_mode will be automatically set according to the last received valid color or color temperature
		///</summary> 
		[JsonProperty("color_mode_state_topic")]
		public string? ColorModeStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the color mode.
		///</summary> 
		[JsonProperty("color_mode_value_template")]
		public string? ColorModeValueTemplate { get; set; }

		///<summary>
		/// Defines a template to compose message which will be sent to color_temp_command_topic. Available variables: value.
		///</summary> 
		[JsonProperty("color_temp_command_template")]
		public string? ColorTempCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the light’s color temperature state. The color temperature command slider has a range of 153 to 500 mireds (micro reciprocal degrees).
		///</summary> 
		[JsonProperty("color_temp_command_topic")]
		public string? ColorTempCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive color temperature state updates.
		///</summary> 
		[JsonProperty("color_temp_state_topic")]
		public string? ColorTempStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the color temperature value.
		///</summary> 
		[JsonProperty("color_temp_value_template")]
		public string? ColorTempValueTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the switch state.
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
		/// The MQTT topic to publish commands to change the light’s effect state.
		///</summary> 
		[JsonProperty("effect_command_topic")]
		public string? EffectCommandTopic { get; set; }

		///<summary>
		/// The list of effects the light supports.
		///</summary> 
		[JsonProperty("effect_list")]
		public List<string>? EffectList { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive effect state updates.
		///</summary> 
		[JsonProperty("effect_state_topic")]
		public string? EffectStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the effect value.
		///</summary> 
		[JsonProperty("effect_value_template")]
		public string? EffectValueTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the light’s color state in HS format (Hue Saturation). Range for Hue: 0° .. 360°, Range of Saturation: 0..100. Note: Brightness is sent separately in the brightness_command_topic.
		///</summary> 
		[JsonProperty("hs_command_topic")]
		public string? HsCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive color state updates in HS format. Note: Brightness is received separately in the brightness_state_topic.
		///</summary> 
		[JsonProperty("hs_state_topic")]
		public string? HsStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the HS value.
		///</summary> 
		[JsonProperty("hs_value_template")]
		public string? HsValueTemplate { get; set; }

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
		/// Defines when on the payload_on is sent. Using last (the default) will send any style (brightness, color, etc) topics first and then a payload_on to the command_topic. Using first will send the payload_on and then any style topics. Using brightness will only send brightness commands instead of the payload_on to turn the light on.
		///</summary> 
		[JsonProperty("on_command_type")]
		public string? OnCommandType { get; set; }

		///<summary>
		/// Flag that defines if switch works in optimistic mode.
		/// Default: 
		///
		///true if no state topic defined, else false.
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
		/// The payload that represents disabled state.
		/// , default: OFF
		///</summary> 
		[JsonProperty("payload_off")]
		public string? PayloadOff { get; set; }

		///<summary>
		/// The payload that represents enabled state.
		/// , default: ON
		///</summary> 
		[JsonProperty("payload_on")]
		public string? PayloadOn { get; set; }

		///<summary>
		/// The maximum QoS level of the state topic.
		/// , default: 0
		///</summary> 
		[JsonProperty("qos")]
		public long? Qos { get; set; }

		///<summary>
		/// If the published message should have the retain flag on or not.
		/// , default: false
		///</summary> 
		[JsonProperty("retain")]
		public bool? Retain { get; set; }

		///<summary>
		/// Defines a template to compose message which will be sent to rgb_command_topic. Available variables: red, green and blue.
		///</summary> 
		[JsonProperty("rgb_command_template")]
		public string? RgbCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the light’s RGB state. Please note that the color value sent by Home Assistant is normalized to full brightness if brightness_command_topic is set. Brightness information is in this case sent separately in the brightness_command_topic. This will cause a light that expects an absolute color value (including brightness) to flicker.
		///</summary> 
		[JsonProperty("rgb_command_topic")]
		public string? RgbCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive RGB state updates. The expected payload is the RGB values separated by commas, for example, 255,0,127. Please note that the color value received by Home Assistant is normalized to full brightness. Brightness information is received separately in the brightness_state_topic.
		///</summary> 
		[JsonProperty("rgb_state_topic")]
		public string? RgbStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the RGB value.
		///</summary> 
		[JsonProperty("rgb_value_template")]
		public string? RgbValueTemplate { get; set; }

		///<summary>
		/// The schema to use. Must be default or omitted to select the default schema.
		/// , default: default
		///</summary> 
		[JsonProperty("schema")]
		public string? Schema { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive state updates.
		///</summary> 
		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the state value. The template should match the payload on and off values, so if your light uses power on to turn on, your state_value_template string should return power on when the switch is on. For example if the message is just on, your state_value_template should be power .
		///</summary> 
		[JsonProperty("state_value_template")]
		public string? StateValueTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the light to white mode with a given brightness.
		///</summary> 
		[JsonProperty("white_command_topic")]
		public string? WhiteCommandTopic { get; set; }

		///<summary>
		/// Defines the maximum white level (i.e., 100%) of the MQTT device.
		/// , default: 255
		///</summary> 
		[JsonProperty("white_scale")]
		public long? WhiteScale { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the light’s XY state.
		///</summary> 
		[JsonProperty("xy_command_topic")]
		public string? XyCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive XY state updates.
		///</summary> 
		[JsonProperty("xy_state_topic")]
		public string? XyStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the XY value.
		///</summary> 
		[JsonProperty("xy_value_template")]
		public string? XyValueTemplate { get; set; }
	}
}
