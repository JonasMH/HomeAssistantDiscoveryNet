using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt button platform lets you send an MQTT message when the button is pressed in the frontend or the button press service is called. This can be used to expose some service of a remote device, for example reboot.
	/// </summary>
	public class MqttButtonDiscoveryConfig : MqttDiscoveryConfig<MqttButtonDiscoveryConfig>
	{
		public override string Component => "button";

		/// <summary>
		/// The MQTT topic to publish commands to trigger the button.
		/// </summary>
		[JsonProperty("command_topic")]
		public string? CommandTopic { get; set; }

		/// <summary>
		/// Defines a template to generate the payload to send to command_topic.
		/// </summary>
		[JsonProperty("command_template")]
		public string? CommandTemplate { get; set; }

		/// <summary>
		/// The payload To send to trigger the button.
		/// </summary>
		[JsonProperty("payload_press")]
		public string? PayloadPress { get; set; }

	}
}
