using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt binary sensor platform uses an MQTT message received to set the binary sensor’s state to on or off.
	/// </summary>
	public class MqttBinarySensorDiscoveryConfig : MqttDiscoveryConfig<MqttSelectDiscoveryConfig>
	{
		public override string Component => "binary_sensor";

		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		/// <summary>
		/// Defines a template that returns a string to be compared to <c>payload_on</c>/<c>payload_off</c> or an empty string, in which case the MQTT message will be removed. Available variables: entity_id. Remove this option when ‘payload_on’ and ‘payload_off’ are sufficient to match your payloads (i.e no pre-processing of original message is required).
		/// </summary>
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }

		/// <summary>
		/// The string that represents the off state. It will be compared to the message in the state_topic (see value_template for details)
		/// </summary>
		[JsonProperty("payload_off")]
		public string? PayloadOff { get; set; }

		/// <summary>
		/// The string that represents the on state. It will be compared to the message in the state_topic (see value_template for details)
		/// </summary>
		[JsonProperty("payload_on")]
		public string? PayloadOn { get; set; }

		/// <summary>
		/// Sets the <see href="https://www.home-assistant.io/integrations/binary_sensor/#device-class">class of the device</see>, changing the device state and icon that is displayed on the frontend.
		/// </summary>
		[JsonProperty("device_class")]
		public string? DeviceClass { get; set; }
	}
}
