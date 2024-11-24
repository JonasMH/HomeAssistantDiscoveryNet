using System.ComponentModel.DataAnnotations;
using HomeAssistantDiscoveryNet;

namespace ToMqttNet;

public class MqttConnectionOptions
{
    public const string Section = "MqttConnection";

    public int? Port { get; set; }
    public bool UseTls { get; set; }
    [Required]
    public string NodeId { get; set; } = null!;
    public string? Server { get; set; }
    public string? CaCrt { get; set; }
    public string? ClientCrt { get; set; }
    public string? ClientKey { get; set; }

    public MqttDiscoveryConfigOrigin? OriginConfig { get; set; }
}
