using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

public class MqttNotifyDiscoveryConfig : MqttDiscoveryConfig
{
    public override string Component => "notify";
    
    /// <summary>
    /// The MQTT topic to publish send message commands at.
    /// </summary>
    [JsonPropertyName("command_topic")]
    public string? CommandTopic { get; set; }
    
    ///<summary>
    /// Flag which defines if the entity should be enabled when first added.
    /// , default: true
    ///</summary> 
    [JsonPropertyName("enabled_by_default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? EnabledByDefault { get; set; }
    
    ///<summary>
    /// The encoding of the payloads received and published messages. Set to "" to disable decoding of incoming payload.
    /// , default: utf-8
    ///</summary> 
    [JsonPropertyName("encoding")]
    public string? Encoding { get; set; }
    
    //<summary>
    /// The category of the entity.
    /// , default: None
    ///</summary> 
    [JsonPropertyName("entity_category")]
    public string? EntityCategory { get; set; }
    
    /// <summary>
    /// Picture URL for the entity.
    /// </summary>
    [JsonPropertyName("entity_picture")]
    public string? EntityPicture { get; set; }
    
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
    /// The maximum QoS level of the state topic.
    /// , default: 0
    ///</summary> 
    [JsonPropertyName("qos")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public long? Qos { get; set; }

    ///<summary>
    /// If the published message should have the retain flag on or not.
    /// , default: false
    ///</summary> 
    [JsonPropertyName("retain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Retain { get; set; }
}