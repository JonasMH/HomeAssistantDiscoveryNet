using Newtonsoft.Json;

namespace ToMqttNet
{
	public class MqttSwitchDiscoveryConfig : MqttDiscoveryConfig<MqttSwitchDiscoveryConfig>
	{
		public override string Component => "switch";

		[JsonProperty("command_topic")]
		public string? CommandTopic { get; set; }

		[JsonProperty("payload_on")]
		public object? PayloadOn { get; set; }

		[JsonProperty("payload_off")]
		public object? PayloadOff { get; set; }


		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		[JsonProperty("state_on")]
		public object? StateOn { get; set; }

		[JsonProperty("state_off")]
		public object? StateOff { get; set; }

		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
