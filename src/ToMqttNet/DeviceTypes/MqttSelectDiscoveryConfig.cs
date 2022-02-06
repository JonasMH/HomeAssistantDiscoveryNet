using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt Select platform allows you to integrate devices that might expose configuration options through MQTT into Home Assistant as a Select. Every time a message under the topic in the configuration is received, the select entity will be updated in Home Assistant and vice-versa, keeping the device and Home Assistant in sync.
	/// </summary>
	public class MqttSelectDiscoveryConfig : MqttDiscoveryConfig<MqttSelectDiscoveryConfig>
	{
		public override string Component => "select";

		[JsonProperty("command_topic")]
		public string? CommandTopic { get; set; }


		[JsonProperty("options")]
		public List<string> Options { get; set; } = new List<string>();

	}
}
