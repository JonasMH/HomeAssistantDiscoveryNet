using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt humidifier platform lets you control your MQTT enabled humidifiers.
	/// </summary>
	public class MqttHumidifierDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "humidifier";

		///<summary>
		/// Defines a template to generate the payload to send to command_topic.
		///</summary> 
		[JsonProperty("command_template")]
		public string? CommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the humidifier state.
		///</summary> 
		[JsonProperty("command_topic")]
		public string CommandTopic { get; set; }

		///<summary>
		/// The device class of the MQTT device. Must be either humidifier or dehumidifier.
		/// , default: humidifier
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
		/// The minimum target humidity percentage that can be set.
		/// , default: 100
		///</summary> 
		[JsonProperty("max_humidity")]
		public long? MaxHumidity { get; set; }

		///<summary>
		/// The maximum target humidity percentage that can be set.
		/// , default: 0
		///</summary> 
		[JsonProperty("min_humidity")]
		public long? MinHumidity { get; set; }

		///<summary>
		/// Used instead of name for automatic generation of entity_id
		///</summary> 
		[JsonProperty("object_id")]
		public string? ObjectId { get; set; }

		///<summary>
		/// Flag that defines if humidifier works in optimistic mode
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
		/// The payload that represents the stop state.
		/// , default: OFF
		///</summary> 
		[JsonProperty("payload_off")]
		public string? PayloadOff { get; set; }

		///<summary>
		/// The payload that represents the running state.
		/// , default: ON
		///</summary> 
		[JsonProperty("payload_on")]
		public string? PayloadOn { get; set; }

		///<summary>
		/// A special payload that resets the target_humidity state attribute to None when received at the target_humidity_state_topic.
		/// , default: None
		///</summary> 
		[JsonProperty("payload_reset_humidity")]
		public string? PayloadResetHumidity { get; set; }

		///<summary>
		/// A special payload that resets the mode state attribute to None when received at the mode_state_topic.
		/// , default: None
		///</summary> 
		[JsonProperty("payload_reset_mode")]
		public string? PayloadResetMode { get; set; }

		///<summary>
		/// Defines a template to generate the payload to send to target_humidity_command_topic.
		///</summary> 
		[JsonProperty("target_humidity_command_template")]
		public string? TargetHumidityCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the humidifier target humidity state based on a percentage.
		///</summary> 
		[JsonProperty("target_humidity_command_topic")]
		public string TargetHumidityCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive humidifier target humidity.
		///</summary> 
		[JsonProperty("target_humidity_state_topic")]
		public string? TargetHumidityStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract a value for the humidifier target_humidity state.
		///</summary> 
		[JsonProperty("target_humidity_state_template")]
		public string? TargetHumidityStateTemplate { get; set; }

		///<summary>
		/// Defines a template to generate the payload to send to mode_command_topic.
		///</summary> 
		[JsonProperty("mode_command_template")]
		public string? ModeCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the mode on the humidifier. This attribute ust be configured together with the modes attribute.
		///</summary> 
		[JsonProperty("mode_command_topic")]
		public string? ModeCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive the humidifier mode.
		///</summary> 
		[JsonProperty("mode_state_topic")]
		public string? ModeStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract a value for the humidifier mode state.
		///</summary> 
		[JsonProperty("mode_state_template")]
		public string? ModeStateTemplate { get; set; }

		///<summary>
		/// List of available modes this humidifier is capable of running at. Common examples include normal, eco, away, boost, comfort, home, sleep, auto and baby. These examples offer built-in translations but other custom modes are allowed as well. This attribute ust be configured together with the mode_command_topic attribute.
		/// , default: []
		///</summary> 
		[JsonProperty("modes")]
		public List<string>? Modes { get; set; }

		///<summary>
		/// The maximum QoS level of the state topic.
		/// , default: 0
		///</summary> 
		[JsonProperty("qos")]
		public long? Qos { get; set; }

		///<summary>
		/// If the published message should have the retain flag on or not.
		/// , default: true
		///</summary> 
		[JsonProperty("retain")]
		public bool? Retain { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive state updates.
		///</summary> 
		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		///<summary>
		/// Defines a template to extract a value from the state.
		///</summary> 
		[JsonProperty("state_value_template")]
		public string? StateValueTemplate { get; set; }
	}
}
