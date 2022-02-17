using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt climate platform lets you control your MQTT enabled HVAC devices.
	/// </summary>
	public class MqttClimateDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "climate";

		///<summary>
		/// A template to render the value received on the action_topic with.
		///</summary> 
		[JsonProperty("action_template")]
		public string? ActionTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes of the current action. If this is set, the climate graph uses the value received as data source. Valid values: off, heating, cooling, drying, idle, fan.
		///</summary> 
		[JsonProperty("action_topic")]
		public string? ActionTopic { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to switch auxiliary heat.
		///</summary> 
		[JsonProperty("aux_command_topic")]
		public string? AuxCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the aux_state_topic with.
		///</summary> 
		[JsonProperty("aux_state_template")]
		public string? AuxStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes of the auxiliary heat mode. If this is not set, the auxiliary heat mode works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("aux_state_topic")]
		public string? AuxStateTopic { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the away mode.
		///</summary> 
		[JsonProperty("away_mode_command_topic")]
		public string? AwayModeCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the away_mode_state_topic with.
		///</summary> 
		[JsonProperty("away_mode_state_template")]
		public string? AwayModeStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes of the HVAC away mode. If this is not set, the away mode works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("away_mode_state_topic")]
		public string? AwayModeStateTopic { get; set; }

		///<summary>
		/// A template with which the value received on current_temperature_topic will be rendered.
		///</summary> 
		[JsonProperty("current_temperature_template")]
		public string? CurrentTemperatureTemplate { get; set; }

		///<summary>
		/// The MQTT topic on which to listen for the current temperature.
		///</summary> 
		[JsonProperty("current_temperature_topic")]
		public string? CurrentTemperatureTopic { get; set; }

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
		/// A template to render the value sent to the fan_mode_command_topic with.
		///</summary> 
		[JsonProperty("fan_mode_command_template")]
		public string? FanModeCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the fan mode.
		///</summary> 
		[JsonProperty("fan_mode_command_topic")]
		public string? FanModeCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the fan_mode_state_topic with.
		///</summary> 
		[JsonProperty("fan_mode_state_template")]
		public string? FanModeStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes of the HVAC fan mode. If this is not set, the fan mode works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("fan_mode_state_topic")]
		public string? FanModeStateTopic { get; set; }

		///<summary>
		/// A list of supported fan modes.
		/// Default: 
		///
		///[“auto”, “low”, “medium”, “high”]
		///</summary> 
		[JsonProperty("fan_modes")]
		public List<string>? FanModes { get; set; }

		///<summary>
		/// A template to render the value sent to the hold_command_topic with.
		///</summary> 
		[JsonProperty("hold_command_template")]
		public string? HoldCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the hold mode.
		///</summary> 
		[JsonProperty("hold_command_topic")]
		public string? HoldCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the hold_state_topic with.
		///</summary> 
		[JsonProperty("hold_state_template")]
		public string? HoldStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes of the HVAC hold mode. If this is not set, the hold mode works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("hold_state_topic")]
		public string? HoldStateTopic { get; set; }

		///<summary>
		/// A list of available hold modes.
		///</summary> 
		[JsonProperty("hold_modes")]
		public List<string>? HoldModes { get; set; }

		///<summary>
		/// Set the initial target temperature.
		/// , default: 21
		///</summary> 
		[JsonProperty("initial")]
		public long? Initial { get; set; }


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
		/// Maximum set point available.
		///</summary> 
		[JsonProperty("max_temp")]
		public double? MaxTemp { get; set; }

		///<summary>
		/// Minimum set point available.
		///</summary> 
		[JsonProperty("min_temp")]
		public double? MinTemp { get; set; }

		///<summary>
		/// A template to render the value sent to the mode_command_topic with.
		///</summary> 
		[JsonProperty("mode_command_template")]
		public string? ModeCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the HVAC operation mode.
		///</summary> 
		[JsonProperty("mode_command_topic")]
		public string? ModeCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the mode_state_topic with.
		///</summary> 
		[JsonProperty("mode_state_template")]
		public string? ModeStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes of the HVAC operation mode. If this is not set, the operation mode works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("mode_state_topic")]
		public string? ModeStateTopic { get; set; }

		///<summary>
		/// A list of supported modes. Needs to be a subset of the default values.
		/// Default: 
		///
		///[“auto”, “off”, “cool”, “heat”, “dry”, “fan_only”]
		///</summary> 
		[JsonProperty("modes")]
		public List<string>? Modes { get; set; }

		///<summary>
		/// Used instead of name for automatic generation of entity_id
		///</summary> 
		[JsonProperty("object_id")]
		public string? ObjectId { get; set; }

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
		/// The MQTT topic to publish commands to change the power state. This is useful if your device has a separate power toggle in addition to mode.
		///</summary> 
		[JsonProperty("power_command_topic")]
		public string? PowerCommandTopic { get; set; }

		///<summary>
		/// The desired precision for this device. Can be used to match your actual thermostat’s precision. Supported values are 0.1, 0.5 and 1.0.
		/// Default: 
		///
		///0.1 for Celsius and 1.0 for Fahrenheit.
		///</summary> 
		[JsonProperty("precision")]
		public double? Precision { get; set; }

		///<summary>
		/// The maximum QoS level to be used when receiving and publishing messages.
		/// , default: 0
		///</summary> 
		[JsonProperty("qos")]
		public long? Qos { get; set; }

		///<summary>
		/// Defines if published messages should have the retain flag set.
		/// , default: false
		///</summary> 
		[JsonProperty("retain")]
		public bool? Retain { get; set; }

		///<summary>
		/// Set to false to suppress sending of all MQTT messages when the current mode is Off.
		/// , default: true
		///</summary> 
		[JsonProperty("send_if_off")]
		public bool? SendIfOff { get; set; }

		///<summary>
		/// A template to render the value sent to the swing_mode_command_topic with.
		///</summary> 
		[JsonProperty("swing_mode_command_template")]
		public string? SwingModeCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the swing mode.
		///</summary> 
		[JsonProperty("swing_mode_command_topic")]
		public string? SwingModeCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the swing_mode_state_topic with.
		///</summary> 
		[JsonProperty("swing_mode_state_template")]
		public string? SwingModeStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes of the HVAC swing mode. If this is not set, the swing mode works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("swing_mode_state_topic")]
		public string? SwingModeStateTopic { get; set; }

		///<summary>
		/// A list of supported swing modes.
		/// , default: [“on”, “off”]
		///</summary> 
		[JsonProperty("swing_modes")]
		public List<string>? SwingModes { get; set; }

		///<summary>
		/// A template to render the value sent to the temperature_command_topic with.
		///</summary> 
		[JsonProperty("temperature_command_template")]
		public string? TemperatureCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the target temperature.
		///</summary> 
		[JsonProperty("temperature_command_topic")]
		public string? TemperatureCommandTopic { get; set; }

		///<summary>
		/// A template to render the value sent to the temperature_high_command_topic with.
		///</summary> 
		[JsonProperty("temperature_high_command_template")]
		public string? TemperatureHighCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the high target temperature.
		///</summary> 
		[JsonProperty("temperature_high_command_topic")]
		public string? TemperatureHighCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the temperature_high_state_topic with.
		///</summary> 
		[JsonProperty("temperature_high_state_template")]
		public string? TemperatureHighStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes in the target high temperature. If this is not set, the target high temperature works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("temperature_high_state_topic")]
		public string? TemperatureHighStateTopic { get; set; }

		///<summary>
		/// A template to render the value sent to the temperature_low_command_topic with.
		///</summary> 
		[JsonProperty("temperature_low_command_template")]
		public string? TemperatureLowCommandTemplate { get; set; }

		///<summary>
		/// The MQTT topic to publish commands to change the target low temperature.
		///</summary> 
		[JsonProperty("temperature_low_command_topic")]
		public string? TemperatureLowCommandTopic { get; set; }

		///<summary>
		/// A template to render the value received on the temperature_low_state_topic with.
		///</summary> 
		[JsonProperty("temperature_low_state_template")]
		public string? TemperatureLowStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes in the target low temperature. If this is not set, the target low temperature works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("temperature_low_state_topic")]
		public string? TemperatureLowStateTopic { get; set; }

		///<summary>
		/// A template to render the value received on the temperature_state_topic with.
		///</summary> 
		[JsonProperty("temperature_state_template")]
		public string? TemperatureStateTemplate { get; set; }

		///<summary>
		/// The MQTT topic to subscribe for changes in the target temperature. If this is not set, the target temperature works in optimistic mode (see below).
		///</summary> 
		[JsonProperty("temperature_state_topic")]
		public string? TemperatureStateTopic { get; set; }

		///<summary>
		/// Defines the temperature unit of the device, C or F. If this is not set, the temperature unit is set to the system temperature unit.
		///</summary> 
		[JsonProperty("temperature_unit")]
		public string? TemperatureUnit { get; set; }

		///<summary>
		/// Step size for temperature set point.
		/// , default: 1
		///</summary> 
		[JsonProperty("temp_step")]
		public double? TempStep { get; set; }

		///<summary>
		/// Default template to render the payloads on all *_state_topics with.
		///</summary> 
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
