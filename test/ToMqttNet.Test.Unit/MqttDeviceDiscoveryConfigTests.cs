using HomeAssistantDiscoveryNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ToMqttNet.Test.Unit;

public class MqttDeviceDiscoveryConfigTests
{
    [Fact]
    public void ToJson_SchemaIsBasic()
    {
        var cfg = new MqttDeviceDiscoveryConfig
        {
            Device = new()
            {
                Manufacturer = "Test",
                Model = "TestModel",
                Name = "TestName"
            },
            Origin = new()
            {

            },
            StateTopic = "zigbee/0x086bd7fffe22836a"
        };


        var lightcfg = new MqttBinarySensorDiscoveryConfig
        {
            Name = $"Recommend Charging",
            ValueTemplate = "{{ 'ON' if value_json.recommend else 'OFF' }}",
            StateTopic = $"some-node/status/recommend-charging",
            UniqueId = $"some-node-recommend-charging",
        };

        cfg.AddComponent("charging", lightcfg);

        var json = cfg.ToJson();
        var result = (JObject)JsonConvert.DeserializeObject(json)!;
        
        Assert.Equal("binary_sensor", result["components"]?["charging"]?["platform"]?.ToString());
	}
}
