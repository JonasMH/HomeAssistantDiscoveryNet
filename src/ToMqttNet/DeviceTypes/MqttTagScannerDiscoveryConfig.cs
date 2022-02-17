using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt tag scanner platform uses an MQTT message payload to generate tag scanned events.
	/// </summary>
	public class MqttTagScannerDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "tag";


		///<summary>
		/// The MQTT topic subscribed to receive tag scanned events.
		///</summary> 
		[JsonProperty("topic")]
		public string Topic { get; set; }

		///<summary>
		/// Defines a template that returns a tag ID.
		///</summary> 
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
