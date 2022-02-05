using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ToMqttNet.Test.Unit;

public class MqttDiscoveryConfigTests
{
	[Fact]
	public void ToJson_CorrectTopic()
	{
		// Arrange
		var sut = new MqttStubDiscoveryConfig()
		{
			
		};

		// Act
		var result = sut.ToJson();

		// Assert
		Assert.Equal("{\"component\":\"stub\"}", result);
	}

	[Fact]
	public void ToJson_Availability_IsStringBased()
	{
		// Arrange
		var sut = new MqttStubDiscoveryConfig()
		{
			AvailabliltyMode = MqttDiscoveryAvailabilityMode.Any
		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		Assert.Equal("any", result["availability_mode"]!.ToString());
	}
}


public class MqttStubDiscoveryConfig : MqttDiscoveryConfig<MqttStubDiscoveryConfig>
{
	public override string Component => "stub";
}
