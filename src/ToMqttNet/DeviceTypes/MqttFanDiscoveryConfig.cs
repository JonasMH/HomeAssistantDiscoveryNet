using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt fan platform lets you control your MQTT enabled fans.
	/// </summary>
	public class MqttFanDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "fan";

		///<summary>
		/// Defines a template to generate the payload to send to command_topic.
		///</summary> 
		[JsonProperty("command_template")]
		public string? CommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the fan state.
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
		/// Flag that defines if fan works in optimistic mode
		/// Default: 
		///
		///true if no state topic defined, else false.
		///</summary> 
		[JsonProperty("optimistic")]
		public bool? Optimistic { get; set; }

		///<summary>
		/// Defines a template to generate the payload to send to oscillation_command_topic.
		///</summary> 
		[JsonProperty("oscillation_command_template")]
		public string? OscillationCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the oscillation state.
		///</summary> 
		[JsonProperty("oscillation_command_topic")]
		public string? OscillationCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive oscillation state updates.
		///</summary> 
		[JsonProperty("oscillation_state_topic")]
		public string? OscillationStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract a value from the oscillation.
		///</summary> 
		[JsonProperty("oscillation_value_template")]
		public string? OscillationValueTemplate { get; set; }

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
		/// The payload that represents the oscillation off state.
		/// , default: oscillate_off
		///</summary> 
		[JsonProperty("payload_oscillation_off")]
		public string? PayloadOscillationOff { get; set; }

		///<summary>
		/// The payload that represents the oscillation on state.
		/// , default: oscillate_on
		///</summary> 
		[JsonProperty("payload_oscillation_on")]
		public string? PayloadOscillationOn { get; set; }

		///<summary>
		/// A special payload that resets the percentage state attribute to None when received at the percentage_state_topic.
		/// , default: None
		///</summary> 
		[JsonProperty("payload_reset_percentage")]
		public string? PayloadResetPercentage { get; set; }

		///<summary>
		/// A special payload that resets the preset_mode state attribute to None when received at the preset_mode_state_topic.
		/// , default: None
		///</summary> 
		[JsonProperty("payload_reset_preset_mode")]
		public string? PayloadResetPresetMode { get; set; }

		///<summary>
		/// Defines a template to generate the payload to send to percentage_command_topic.
		///</summary> 
		[JsonProperty("percentage_command_template")]
		public string? PercentageCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the fan speed state based on a percentage.
		///</summary> 
		[JsonProperty("percentage_command_topic")]
		public string? PercentageCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive fan speed based on percentage.
		///</summary> 
		[JsonProperty("percentage_state_topic")]
		public string? PercentageStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the percentage value from the payload received on percentage_state_topic.
		///</summary> 
		[JsonProperty("percentage_value_template")]
		public string? PercentageValueTemplate { get; set; }

		///<summary>
		/// Defines a template to generate the payload to send to preset_mode_command_topic.
		///</summary> 
		[JsonProperty("preset_mode_command_template")]
		public string? PresetModeCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the preset mode.
		///</summary> 
		[JsonProperty("preset_mode_command_topic")]
		public string? PresetModeCommandTopic { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive fan speed based on presets.
		///</summary> 
		[JsonProperty("preset_mode_state_topic")]
		public string? PresetModeStateTopic { get; set; }

		///<summary>
		/// Defines a template to extract the preset_mode value from the payload received on preset_mode_state_topic.
		///</summary> 
		[JsonProperty("preset_mode_value_template")]
		public string? PresetModeValueTemplate { get; set; }

		///<summary>
		/// List of preset modes this fan is capable of running at. Common examples include auto, smart, whoosh, eco and breeze.
		/// , default: []
		///</summary> 
		[JsonProperty("preset_modes")]
		public List<string>? PresetModes { get; set; }

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
		/// The maximum of numeric output range (representing 100 %). The number of speeds within the speed_range / 100 will determine the percentage_step.
		/// , default: 100
		///</summary> 
		[JsonProperty("speed_range_max")]
		public long? SpeedRangeMax { get; set; }

		///<summary>
		/// The minimum of numeric output range (off not included, so speed_range_min - 1 represents 0 %). The number of speeds within the speed_range / 100 will determine the percentage_step.
		/// , default: 1
		///</summary> 
		[JsonProperty("speed_range_min")]
		public long? SpeedRangeMin { get; set; }

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
