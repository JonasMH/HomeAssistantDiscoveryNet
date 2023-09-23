using MQTTnet.Client;
using System.ComponentModel.DataAnnotations;

namespace ToMqttNet;

public class MqttConnectionOptions
{
	[Required]
	public string NodeId { get; set; } = null!;


        public MqttClientOptions ClientOptions { get; set; } = new MqttClientOptions { };
}
