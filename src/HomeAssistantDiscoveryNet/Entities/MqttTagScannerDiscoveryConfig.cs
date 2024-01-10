using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

/// <summary>
/// The mqtt tag scanner platform uses an MQTT message payload to generate tag scanned events.
/// </summary>
public class MqttTagScannerDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "tag";


	///<summary>
	/// The MQTT topic subscribed to receive tag scanned events.
	///</summary> 
	[JsonPropertyName("topic")]
	public string Topic { get; set; } = null!;

	///<summary>
	/// Defines a template that returns a tag ID.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
