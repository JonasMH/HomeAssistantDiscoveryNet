using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xunit;
using HomeAssistantDiscoveryNet;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit.Abstractions;

namespace ToMqttNet.Test.Unit;


public class MqttBinarySensorDiscoveryConfigTests(ITestOutputHelper testOutput)
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
		// More than 6 can be an indication to many null properties are included.
		Assert.True(6 == result.Count, json);
	}


	[Fact]
	public void Parse_ExampleJson()
	{

		var json = """
{"availability":[{"topic":"zigbee/bridge/state","value_template":"{{ value_json.state }}"},{"topic":"zigbee/firealarm/availability","value_template":"{{ value_json.state }}"}],"availability_mode":"all","default_entity_id":"binary_sensor.firealarm_heat","device":{"hw_version":1,"identifiers":["zigbee2mqtt_0x187a3efffe2e4235"],"manufacturer":"Schneider Electric","model":"Wiser smoke alarm","model_id":"W599501","name":"Firealarm","sw_version":"2209261","via_device":"zigbee2mqtt_bridge_0x4c5bb3fffe83b1ec"},"name":"Heat","object_id":"firealarm_heat","origin":{"name":"Zigbee2MQTT","sw":"2.6.2","url":"https://www.zigbee2mqtt.io"},"payload_off":false,"payload_on":true,"state_topic":"zigbee/firealarm","unique_id":"0x187a3efffe2e4235_heat_zigbee","value_template":"{{ value_json.heat }}"}
""";


		var parser = new MqttDiscoveryConfigParser(NullLoggerFactory.Instance, []);

		testOutput.WriteLine("Parsing JSON: " + json);

		var result = parser.Parse("homeassistant/binary_sensor/firealarm/config", json);

		Assert.NotNull(result);
		Assert.IsType<MqttBinarySensorDiscoveryConfig>(result);
		Assert.Equal("true", ((MqttBinarySensorDiscoveryConfig)result!).PayloadOn);
	}
}
