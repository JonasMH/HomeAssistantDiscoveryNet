using HomeAssistantDiscoveryNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ToMqttNet.Test.Unit;

public class MqttDiscoveryConfigTests
{
	[Fact]
	public void ToJson_CorrectTopic()
	{
		// Arrange
		var sut = new MqttEventDiscoveryConfig()
		{
			
		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		Assert.Equal("event", result["component"]!.ToString());
	}

	[Fact]
	public void ToJson_ShouldIgnoreNullForObjects()
	{
		// Arrange
		var sut = new MqttEventDiscoveryConfig()
		{
			
		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		Assert.Null(result["device"]);
	}

	[Theory]
	[InlineData(typeof(MqttAlarmControlPanelDiscoveryConfig))]
	[InlineData(typeof(MqttBinarySensorDiscoveryConfig))]
	[InlineData(typeof(MqttButtonDiscoveryConfig))]
	[InlineData(typeof(MqttCameraDiscoveryConfig))]
	[InlineData(typeof(MqttClimateDiscoveryConfig))]
	[InlineData(typeof(MqttCoverDiscoveryConfig))]
	[InlineData(typeof(MqttDefaultLightDiscoveryConfig))]
	[InlineData(typeof(MqttDeviceTrackerDiscoveryConfig))]
	[InlineData(typeof(MqttDeviceTriggerDiscoveryConfig))]
	[InlineData(typeof(MqttEventDiscoveryConfig))]
	[InlineData(typeof(MqttFanDiscoveryConfig))]
	[InlineData(typeof(MqttHumidifierDiscoveryConfig))]
	[InlineData(typeof(MqttJsonLightDiscoveryConfig))]
	[InlineData(typeof(MqttLockDiscoveryConfig))]
	[InlineData(typeof(MqttNumberDiscoveryConfig))]
	[InlineData(typeof(MqttSceneDiscoveryConfig))]
	[InlineData(typeof(MqttSelectDiscoveryConfig))]
	[InlineData(typeof(MqttSensorDiscoveryConfig))]
	[InlineData(typeof(MqttSwitchDiscoveryConfig))]
	[InlineData(typeof(MqttTagScannerDiscoveryConfig))]
	[InlineData(typeof(MqttTemplateLightDiscoveryConfig))]
	[InlineData(typeof(MqttVacuumDiscoveryConfig))]
	[InlineData(typeof(MqttTextDiscoveryConfig))]
	[InlineData(typeof(MqttValveDiscoveryConfig))]
	[InlineData(typeof(MqttWaterHeaterDiscoveryConfig))]
	[InlineData(typeof(MqttUpdateDiscoveryConfig))]
	[InlineData(typeof(MqttSirenDiscoveryConfig))]
	[InlineData(typeof(MqttImageDiscoveryConfig))]
	public void ToJson_OutputShouldNotContainNull(Type configType)
	{
		var instance = (Activator.CreateInstance(configType) as MqttDiscoveryConfig)!;

		var json = instance.ToJson();

		Assert.DoesNotContain("null", json);
	}

	[Fact]
	public void ToJson_Availability_IsStringBased()
	{
		// Arrange
		var sut = new MqttEventDiscoveryConfig()
		{
			AvailabilityMode = MqttDiscoveryAvailabilityMode.Any
		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		Assert.Equal("any", result["availability_mode"]!.ToString());
	}

	[Fact]
	public void ToJson_DeviceConnections_ShouldBeAListOfLists()
	{
		// Arrange
		var sut = new MqttEventDiscoveryConfig()
		{
			Device = new MqttDiscoveryDevice
			{
				Connections = new List<List<string>>
				{
					new List<string>
					{
						"ip",
						"192.168.0.1"
					}
				}
			}
		};

		// Act
		var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

		// Assert
		var connectionArray = result["device"]!["connections"]!;
		Assert.IsType<JArray>(connectionArray);
		var con1Array = connectionArray[0]!;
		Assert.IsType<JArray>(con1Array);
		Assert.Equal("ip", con1Array[0]);
		Assert.Equal("192.168.0.1", con1Array[1]);
	}
}
