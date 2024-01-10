using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xunit;
using HomeAssistantDiscoveryNet;

namespace ToMqttNet.Test.Unit;

public class MqttJsonLightDiscoveryConfigTests
{
	[Fact]
	public void ToJson_SchemaIsBasic()
	{
		// Arrange
		var sut = new MqttJsonLightDiscoveryConfig()
		{

		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		Assert.Equal("json", result["schema"]!.ToString());
	}
}
