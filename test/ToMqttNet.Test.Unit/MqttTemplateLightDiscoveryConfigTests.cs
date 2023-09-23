using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xunit;

namespace ToMqttNet.Test.Unit;

public class MqttTemplateLightDiscoveryConfigTests
{
	[Fact]
	public void ToJson_SchemaIsBasic()
	{
		// Arrange
		var sut = new MqttTemplateLightDiscoveryConfig()
		{

		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		Assert.Equal("template", result["schema"]!.ToString());
	}
}
