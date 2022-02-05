using Newtonsoft.Json;

namespace ToMqttNet
{
	public class MqttBinarySensorDiscoveryConfig : MqttDiscoveryConfig<MqttSelectDiscoveryConfig>
	{
		public override string Component => "binary_sensor";

		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
