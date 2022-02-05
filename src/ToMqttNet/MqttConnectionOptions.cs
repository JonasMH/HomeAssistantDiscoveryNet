using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ToMqttNet
{
	public class MqttConnectionOptions
	{
		[Required]
		public string ClientId { get; set; } = null!;
		[Required]
		public string NodeId { get; set; } = null!;
		public string Server { get; set; } = "mosquitto";
		public int Port { get; set; } = 1883;
	}
}
