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
		/// <summary>
		/// If set will be used, even if <see cref="Server"/> is set
		/// </summary>
		public string? BrokerUrl { get; set; }
		/// <summary>
		/// If <see cref="BrokerUrl"/> is set, it will be used instead
		/// </summary>
		public string? Server { get; set; } = "mosquitto";
		public int Port { get; set; } = 1883;
	}
}
