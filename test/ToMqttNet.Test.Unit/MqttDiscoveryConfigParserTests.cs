using HomeAssistantDiscoveryNet;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ToMqttNet.Test.Unit;

public class MqttDiscoveryConfigParserTests
{
	public MqttDiscoveryConfigParser _sut;

	public MqttDiscoveryConfigParserTests(ITestOutputHelper testOutputHelper)
	{
		_sut = new MqttDiscoveryConfigParser(NullLoggerFactory.Instance, []);
	}

	[Fact]
	public void Parse_ParseSensorConfig_ParseOkay()
	{
		var message = "{\"availability\":[{\"topic\":\"zigbee/bridge/state\"}],\"device\":{\"identifiers\":[\"zigbee2mqtt_0x086bd7fffe22836a\"],\"manufacturer\":\"IKEA\",\"model\":\"TRADFRI driver for wireless control (30 watt) (ICPSHC24-30EU-IL-1)\",\"name\":\"0x086bd7fffe22836a\",\"sw_version\":\"2.3.086\"},\"enabled_by_default\":false,\"entity_category\":\"diagnostic\",\"icon\":\"mdi:signal\",\"name\":\"0x086bd7fffe22836a linkquality\",\"state_class\":\"measurement\",\"state_topic\":\"zigbee/0x086bd7fffe22836a\",\"unique_id\":\"0x086bd7fffe22836a_linkquality_zigbee\",\"unit_of_measurement\":\"lqi\",\"value_template\":\"{{ value_json.linkquality }}\"}";
		var topic = "homeassistant/sensor/0x086bd7fffe22836a/update_state";

		var result = _sut.Parse(topic, message);

		Assert.IsType<MqttSensorDiscoveryConfig>(result);
		Assert.Equal("lqi", ((MqttSensorDiscoveryConfig)result).UnitOfMeasurement);
	}

	[Fact]
	public void Parse_ParseLightConfig_ParseOkay()
	{
		var message = "{\"availability\":[{\"topic\":\"zigbee/bridge/state\"}],\"brightness\":true,\"brightness_scale\":254,\"command_topic\":\"zigbee/0x086bd7fffe22836a/set\",\"device\":{\"identifiers\":[\"zigbee2mqtt_0x086bd7fffe22836a\"],\"manufacturer\":\"IKEA\",\"model\":\"TRADFRI driver for wireless control (30 watt) (ICPSHC24-30EU-IL-1)\",\"name\":\"0x086bd7fffe22836a\",\"sw_version\":\"2.3.086\"},\"effect\":true,\"effect_list\":[\"blink\",\"breathe\",\"okay\",\"channel_change\",\"finish_effect\",\"stop_effect\"],\"name\":\"0x086bd7fffe22836a\",\"schema\":\"json\",\"state_topic\":\"zigbee/0x086bd7fffe22836a\",\"unique_id\":\"0x086bd7fffe22836a_light_zigbee\"}";
		var topic = "homeassistant/light/0x086bd7fffe22836a/light/config";

		var result = _sut.Parse(topic, message);

		Assert.IsType<MqttJsonLightDiscoveryConfig>(result);
		Assert.Equal(254, ((MqttJsonLightDiscoveryConfig)result).BrightnessScale);
	}

	[Fact]
	public void Parse_ParseReadmeExample()
	{
		var parser = new MqttDiscoveryConfigParser(NullLoggerFactory.Instance, []);
		var topic = "some-node/binary_sensor/some_sensor";
		var message = "{\"component\": \"binary_sensor\", \"state_topic\": \"some-node/status/recommend-charging\", \"value_template\": \"{{ 'ON' if value_json.recommend else 'OFF' }}\", \"name\": \"Recommend Charging\", \"unique_id\": \"some-node-recommend-charging\"}";

		var result = parser.Parse(topic, message);

		Assert.IsType<MqttBinarySensorDiscoveryConfig>(result);
	}
}
