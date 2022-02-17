using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt scene platform lets you control your MQTT enabled scenes.
	/// </summary>
	public class MqttSceneDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "scene";

		///<summary>
		/// The MQTT topic to publish commands to change the scene state.
		///</summary> 
		[JsonProperty("command_topic")]
		public string? CommandTopic { get; set; }

		///<summary>
		/// Flag which defines if the entity should be enabled when first added.
		/// , default: true
		///</summary> 
		[JsonProperty("enabled_by_default")]
		public bool? EnabledByDefault { get; set; }

		///<summary>
		/// The category of the entity.
		/// , default: None
		///</summary> 
		[JsonProperty("entity_category")]
		public string? EntityCategory { get; set; }

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
		/// The payload that represents the unavailable state.
		/// , default: offline
		///</summary> 
		[JsonProperty("payload_not_available")]
		public string? PayloadNotAvailable { get; set; }

		///<summary>
		/// The payload that represents on state. If specified, will be used for both comparing to the value in the state_topic (see value_template and state_on for details) and sending as on command to the command_topic.
		/// , default: ON
		///</summary> 
		[JsonProperty("payload_on")]
		public string? PayloadOn { get; set; }

		///<summary>
		/// The maximum QoS level of the state topic. Default is 0 and will also be used to publishing messages.
		/// , default: 0
		///</summary> 
		[JsonProperty("qos")]
		public long? Qos { get; set; }

		///<summary>
		/// If the published message should have the retain flag on or not.
		/// , default: false
		///</summary> 
		[JsonProperty("retain")]
		public bool? Retain { get; set; }
	}
}
