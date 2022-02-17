using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt switch platform lets you control your MQTT enabled switches.
	/// </summary>
	public class MqttSwitchDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "switch";

		///<summary>
		/// The MQTT topic to publish commands to change the switch state.
		///</summary> 
		[JsonProperty("command_topic")]
		public string? CommandTopic { get; set; }

		///<summary>
		/// The type/class of the switch to set the icon in the frontend.
		/// , default: None
		///</summary> 
		[JsonProperty("device_class")]
		public string? DeviceClass { get; set; }

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
		/// Used instead of name for automatic generation of entity_id
		///</summary> 
		[JsonProperty("object_id")]
		public string? ObjectId { get; set; }

		///<summary>
		/// Flag that defines if switch works in optimistic mode.
		/// Default: 
		///
		///true if no state_topic defined, else false.
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
		/// The payload that represents off state. If specified, will be used for both comparing to the value in the state_topic (see value_template and state_off for details) and sending as off command to the command_topic.
		/// , default: OFF
		///</summary> 
		[JsonProperty("payload_off")]
		public string? PayloadOff { get; set; }

		///<summary>
		/// The payload that represents on state. If specified, will be used for both comparing to the value in the state_topic (see value_template and state_on for details) and sending as on command to the command_topic.
		/// , default: ON
		///</summary> 
		[JsonProperty("payload_on")]
		public string? PayloadOn { get; set; }

		///<summary>
		/// The maximum QoS level of the state topic. Default is 0 and will also be used to publishing messages.
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
		/// The payload that represents the off state. Used when value that represents off state in the state_topic is different from value that should be sent to the command_topic to turn the device off.
		/// Default: 
		///
		///payload_off if defined, else OFF
		///</summary> 
		[JsonProperty("state_off")]
		public string? StateOff { get; set; }

		///<summary>
		/// The payload that represents the on state. Used when value that represents on state in the state_topic is different from value that should be sent to the command_topic to turn the device on.
		/// Default: 
		///
		///payload_on if defined, else ON
		///</summary> 
		[JsonProperty("state_on")]
		public string? StateOn { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive state updates.
		///</summary> 
		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		///<summary>
		/// Defines a template to extract device’s state from the state_topic. To determine the switches’s state result of this template will be compared to state_on and state_off.
		///</summary> 
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
