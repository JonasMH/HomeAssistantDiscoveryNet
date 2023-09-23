namespace ToMqttNet;

public class HomeAssistantDeviceClass
{
	public string Value { get; }

	public HomeAssistantDeviceClass(string value)
	{
		Value = value;
	}

	public override string ToString()
	{
		return Value;
	}

	/// <summary>
	/// Apparent power in VA.
	/// </summary>
	public static HomeAssistantDeviceClass APPARENT_POWER { get; } = new HomeAssistantDeviceClass("apparent_power");
	/// <summary>
	/// Air Quality Index
	/// </summary>
	public static HomeAssistantDeviceClass AQI { get; } = new HomeAssistantDeviceClass("aqi");
	/// <summary>
	/// Percentage of battery that is left
	/// </summary>
	public static HomeAssistantDeviceClass BATTERY { get; } = new HomeAssistantDeviceClass("battery");
	/// <summary>
	/// Carbon Dioxide in CO2 (Smoke)
	/// </summary>
	public static HomeAssistantDeviceClass CARBON_DIOXIDE { get; } = new HomeAssistantDeviceClass("carbon_dioxide");
	/// <summary>
	/// Carbon Monoxide in CO (Gas CNG/LPG)
	/// </summary>
	public static HomeAssistantDeviceClass CARBON_MONOXIDE { get; } = new HomeAssistantDeviceClass("carbon_monoxide");
	/// <summary>
	/// Current in A
	/// </summary>
	public static HomeAssistantDeviceClass CURRENT { get; } = new HomeAssistantDeviceClass("current");
	/// <summary>
	/// Date string (ISO 8601)
	/// </summary>
	public static HomeAssistantDeviceClass DATE { get; } = new HomeAssistantDeviceClass("date");
	/// <summary>
	/// Duration in days, hours, minutes or seconds
	/// </summary>
	public static HomeAssistantDeviceClass DURATION { get; } = new HomeAssistantDeviceClass("duration");
	/// <summary>
	/// Energy in Wh, kWh or MWh
	/// </summary>
	public static HomeAssistantDeviceClass ENERGY { get; } = new HomeAssistantDeviceClass("energy");
	/// <summary>
	/// Frequency in Hz, kHz, MHz or GHz
	/// </summary>
	public static HomeAssistantDeviceClass FREQUENCY { get; } = new HomeAssistantDeviceClass("frequency");
	/// <summary>
	/// Gasvolume in m³ or ft³
	/// </summary>
	public static HomeAssistantDeviceClass GAS { get; } = new HomeAssistantDeviceClass("gas");
	/// <summary>
	/// Percentage of humidity in the air
	/// </summary>
	public static HomeAssistantDeviceClass HUMIDITY { get; } = new HomeAssistantDeviceClass("humidity");
	/// <summary>
	/// The current light level in lx or lm
	/// </summary>
	public static HomeAssistantDeviceClass ILLUMINANCE { get; } = new HomeAssistantDeviceClass("illuminance");
	/// <summary>
	/// The monetary value
	/// </summary>
	public static HomeAssistantDeviceClass MONETARY { get; } = new HomeAssistantDeviceClass("monetary");
	/// <summary>
	/// Concentration of Nitrogen Dioxide in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass NITROGEN_DIOXIDE { get; } = new HomeAssistantDeviceClass("nitrogen_dioxide");
	/// <summary>
	/// Concentration of Nitrogen Monoxide in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass NITROGEN_MONOXIDE { get; } = new HomeAssistantDeviceClass("nitrogen_monoxide");
	/// <summary>
	/// Concentration of Nitrous Oxide in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass NITROUS_OXIDE { get; } = new HomeAssistantDeviceClass("nitrous_oxide");
	/// <summary>
	/// Concentration of Ozone in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass OZONE { get; } = new HomeAssistantDeviceClass("ozone");
	/// <summary>
	/// Concentration of particulate matter less than 1 micrometer in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass PM1 { get; } = new HomeAssistantDeviceClass("pm1");
	/// <summary>
	/// Concentration of particulate matter less than 10 micrometers in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass PM10 { get; } = new HomeAssistantDeviceClass("pm10");
	/// <summary>
	/// Concentration of particulate matter less than 2.5 micrometers in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass PM25 { get; } = new HomeAssistantDeviceClass("pm25");
	/// <summary>
	/// Power factor in %
	/// </summary>
	public static HomeAssistantDeviceClass POWER_FACTOR { get; } = new HomeAssistantDeviceClass("power_factor");
	/// <summary>
	/// Power in W or kW
	/// </summary>
	public static HomeAssistantDeviceClass POWER { get; } = new HomeAssistantDeviceClass("power");
	/// <summary>
	/// Pressure in Pa, kPa, hPa, bar, cbar, mbar, mmHg, inHg or psi
	/// </summary>
	public static HomeAssistantDeviceClass PRESSURE { get; } = new HomeAssistantDeviceClass("pressure");
	/// <summary>
	/// Reactive power in var
	/// </summary>
	public static HomeAssistantDeviceClass REACTIVE_POWER { get; } = new HomeAssistantDeviceClass("reactive_power");
	/// <summary>
	/// Signal strength in dB or dBm
	/// </summary>
	public static HomeAssistantDeviceClass SIGNAL_STRENGTH { get; } = new HomeAssistantDeviceClass("signal_strength");
	/// <summary>
	/// Concentration of sulphur dioxide in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass SULPHUR_DIOXIDE { get; } = new HomeAssistantDeviceClass("sulphur_dioxide");
	/// <summary>
	/// Temperature in °C or °F
	/// </summary>
	public static HomeAssistantDeviceClass TEMPERATURE { get; } = new HomeAssistantDeviceClass("temperature");
	/// <summary>
	/// Datetime object or timestamp string (ISO 8601)
	/// </summary>
	public static HomeAssistantDeviceClass TIMESTAMP { get; } = new HomeAssistantDeviceClass("timestamp");
	/// <summary>
	/// Concentration of volatile organic compounds in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass VOLATILE_ORGANIC_COMPOUNDS { get; } = new HomeAssistantDeviceClass("volatile_organic_compounds");
	/// <summary>
	/// Voltage in V
	/// </summary>
	public static HomeAssistantDeviceClass VOLTAGE { get; } = new HomeAssistantDeviceClass("voltage");
}
