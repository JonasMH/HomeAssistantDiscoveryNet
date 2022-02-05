using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ToMqttNet
{
	public class MqttSensorDiscoveryConfig : MqttDiscoveryConfig<MqttSensorDiscoveryConfig>
	{
		public override string Component => "sensor";

		[JsonProperty("state_topic")]
		public string? StateTopic { get; set; }

		[JsonProperty("value_template")]
		public string? ValueTemplate { get; set; }

		/// <summary>
		/// https://developers.home-assistant.io/docs/core/entity/sensor/#available-state-classes 
		/// </summary>
		[JsonProperty("state_class")]
		[JsonConverter(typeof(StringEnumConverter))]
		public MqttDiscoveryStateClass StateClass { get; set; }

		/// <summary>
		/// https://github.com/home-assistant/core/blob/dev/homeassistant/const.py#L460
		/// </summary>
		[JsonProperty("unit_of_measurement", NullValueHandling = NullValueHandling.Ignore)]
		public string? UnitOfMeasurement { get; set; }

	}
}
