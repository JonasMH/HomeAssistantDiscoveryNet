using System.Text.Json.Serialization;

namespace ToMqttNet;

    public class MqttEventDiscoveryConfig : MqttDiscoveryConfig
    {
        public override string Component => "event";

        ///<summary>
        /// The type/class of the event to set the icon in the frontend. The device_class can be null.
        /// , default: None
        ///</summary> 
        [JsonPropertyName("device_class")]
        public string? DeviceClass { get; set; }

        ///<summary>
        /// Flag which defines if the entity should be enabled when first added.
        /// , default: true
        ///</summary> 
        [JsonPropertyName("enabled_by_default")]
        public bool? EnabledByDefault { get; set; }

        ///<summary>
        /// The encoding of the published messages.
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
        /// A list of valid event_type strings.
        ///</summary> 
        [JsonPropertyName("event_types")]
        public List<string> EventTypes { get; set; }


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
        /// The payload that represents the available state.
        /// , default: online
        ///</summary> 
        [JsonPropertyName("payload_available")]
        public string? PayloadAvailable { get; set; }

        ///<summary>
        /// The payload that represents the unavailable state.
        /// , default: offline
        ///</summary> 
        [JsonPropertyName("payload_not_available")]
        public string? PayloadNotAvailable { get; set; }

        ///<summary>
        /// The maximum QoS level to be used when receiving and publishing messages.
        /// , default: 0
        ///</summary> 
        [JsonPropertyName("qos")]
        public long? Qos { get; set; }

        ///<summary>
        /// The MQTT topic subscribed to receive JSON event payloads. The JSON payload should contain the event_type element. The event type should be one of the configured event_types.
        /// , default: None
        ///</summary> 
        [JsonPropertyName("state_topic")]
        public string StateTopic { get; set; }

        ///<summary>
        /// Defines a template to extract the value and render it to a valid JSON event payload. If the template throws an error, the current state will be used instead.
        ///</summary> 
        [JsonPropertyName("value_template")]
        public string? ValueTemplate { get; set; }
    }
