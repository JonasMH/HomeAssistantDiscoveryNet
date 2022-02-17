using Newtonsoft.Json;

namespace ToMqttNet
{
	/// <summary>
	/// The mqtt lock platform lets you control your MQTT enabled locks.
	/// </summary>
	public class MqttLockDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "lock";

		///<summary>
		/// The MQTT topic to publish commands to change the lock state.
		///</summary> 
		[JsonProperty("command_topic")]
		public string CommandTopic { get; set; }

		///<summary>
		/// Flag which defines if the entity should be enabled when first added.
		/// , default: true
		///</summary> 
		[JsonProperty("enabled_by_default")]
		public bool? EnabledByDefault { get; set; }

		///<summary>
		/// The encoding of the payloads received and published messages. Set to "" to disable decoding of incoming payload.
		/// , default: utf-8
		///</summary> 
		[JsonProperty("encoding")]
		public string? Encoding { get; set; }

		///<summary>
		/// The category of the entity.
		/// , default: None
		///</summary> 
		[JsonProperty("entity_category")]
		public string? EntityCategory { get; set; }

		///<summary>
		/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic. Usage example can be found in MQTT sensor documentation.
		///</summary> 
		[JsonProperty("json_attributes_template")]
		public string? JsonAttributesTemplate { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Usage example can be found in MQTT sensor documentation.
		///</summary> 
		[JsonProperty("json_attributes_topic")]
		public string? JsonAttributesTopic { get; set; }

		///<summary>
		/// Used instead of name for automatic generation of entity_id
		///</summary> 
		[JsonProperty("object_id")]
		public string? ObjectId { get; set; }

		///<summary>
		/// Flag that defines if lock works in optimistic mode.
		/// Default: 
		///
		///true if no state_topic defined, else false.
		///</summary> 
		[JsonProperty("optimistic")]
		public bool? Optimistic { get; set; }

		///<summary>
		/// The payload that represents the available state.
		/// , default: online
		///</summary> 
		[JsonProperty("payload_available")]
		public string? PayloadAvailable { get; set; }

		///<summary>
		/// The payload sent to the lock to lock it.
		/// , default: LOCK
		///</summary> 
		[JsonProperty("payload_lock")]
		public string? PayloadLock { get; set; }

		///<summary>
		/// The payload that represents the unavailable state.
		/// , default: offline
		///</summary> 
		[JsonProperty("payload_not_available")]
		public string? PayloadNotAvailable { get; set; }

		///<summary>
		/// The payload sent to the lock to unlock it.
		/// , default: UNLOCK
		///</summary> 
		[JsonProperty("payload_unlock")]
		public string? PayloadUnlock { get; set; }

		///<summary>
		/// The payload sent to the lock to open it.
		/// , default: OPEN
		///</summary> 
		[JsonProperty("payload_open")]
		public string? PayloadOpen { get; set; }

		///<summary>
		/// The maximum QoS level of the state topic.
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

		///<summary>
		/// The payload sent to by the lock when it’s locked.
		/// , default: LOCKED
		///</summary> 
		[JsonProperty("state_locked")]
		public string? StateLocked { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive state updates.
		///</summary> 
		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		///<summary>
		/// The payload sent to by the lock when it’s unlocked.
		/// , default: UNLOCKED
		///</summary> 
		[JsonProperty("state_unlocked")]
		public string? StateUnlocked { get; set; }

		///<summary>
		/// Defines a template to extract a value from the payload.
		///</summary> 
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }
	}
}
