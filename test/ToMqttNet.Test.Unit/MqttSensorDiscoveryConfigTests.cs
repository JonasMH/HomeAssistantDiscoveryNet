using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ToMqttNet.Test.Unit;

public class MqttSensorDiscoveryConfigTests
{
	[Fact]
	public void ToJson_CorrectTopic()
	{
		// Arrange
		var sut = new MqttSensorDiscoveryConfig()
		{
			StateClass = MqttDiscoveryStateClass.TotalIncreasing
		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		Assert.Equal("total_increasing", result["state_class"]!.ToString());
	}
}
