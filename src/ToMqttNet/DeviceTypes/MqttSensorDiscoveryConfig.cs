using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ToMqttNet
{
	/// <summary>
	/// This mqtt sensor platform uses the MQTT message payload as the sensor value. If messages in this state_topic are published with RETAIN flag, the sensor will receive an instant update with last known value. Otherwise, the initial state will be undefined.
	/// </summary>
	public class MqttSensorDiscoveryConfig : MqttDiscoveryConfig
	{
		public override string Component => "sensor";

		///<summary>
		/// The type/class of the sensor to set the icon in the frontend.
		/// , default: None
		///</summary> 
		[JsonProperty("device_class")]
		public string? DeviceClass { get; set; }

		///<summary>
		/// Flag which defines if the entity should be enabled when first added.
		/// , default: true
		///</summary> 
		[JsonProperty("enabled_by_default")]
		public bool? EnabledByDefault { get; set; }

		///<summary>
		/// The encoding of the payloads received. Set to "" to disable decoding of incoming payload.
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
		/// Defines the number of seconds after the sensor’s state expires, if it’s not updated. After expiry, the sensor’s state becomes unavailable.
		/// , default: 0
		///</summary> 
		[JsonProperty("expire_after")]
		public long? ExpireAfter { get; set; }

		///<summary>
		/// Sends update events even if the value hasn’t changed. Useful if you want to have meaningful value graphs in history.
		/// , default: false
		///</summary> 
		[JsonProperty("force_update")]
		public bool? ForceUpdate { get; set; }

		///<summary>
		/// Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic.
		///</summary> 
		[JsonProperty("json_attributes_template")]
		public string? JsonAttributesTemplate { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Implies force_update of the current sensor state when a message is received on this topic.
		///</summary> 
		[JsonProperty("json_attributes_topic")]
		public string? JsonAttributesTopic { get; set; }

		///<summary>
		/// Defines a template to extract the last_reset. Available variables: entity_id. The entity_id can be used to reference the entity’s attributes.
		///</summary> 
		[JsonProperty("last_reset_value_template")]
		public string? LastResetValueTemplate { get; set; }

		///<summary>
		/// Last rest
		///</summary> 
		[JsonProperty("last_reset")]
		public string? LastReset { get; set; }

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
		/// The maximum QoS level of the state topic.
		/// , default: 0
		///</summary> 
		[JsonProperty("qos")]
		public long? Qos { get; set; }

		///<summary>
		/// The state_class of the sensor.
		/// , default: None
		///</summary> 
		[JsonProperty("state_class")]
		[JsonConverter(typeof(StringEnumConverter))]
		public MqttDiscoveryStateClass? StateClass { get; set; }

		///<summary>
		/// The MQTT topic subscribed to receive sensor values.
		///</summary> 
		[JsonProperty("state_topic")]
		public string StateTopic { get; set; }

		///<summary>
		/// Defines the units of measurement of the sensor, if any.
		///</summary> 
		[JsonProperty("unit_of_measurement")]
		public string? UnitOfMeasurement { get; set; }

		///<summary>
		/// Defines a template to extract the value. Available variables: entity_id. The entity_id can be used to reference the entity’s attributes. If the template throws an error, the current state will be used instead.
		///</summary> 
		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }

	}
}
