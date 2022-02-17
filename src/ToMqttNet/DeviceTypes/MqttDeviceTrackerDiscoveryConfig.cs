using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt device tracker platform allows you to define new device_trackers through manual YAML configuration in configuration.yaml and also to automatically discover device_trackers through a discovery schema using the MQTT Discovery protocol.
	/// </summary>
	public class MqttDeviceTrackerDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "device_tracker";

		///<summary>
		/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic. Usage example can be found in MQTT sensor documentation.
		///</summary> 
		[JsonProperty("json_attributes_template")]
		public string? JsonAttributesTemplate { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as device_tracker attributes. Usage example can be found in MQTT sensor documentation.
		///</summary> 
		[JsonProperty("json_attributes_topic")]
		public string? JsonAttributesTopic { get; set; }

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
		/// The payload value that represents the ‘home’ state for the device.
		/// , default: home
		///</summary> 
		[JsonProperty("payload_home")]
		public string? PayloadHome { get; set; }

		///<summary>
		/// The payload that represents the unavailable state.
		/// , default: offline
		///</summary> 
		[JsonProperty("payload_not_available")]
		public string? PayloadNotAvailable { get; set; }

		///<summary>
		/// The payload value that represents the ‘not_home’ state for the device.
		/// , default: not_home
		///</summary> 
		[JsonProperty("payload_not_home")]
		public string? PayloadNotHome { get; set; }

		///<summary>
		/// The maximum QoS level of the state topic.
		/// , default: 0
		///</summary> 
		[JsonProperty("qos")]
		public long? Qos { get; set; }

		///<summary>
		/// Attribute of a device tracker that affects state when being used to track a person. Valid options are gps, router, bluetooth, or bluetooth_le.
		///</summary> 
		[JsonProperty("source_type")]
		public string? SourceType { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive device tracker state changes.
		///</summary> 
		[JsonProperty("state_topic")]
		public string StateTopic { get; set; }

		///<summary>
		/// Defines a template that returns a device tracker state.
		///</summary> 
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
