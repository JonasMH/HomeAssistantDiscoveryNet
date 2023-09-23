using System.Text.Json.Serialization;

namespace ToMqttNet;

/// <summary>
/// The mqtt lock platform lets you control your MQTT enabled locks.
/// </summary>
public class MqttLockDiscoveryConfig : MqttDiscoveryConfig
{
	public override string Component => "lock";

	///<summary>
	/// The MQTT topic to publish commands to change the lock state.
	///</summary> 
	[JsonPropertyName("command_topic")]
	public string CommandTopic { get; set; } = null!;

	///<summary>
	/// Flag which defines if the entity should be enabled when first added.
	/// , default: true
	///</summary> 
	[JsonPropertyName("enabled_by_default")]
	public bool? EnabledByDefault { get; set; }

	///<summary>
	/// The encoding of the payloads received and published messages. Set to "" to disable decoding of incoming payload.
	/// , default: utf-8
	///</summary> 
	[JsonPropertyName("encoding")]
	public string? Encoding { get; set; }

	///<summary>
	/// The category of the entity.
	/// , default: None
	///</summary> 
	[JsonPropertyName("entity_category")]
	public string? EntityCategory { get; set; }

	///<summary>
	/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic. Usage example can be found in MQTT sensor documentation.
	///</summary> 
	[JsonPropertyName("json_attributes_template")]
	public string? JsonAttributesTemplate { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Usage example can be found in MQTT sensor documentation.
	///</summary> 
	[JsonPropertyName("json_attributes_topic")]
	public string? JsonAttributesTopic { get; set; }

	///<summary>
	/// Used instead of name for automatic generation of entity_id
	///</summary> 
	[JsonPropertyName("object_id")]
	public string? ObjectId { get; set; }

	///<summary>
	/// Flag that defines if lock works in optimistic mode.
	/// Default: 
	///
	///true if no state_topic defined, else false.
	///</summary> 
	[JsonPropertyName("optimistic")]
	public bool? Optimistic { get; set; }

	///<summary>
	/// The payload that represents the available state.
	/// , default: online
	///</summary> 
	[JsonPropertyName("payload_available")]
	public string? PayloadAvailable { get; set; }

	///<summary>
	/// The payload sent to the lock to lock it.
	/// , default: LOCK
	///</summary> 
	[JsonPropertyName("payload_lock")]
	public string? PayloadLock { get; set; }

	///<summary>
	/// The payload that represents the unavailable state.
	/// , default: offline
	///</summary> 
	[JsonPropertyName("payload_not_available")]
	public string? PayloadNotAvailable { get; set; }

	///<summary>
	/// The payload sent to the lock to unlock it.
	/// , default: UNLOCK
	///</summary> 
	[JsonPropertyName("payload_unlock")]
	public string? PayloadUnlock { get; set; }

	///<summary>
	/// The payload sent to the lock to open it.
	/// , default: OPEN
	///</summary> 
	[JsonPropertyName("payload_open")]
	public string? PayloadOpen { get; set; }

	///<summary>
	/// The maximum QoS level of the state topic.
	/// , default: 0
	///</summary> 
	[JsonPropertyName("qos")]
	public long? Qos { get; set; }

	///<summary>
	/// If the published message should have the retain flag on or not.
	/// , default: false
	///</summary> 
	[JsonPropertyName("retain")]
	public bool? Retain { get; set; }

	///<summary>
	/// The payload sent to by the lock when it’s locked.
	/// , default: LOCKED
	///</summary> 
	[JsonPropertyName("state_locked")]
	public string? StateLocked { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive state updates.
	///</summary> 
	[JsonPropertyName("state_topic")]
	public string? StateTopic { get; set; }

	///<summary>
	/// The payload sent to by the lock when it’s unlocked.
	/// , default: UNLOCKED
	///</summary> 
	[JsonPropertyName("state_unlocked")]
	public string? StateUnlocked { get; set; }

	///<summary>
	/// Defines a template to extract a value from the payload.
	///</summary> 
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; set; }
}
