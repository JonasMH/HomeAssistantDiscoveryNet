using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace ToMqttNet;

/*
 * const snakeToPascal = (string) => {
  return string.split("/")
	.map(snake => snake.split("_")
	  .map(substr => substr.charAt(0)
		.toUpperCase() +
		substr.slice(1))
	  .join(""))
	.join("/");
};
$$('.config-vars>div>.config-vars-item')
	.map(x => {
		var typeMap = {
			"template": "string",
			"boolean": "bool",
			"list": "List<>",
			"integer": "long",
			"float": "double"
		};

		var result = "///<summary>";
		result += "\n/// " + x.getElementsByClassName("config-vars-description")[0].innerText;
		var defaultValue = x.getElementsByClassName("config-vars-required")[0].getElementsByClassName("default")[0];            
		if(defaultValue.innerText) {
			result += "\n/// " + defaultValue.innerText
		}
		defaultValue = x.getElementsByClassName("config-vars-default")[0];            
		if(defaultValue?.innerText) {
			result += "\n/// " + defaultValue.innerText.replace(/\n/g, "\n///")
		}
		var varName = x.getElementsByClassName("config-vars-label-name")[0].innerText.trim();
		result += "\n///</summary> "
		result += "\n[JsonPropertyName(\"" + varName + "\")]"
		result += "\npublic "
		var varType = x.getElementsByClassName("config-vars-type")[0].innerText.trim();
		result += typeMap[varType] || varType;
		if(x.getElementsByClassName("config-vars-required")[0].getElementsByClassName("false")[0]) {
			result += "?";
		}
		result += " ";
		result += snakeToPascal(varName);
		result += " { get; set; }";
		return result;
	}).join('\n\n')
 */
public abstract class MqttDiscoveryConfig
{
	[JsonPropertyName("name")]
	public string? Name { get; init; }

	/// <summary>
	/// An ID that uniquely identifies this sensor. If two sensors have the same unique ID, Home Assistant will raise an exception.
	/// </summary>
	[JsonPropertyName("unique_id")]
	public string? UniqueId { get; init; }

	/// <summary>
	/// Information about the device this sensor is a part of to tie it into the device registry. Only works through MQTT discovery and when <see cref="UniqueId"/> is set. At least one of identifiers or connections must be present to identify the device.
	/// </summary>
	[JsonPropertyName("device")]
	public MqttDiscoveryDevice? Device { get; init; }

	/// <summary>
	/// A list of MQTT topics subscribed to receive availability (online/offline) updates. Must not be used together with availability_topic
	/// </summary>
	[JsonPropertyName("availability")]
	public List<MqttDiscoveryAvailablilty>? Availability { get; init; }

	///<summary>
	/// Defines a template to extract device’s availability from the availability_topic. To determine the devices’s availability result of this template will be compared to payload_available and payload_not_available.
	///</summary> 
	[JsonPropertyName("availability_template")]
	public string? AvailabilityTemplate { get; set; }

	///<summary>
	/// The MQTT topic subscribed to receive availability (online/offline) updates. Must not be used together with availability.
	///</summary> 
	[JsonPropertyName("availability_topic")]
	public string? AvailabilityTopic { get; set; }


	/// <summary>
	/// When <see cref="Availablilty"/> is configured, this controls the conditions needed to set the entity to available.
	/// <br/>
	/// If set to <see cref="MqttDiscoveryAvailabilityMode.All"/>, payload_available must be received on all configured availability topics before the entity is marked as online.
	/// <br/>
	/// If set to <see cref="MqttDiscoveryAvailabilityMode.Any"/>, payload_available must be received on at least one configured availability topic before the entity is marked as online.
	/// <br/>
	/// If set to <see cref="MqttDiscoveryAvailabilityMode.Latest"/>, the last payload_available or payload_not_available received on any configured availability topic controls the availability.
	/// </summary>
	[JsonPropertyName("availability_mode")]
	public MqttDiscoveryAvailabilityMode? AvailabilityMode { get; init; }

	/// <summary>
	/// <see href="https://www.home-assistant.io/docs/configuration/customizing-devices/#icon">Icon</see> for the entity.
	/// </summary>
	[JsonPropertyName("icon")]
	public string? Icon { get; set; }

	public abstract string Component { get; }
}

[JsonConverter(typeof(SnaekCaseJsonStringEnumConverter<MqttDiscoveryAvailabilityMode>))]
public enum MqttDiscoveryAvailabilityMode
{
	All,
	Any,
	Latest,
}

public class SnaekCaseJsonStringEnumConverter<TEnum> : JsonStringEnumConverter<TEnum>
		where TEnum : struct, Enum
{
	public SnaekCaseJsonStringEnumConverter() : base (namingPolicy: System.Text.Json.JsonNamingPolicy.SnakeCaseLower) { }
}

public class MqttDiscoveryAvailablilty
{
	/// <summary>
	/// The payload that represents the available state.
	/// </summary>
	[JsonPropertyName("payload_available")]
	public object? PayloadAvailable { get; init; }

	/// <summary>
	/// The payload that represents the unavailable state.
	/// </summary>
	[JsonPropertyName("payload_not_available")]
	public object? PayloadNotAvailable { get; init; }

	/// <summary>
	/// An MQTT topic subscribed to receive availability (online/offline) updates.
	/// </summary>
	[JsonPropertyName("topic")]
	public string Topic { get; init; }

	/// <summary>
	/// Defines a template to extract device’s availability from the topic. To determine the devices’s availability result of this template will be compared to payload_available and payload_not_available.
	/// </summary>
	[JsonPropertyName("value_template")]
	public string? ValueTemplate { get; init; }
}

public class MqttDiscoveryDevice
{
	/// <summary>
	/// The name of the device.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// The manufacturer of the device.
	/// </summary>
	[JsonPropertyName("manufacturer")]
	public string? Manufacturer { get; set; }

	/// <summary>
	/// The model of the device.
	/// </summary>
	[JsonPropertyName("model")]
	public string? Model { get; set; }

	/// <summary>
	/// Suggest an area if the device isn’t in one yet.
	/// </summary>
	[JsonPropertyName("suggested_area")]
	public string? SuggestedArea { get; set; }

	/// <summary>
	/// The firmware version of the device.
	/// </summary>
	[JsonPropertyName("sw_version")]
	public string? SoftwareVersion { get; set; }

	/// <summary>
	/// Identifier of a device that routes messages between this device and Home Assistant. Examples of such devices are hubs, or parent devices of a sub-device. This is used to show device topology in Home Assistant.
	/// </summary>
	[JsonPropertyName("via_device")]
	public string? ViaDevice { get; set; }

	/// <summary>
	/// A link to the webpage that can manage the configuration of this device. Can be either an HTTP or HTTPS link.
	/// </summary>
	[JsonPropertyName("configuration_url")]
	public string? ConfigurationUrl { get; set; }

	/// <summary>
	/// A list of connections of the device to the outside world as a list of tuples [connection_type, connection_identifier]. For example the MAC address of a network interface: "connections": [["mac", "02:5b:26:a8:dc:12"]].
	/// </summary>
	[JsonPropertyName("connections")]
	public List<List<string>>? Connections { get; set; }

	/// <summary>
	/// A list of IDs that uniquely identify the device. For example a serial number.
	/// </summary>
	[JsonPropertyName("identifiers")]
	public List<string>? Identifiers { get; set; }

}

[JsonConverter(typeof(SnaekCaseJsonStringEnumConverter<MqttDiscoveryStateClass>))]
public enum MqttDiscoveryStateClass
{
	Measurement,
	Total,
	TotalIncreasing,
}
