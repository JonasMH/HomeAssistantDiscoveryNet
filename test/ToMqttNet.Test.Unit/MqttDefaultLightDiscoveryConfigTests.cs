using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xunit;
using HomeAssistantDiscoveryNet;

namespace ToMqttNet.Test.Unit;


public class MqttBinarySensorDiscoveryConfigTests
{
	[Fact]
	public void ToJson_SchemaIsBasic()
	{
		var cfg = new MqttBinarySensorDiscoveryConfig
		{
			Name = $"Recommend Charging",
			ValueTemplate = "{{ 'ON' if value_json.recommend else 'OFF' }}",
			StateTopic = $"some-node/status/recommend-charging",
			UniqueId = $"some-node-recommend-charging",
		};

		var json = cfg.ToJson();
		var result = (JObject)JsonConvert.DeserializeObject(json)!;
		// More than 5 can be an indication to many null properties are included.
		Assert.True(5 == result.Count, json);
	}

}
