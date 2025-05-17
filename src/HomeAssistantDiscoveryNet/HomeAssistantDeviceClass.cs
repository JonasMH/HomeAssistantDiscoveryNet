namespace HomeAssistantDiscoveryNet;

public class HomeAssistantDeviceClass(string value)
{
	public string Value { get; } = value;

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
	/// Area in m², cm², km², mm², in², ft², yd², mi², ac, ha
	/// </summary>
	public static HomeAssistantDeviceClass AREA { get; } = new HomeAssistantDeviceClass("area");
	/// <summary>
	/// Atmospheric pressure in cbar, bar, hPa, mmHg, inHg, kPa, mbar, Pa or psi
	/// </summary>
	public static HomeAssistantDeviceClass ATMOSPHERIC_PRESSURE { get; } = new HomeAssistantDeviceClass("atmospheric_pressure");
	/// <summary>
	/// Percentage of battery that is left
	/// </summary>
	public static HomeAssistantDeviceClass BATTERY { get; } = new HomeAssistantDeviceClass("battery");
	/// <summary>
	/// Blood glucose concentration in mg/dL, mmol/L
	/// </summary>
	public static HomeAssistantDeviceClass BLOOD_GLUCOSE_CONCENTRATION { get; } = new HomeAssistantDeviceClass("blood_glucose_concentration");
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
	///  Data rate in bit/s, kbit/s, Mbit/s, Gbit/s, B/s, kB/s, MB/s, GB/s, KiB/s, MiB/s or GiB/s
	/// </summary>
	public static HomeAssistantDeviceClass DATA_RATE { get; } = new HomeAssistantDeviceClass("data_rate");
	/// <summary>
	/// Data size in bit, kbit, Mbit, Gbit, B, kB, MB, GB, TB, PB, EB, ZB, YB, KiB, MiB, GiB, TiB, PiB, EiB, ZiB or YiB
	/// </summary>
	public static HomeAssistantDeviceClass DATA_SIZE { get; } = new HomeAssistantDeviceClass("data_size");
	/// <summary>
	/// Date string (ISO 8601)
	/// </summary>
	public static HomeAssistantDeviceClass DATE { get; } = new HomeAssistantDeviceClass("date");
	/// <summary>
	/// Generic distance in km, m, cm, mm, mi, nmi, yd, or in
	/// </summary>
	public static HomeAssistantDeviceClass DISTANCE { get; } = new HomeAssistantDeviceClass("distance");
	/// <summary>
	/// Duration in d, h, min, s, ms, or µs
	/// </summary>
	public static HomeAssistantDeviceClass DURATION { get; } = new HomeAssistantDeviceClass("duration");
	/// <summary>
	/// Energy in J, kJ, MJ, GJ, mWh, Wh, kWh, MWh, GWh, TWh, cal, kcal, Mcal, or Gcal
	/// </summary>
	public static HomeAssistantDeviceClass ENERGY { get; } = new HomeAssistantDeviceClass("energy");
	/// <summary>
	/// Energy per distance in kWh/100km, mi/kWh or km/kWh.
	/// </summary>
	public static HomeAssistantDeviceClass ENERGY_DISTANCE { get; } = new HomeAssistantDeviceClass("energy_distance");
	/// <summary>
	/// Stored energy in J, kJ, MJ, GJ, mWh, Wh, kWh, MWh, GWh, TWh, cal, kcal, Mcal, or Gcal
	/// </summary>
	public static HomeAssistantDeviceClass ENERGY_STORAGE { get; } = new HomeAssistantDeviceClass("energy_storage");
	/// <summary>
	/// Has a limited set of (non-numeric) states. Set as options attribute:
	/// <code>
	/// attributes:<br/>
	///   options: "{{ ['This', 'That'] }}"
	/// </code>
	/// </summary>
	public static HomeAssistantDeviceClass ENUM { get; } = new HomeAssistantDeviceClass("enum");
	/// <summary>
	/// Frequency in Hz, kHz, MHz or GHz
	/// </summary>
	public static HomeAssistantDeviceClass FREQUENCY { get; } = new HomeAssistantDeviceClass("frequency");
	/// <summary>
	/// Gasvolume in m³ or ft³ or CCF
	/// </summary>
	public static HomeAssistantDeviceClass GAS { get; } = new HomeAssistantDeviceClass("gas");
	/// <summary>
	/// Percentage of humidity in the air
	/// </summary>
	public static HomeAssistantDeviceClass HUMIDITY { get; } = new HomeAssistantDeviceClass("humidity");
	/// <summary>
	/// The current light level in lx
	/// </summary>
	public static HomeAssistantDeviceClass ILLUMINANCE { get; } = new HomeAssistantDeviceClass("illuminance");
	/// <summary>
	/// Irradiance in W/m² or BTU/(h⋅ft²)
	/// </summary>
	public static HomeAssistantDeviceClass IRRADIANCE { get; } = new HomeAssistantDeviceClass("irradiance");
	/// <summary>
	/// Percentage of water in a substance in %
	/// </summary>
	public static HomeAssistantDeviceClass MOISTURE { get; } = new HomeAssistantDeviceClass("moisture");
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
	/// Potential hydrogen (pH) value of a water solution
	/// </summary>
	public static HomeAssistantDeviceClass PH { get; } = new HomeAssistantDeviceClass("ph");
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
	/// Power in mW, W, kW, MW, GW or TW
	/// </summary>
	public static HomeAssistantDeviceClass POWER { get; } = new HomeAssistantDeviceClass("power");
	/// <summary>
	/// Accumulated precipitation in cm, in or mm
	/// </summary>
	public static HomeAssistantDeviceClass PRECIPITATION { get; } = new HomeAssistantDeviceClass("precipitation");
	/// <summary>
	/// Precipitation intensity in in/d, in/h, mm/d or mm/h
	/// </summary>
	public static HomeAssistantDeviceClass PRECIPITATION_INTENSITY { get; } = new HomeAssistantDeviceClass("precipitation_intensity");
	/// <summary>
	/// Pressure in Pa, kPa, hPa, bar, cbar, mbar, mmHg, inHg or psi
	/// </summary>
	public static HomeAssistantDeviceClass PRESSURE { get; } = new HomeAssistantDeviceClass("pressure");
	/// <summary>
	/// Reactive power in var or kvar
	/// </summary>
	public static HomeAssistantDeviceClass REACTIVE_POWER { get; } = new HomeAssistantDeviceClass("reactive_power");
	/// <summary>
	/// Signal strength in dB or dBm
	/// </summary>
	public static HomeAssistantDeviceClass SIGNAL_STRENGTH { get; } = new HomeAssistantDeviceClass("signal_strength");
	/// <summary>
	/// Sound pressure in dB or dBA
	/// </summary>
	public static HomeAssistantDeviceClass SOUND_PRESSURE { get; } = new HomeAssistantDeviceClass("sound_pressure");
	/// <summary>
	/// Generic speed in ft/s, in/d, in/h, in/s, km/h, kn, m/s, mph, mm/d, or mm/s
	/// </summary>
	public static HomeAssistantDeviceClass SPEED { get; } = new HomeAssistantDeviceClass("speed");
	/// <summary>
	/// Concentration of sulphur dioxide in µg/m³
	/// </summary>
	public static HomeAssistantDeviceClass SULPHUR_DIOXIDE { get; } = new HomeAssistantDeviceClass("sulphur_dioxide");
	/// <summary>
	/// Temperature in °C or °F or K
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
	/// Ratio of volatile organic compounds in ppm or ppb
	/// </summary>
	public static HomeAssistantDeviceClass VOLATILE_ORGANIC_COMPUNDS_PARTS { get; } = new HomeAssistantDeviceClass("volatile_organic_compounds_parts");
	/// <summary>
	/// Voltage in V, mV, µV, kV, MV
	/// </summary>
	public static HomeAssistantDeviceClass VOLTAGE { get; } = new HomeAssistantDeviceClass("voltage");
	/// <summary>
	/// Generic volume in L, mL, gal, fl. oz., m³, ft³, or CCF
	/// </summary>
	public static HomeAssistantDeviceClass VOLUME { get; } = new HomeAssistantDeviceClass("volume");
	/// <summary>
	/// Volume flow rate in m³/h, m³/s, ft³/min, L/h, L/min, L/s, gal/min, or mL/s
	/// </summary>
	public static HomeAssistantDeviceClass VOLUME_FLOW_RATE { get; } = new HomeAssistantDeviceClass("volume_flow_rate");
	/// <summary>
	/// Water consumption in L, gal, m³, ft³, or CCF
	/// </summary>
	public static HomeAssistantDeviceClass VOLUME_STORAGE { get; } = new HomeAssistantDeviceClass("volume_storage");
	/// <summary>
	/// Generic mass in kg, g, mg, µg, oz, lb, or st
	/// </summary>
	public static HomeAssistantDeviceClass WEIGHT { get; } = new HomeAssistantDeviceClass("weight");
	/// <summary>
	/// Wind direction in °
	/// </summary>
	public static HomeAssistantDeviceClass WIND_DIRECTION { get; } = new HomeAssistantDeviceClass("wind_direction");
	/// <summary>
	/// Wind speed in Beaufort, ft/s, km/h, kn, m/s, or mph
	/// </summary>
	public static HomeAssistantDeviceClass WIND_SPEED { get; } = new HomeAssistantDeviceClass("wind_speed");
}
