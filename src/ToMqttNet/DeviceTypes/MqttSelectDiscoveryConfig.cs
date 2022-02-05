using Newtonsoft.Json;

namespace ToMqttNet
{
	public class MqttSelectDiscoveryConfig : MqttDiscoveryConfig<MqttSelectDiscoveryConfig>
	{
		public override string Component => "select";

		[JsonProperty("command_topic")]
		public string? CommandTopic { get; set; }


		[JsonProperty("options")]
		public List<string> Options { get; set; } = new List<string>();

	}
}
