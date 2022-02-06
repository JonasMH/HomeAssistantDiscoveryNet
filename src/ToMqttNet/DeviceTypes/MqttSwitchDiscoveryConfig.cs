using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt switch platform lets you control your MQTT enabled switches.
	/// </summary>
	public class MqttSwitchDiscoveryConfig : MqttDiscoveryConfig<MqttSwitchDiscoveryConfig>
	{
		public override string Component => "switch";

		/// <summary>
		/// The MQTT topic to publish commands to change the switch state.
		/// </summary>
		[JsonProperty("command_topic")]
		public string? CommandTopic { get; set; }

		/// <summary>
		/// The payload that represents on state. If specified, will be used for both comparing to the value in the state_topic (see value_template and state_on for details) and sending as on command to the command_topic.
		/// </summary>
		[JsonProperty("payload_on")]
		public object? PayloadOn { get; set; }

		/// <summary>
		/// The payload that represents off state. If specified, will be used for both comparing to the value in the state_topic (see value_template and state_off for details) and sending as off command to the command_topic.
		/// </summary>
		[JsonProperty("payload_off")]
		public object? PayloadOff { get; set; }

		/// <summary>
		/// The MQTT topic subscribed to receive state updates.
		/// </summary>
		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		/// <summary>
		/// The payload that represents the on state. Used when value that represents on state in the state_topic is different from value that should be sent to the command_topic to turn the device on.
		/// Default: payload_on if defined, else ON
		/// </summary>
		[JsonProperty("state_on")]
		public object? StateOn { get; set; }

		/// <summary>
		/// The payload that represents the off state. Used when value that represents off state in the state_topic is different from value that should be sent to the command_topic to turn the device off.
		/// Default: payload_off if defined, else OFF
		/// </summary>
		[JsonProperty("state_off")]
		public object? StateOff { get; set; }

		/// <summary>
		/// Defines a template to extract device’s state from the state_topic. To determine the switches’s state result of this template will be compared to state_on and state_off.
		/// </summary>
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
