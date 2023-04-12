﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ToMqttNet.Test.Unit
{

	public class MqttDefaultLightDiscoveryConfigTests
	{
		[Fact]
		public void ToJson_SchemaIsBasic()
		{
			// Arrange
			var sut = new MqttDefaultLightDiscoveryConfig()
			{
				
			};

			// Act
			var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

			// Assert
			Assert.Equal("basic", result["schema"]!.ToString());
			// The documentation says it should be null or default - but in reality setting this to default makes it fail, so we just force it to basic
		}

		[Fact]
		public void ToJson_PayloadCanBeBoolean()
		{
			// Arrange
			var sut = new MqttDefaultLightDiscoveryConfig()
			{
				PayloadOn = true
			};

			// Act
			var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

			// Assert
			Assert.True(result["payload_on"]!.Value<bool>());
			// The documentation says it should be null or default - but in reality setting this to default makes it fail, so we just force it to basic
		}

		[Fact]
		public void ToJson_PayloadCanBeString()
		{
			// Arrange
			var sut = new MqttDefaultLightDiscoveryConfig()
			{
				PayloadOn = "someString"
			};

			// Act
			var result = (JObject)JsonConvert.DeserializeObject(sut.ToJson())!;

			// Assert
			Assert.Equal("someString", result["payload_on"]!.Value<string>());
			// The documentation says it should be null or default - but in reality setting this to default makes it fail, so we just force it to basic
		}
	}
}