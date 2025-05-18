using System.Text.Json.Serialization;

namespace HomeAssistantDiscoveryNet;

public class MqttDeviceDiscoveryConfig
{
    [JsonPropertyName("device")]
    public required MqttDiscoveryDevice Device { get; set; }
    
    [JsonPropertyName("origin")]
    public required MqttDiscoveryConfigOrigin Origin { get; set; }
    
    [JsonPropertyName("components")]
    public Dictionary<string, object> Components { get; } = new Dictionary<string, object>();

    public void AddComponent<T>(string key, T component) where T : MqttDiscoveryConfig => Components.Add(key, component);

    [JsonPropertyName("state_topic")]
    public required string StateTopic { get; set; }
}