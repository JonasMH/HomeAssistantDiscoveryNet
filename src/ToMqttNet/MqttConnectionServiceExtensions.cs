using MQTTnet;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ToMqttNet
{
	public static class MqttDiscoveryConfigExtensions
	{
		public static JsonSerializerSettings DiscoveryJsonSettings { get; } = new JsonSerializerSettings
		{
			ContractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy(),
			},
			Formatting = Formatting.None,
			NullValueHandling = NullValueHandling.Ignore,
		};
		public static string ToJson<T>(this T config) where T : MqttDiscoveryConfig
		{
			return JsonConvert.SerializeObject(config, DiscoveryJsonSettings);
		}
	}

	public static class MqttConnectionServiceExtensions
	{
		public static Task PublishDiscoveryDocument<T>(this IMqttConnectionService connection, T config) where T : MqttDiscoveryConfig
		{
			return connection.PublishAsync(
				new MqttApplicationMessageBuilder()
					.WithTopic($"homeassistant/{config.Component}/{connection.MqttOptions.NodeId}/{config.UniqueId}/config")
					.WithRetainFlag()
					.WithPayload(config.ToJson())
					.Build());
		}
	}
}
