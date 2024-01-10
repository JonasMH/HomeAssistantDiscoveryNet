namespace HomeAssistantDiscoveryNet;

public class HomeAssistantUnits(string value)
{
	public string Value { get; } = value;

	public override string ToString()
	{
		return Value;
	}



	// Power units
	public static HomeAssistantUnits POWER_WATT { get; } = new HomeAssistantUnits("W");
	public static HomeAssistantUnits POWER_KILO_WATT { get; } = new HomeAssistantUnits("kW");

	// Voltage units
	public static HomeAssistantUnits VOLT { get; } = new HomeAssistantUnits("V");

	// Energy units
	public static HomeAssistantUnits ENERGY_WATT_HOUR { get; } = new HomeAssistantUnits("Wh");
	public static HomeAssistantUnits ENERGY_KILO_WATT_HOUR { get; } = new HomeAssistantUnits("kWh");

	// Electrical units
	public static HomeAssistantUnits ELECTRICAL_CURRENT_AMPERE { get; } = new HomeAssistantUnits("A");
	public static HomeAssistantUnits ELECTRICAL_VOLT_AMPERE { get; } = new HomeAssistantUnits("VA");

	// Degree units
	public static HomeAssistantUnits DEGREE { get; } = new HomeAssistantUnits("°");

	// Currency units
	public static HomeAssistantUnits CURRENCY_EURO { get; } = new HomeAssistantUnits("€");
	public static HomeAssistantUnits CURRENCY_DOLLAR { get; } = new HomeAssistantUnits("$");
	public static HomeAssistantUnits CURRENCY_CENT { get; } = new HomeAssistantUnits("¢");

	// Temperature units
	public static HomeAssistantUnits TEMP_CELSIUS { get; } = new HomeAssistantUnits("°C");
	public static HomeAssistantUnits TEMP_FAHRENHEIT { get; } = new HomeAssistantUnits("°F");
	public static HomeAssistantUnits TEMP_KELVIN { get; } = new HomeAssistantUnits("K");

	// Time units
	public static HomeAssistantUnits TIME_MICROSECONDS { get; } = new HomeAssistantUnits("μs");
	public static HomeAssistantUnits TIME_MILLISECONDS { get; } = new HomeAssistantUnits("ms");
	public static HomeAssistantUnits TIME_SECONDS { get; } = new HomeAssistantUnits("s");
	public static HomeAssistantUnits TIME_MINUTES { get; } = new HomeAssistantUnits("min");
	public static HomeAssistantUnits TIME_HOURS { get; } = new HomeAssistantUnits("h");
	public static HomeAssistantUnits TIME_DAYS { get; } = new HomeAssistantUnits("d");
	public static HomeAssistantUnits TIME_WEEKS { get; } = new HomeAssistantUnits("w");
	public static HomeAssistantUnits TIME_MONTHS { get; } = new HomeAssistantUnits("m");
	public static HomeAssistantUnits TIME_YEARS { get; } = new HomeAssistantUnits("y");

	// Length units
	public static HomeAssistantUnits LENGTH_MILLIMETERS { get; } = new HomeAssistantUnits("mm");
	public static HomeAssistantUnits LENGTH_CENTIMETERS { get; } = new HomeAssistantUnits("cm");
	public static HomeAssistantUnits LENGTH_METERS { get; } = new HomeAssistantUnits("m");
	public static HomeAssistantUnits LENGTH_KILOMETERS { get; } = new HomeAssistantUnits("km");

	public static HomeAssistantUnits LENGTH_INCHES { get; } = new HomeAssistantUnits("in");
	public static HomeAssistantUnits LENGTH_FEET { get; } = new HomeAssistantUnits("ft");
	public static HomeAssistantUnits LENGTH_YARD { get; } = new HomeAssistantUnits("yd");
	public static HomeAssistantUnits LENGTH_MILES { get; } = new HomeAssistantUnits("mi");

	// Frequency units
	public static HomeAssistantUnits FREQUENCY_HERTZ { get; } = new HomeAssistantUnits("Hz");
	public static HomeAssistantUnits FREQUENCY_GIGAHERTZ { get; } = new HomeAssistantUnits("GHz");

	// Pressure units
	public static HomeAssistantUnits PRESSURE_PA { get; } = new HomeAssistantUnits("Pa");
	public static HomeAssistantUnits PRESSURE_HPA { get; } = new HomeAssistantUnits("hPa");
	public static HomeAssistantUnits PRESSURE_BAR { get; } = new HomeAssistantUnits("bar");
	public static HomeAssistantUnits PRESSURE_MBAR { get; } = new HomeAssistantUnits("mbar");
	public static HomeAssistantUnits PRESSURE_INHG { get; } = new HomeAssistantUnits("inHg");
	public static HomeAssistantUnits PRESSURE_PSI { get; } = new HomeAssistantUnits("psi");

	// Volume units
	public static HomeAssistantUnits VOLUME_LITERS { get; } = new HomeAssistantUnits("L");
	public static HomeAssistantUnits VOLUME_MILLILITERS { get; } = new HomeAssistantUnits("mL");
	public static HomeAssistantUnits VOLUME_CUBIC_METERS { get; } = new HomeAssistantUnits("m³");
	public static HomeAssistantUnits VOLUME_CUBIC_FEET { get; } = new HomeAssistantUnits("ft³");

	public static HomeAssistantUnits VOLUME_GALLONS { get; } = new HomeAssistantUnits("gal");
	public static HomeAssistantUnits VOLUME_FLUID_OUNCE { get; } = new HomeAssistantUnits("fl. oz.");

	// Volume Flow Rate units
	public static HomeAssistantUnits VOLUME_FLOW_RATE_CUBIC_METERS_PER_HOUR { get; } = new HomeAssistantUnits("m³/h");
	public static HomeAssistantUnits VOLUME_FLOW_RATE_CUBIC_FEET_PER_MINUTE { get; } = new HomeAssistantUnits("ft³/m");

	// Area units
	public static HomeAssistantUnits AREA_SQUARE_METERS { get; } = new HomeAssistantUnits("m²");

	// Mass units
	public static HomeAssistantUnits MASS_GRAMS { get; } = new HomeAssistantUnits("g");
	public static HomeAssistantUnits MASS_KILOGRAMS { get; } = new HomeAssistantUnits("kg");
	public static HomeAssistantUnits MASS_MILLIGRAMS { get; } = new HomeAssistantUnits("mg");
	public static HomeAssistantUnits MASS_MICROGRAMS { get; } = new HomeAssistantUnits("µg");

	public static HomeAssistantUnits MASS_OUNCES { get; } = new HomeAssistantUnits("oz");
	public static HomeAssistantUnits MASS_POUNDS { get; } = new HomeAssistantUnits("lb");

	// Conductivity units
	public static HomeAssistantUnits CONDUCTIVITY { get; } = new HomeAssistantUnits("µS/cm");

	// Light units
	public static HomeAssistantUnits LIGHT_LUX { get; } = new HomeAssistantUnits("lx");

	// UV Index units
	public static HomeAssistantUnits UV_INDEX { get; } = new HomeAssistantUnits("UV index");

	// Percentage units
	public static HomeAssistantUnits PERCENTAGE { get; } = new HomeAssistantUnits("%");

	// Irradiation units
	public static HomeAssistantUnits IRRADIATION_WATTS_PER_SQUARE_METER { get; } = new HomeAssistantUnits("W/m²");

	// Precipitation units
	public static HomeAssistantUnits PRECIPITATION_MILLIMETERS_PER_HOUR { get; } = new HomeAssistantUnits("mm/h");

	// Concentration units
	public static HomeAssistantUnits CONCENTRATION_MICROGRAMS_PER_CUBIC_METER { get; } = new HomeAssistantUnits("µg/m³");
	public static HomeAssistantUnits CONCENTRATION_MILLIGRAMS_PER_CUBIC_METER { get; } = new HomeAssistantUnits("mg/m³");
	public static HomeAssistantUnits CONCENTRATION_PARTS_PER_CUBIC_METER { get; } = new HomeAssistantUnits("p/m³");
	public static HomeAssistantUnits CONCENTRATION_PARTS_PER_MILLION { get; } = new HomeAssistantUnits("ppm");
	public static HomeAssistantUnits CONCENTRATION_PARTS_PER_BILLION { get; } = new HomeAssistantUnits("ppb");

	// Speed units
	public static HomeAssistantUnits SPEED_MILLIMETERS_PER_DAY { get; } = new HomeAssistantUnits("mm/d");
	public static HomeAssistantUnits SPEED_INCHES_PER_DAY { get; } = new HomeAssistantUnits("in/d");
	public static HomeAssistantUnits SPEED_METERS_PER_SECOND { get; } = new HomeAssistantUnits("m/s");
	public static HomeAssistantUnits SPEED_INCHES_PER_HOUR { get; } = new HomeAssistantUnits("in/h");
	public static HomeAssistantUnits SPEED_KILOMETERS_PER_HOUR { get; } = new HomeAssistantUnits("km/h");
	public static HomeAssistantUnits SPEED_MILES_PER_HOUR { get; } = new HomeAssistantUnits("mph");

	// Signal_strength units
	public static HomeAssistantUnits SIGNAL_STRENGTH_DECIBELS { get; } = new HomeAssistantUnits("dB");
	public static HomeAssistantUnits SIGNAL_STRENGTH_DECIBELS_MILLIWATT { get; } = new HomeAssistantUnits("dBm");

	// Data units
	public static HomeAssistantUnits DATA_BITS { get; } = new HomeAssistantUnits("bit");
	public static HomeAssistantUnits DATA_KILOBITS { get; } = new HomeAssistantUnits("kbit");
	public static HomeAssistantUnits DATA_MEGABITS { get; } = new HomeAssistantUnits("Mbit");
	public static HomeAssistantUnits DATA_GIGABITS { get; } = new HomeAssistantUnits("Gbit");
	public static HomeAssistantUnits DATA_BYTES { get; } = new HomeAssistantUnits("B");
	public static HomeAssistantUnits DATA_KILOBYTES { get; } = new HomeAssistantUnits("kB");
	public static HomeAssistantUnits DATA_MEGABYTES { get; } = new HomeAssistantUnits("MB");
	public static HomeAssistantUnits DATA_GIGABYTES { get; } = new HomeAssistantUnits("GB");
	public static HomeAssistantUnits DATA_TERABYTES { get; } = new HomeAssistantUnits("TB");
	public static HomeAssistantUnits DATA_PETABYTES { get; } = new HomeAssistantUnits("PB");
	public static HomeAssistantUnits DATA_EXABYTES { get; } = new HomeAssistantUnits("EB");
	public static HomeAssistantUnits DATA_ZETTABYTES { get; } = new HomeAssistantUnits("ZB");
	public static HomeAssistantUnits DATA_YOTTABYTES { get; } = new HomeAssistantUnits("YB");
	public static HomeAssistantUnits DATA_KIBIBYTES { get; } = new HomeAssistantUnits("KiB");
	public static HomeAssistantUnits DATA_MEBIBYTES { get; } = new HomeAssistantUnits("MiB");
	public static HomeAssistantUnits DATA_GIBIBYTES { get; } = new HomeAssistantUnits("GiB");
	public static HomeAssistantUnits DATA_TEBIBYTES { get; } = new HomeAssistantUnits("TiB");
	public static HomeAssistantUnits DATA_PEBIBYTES { get; } = new HomeAssistantUnits("PiB");
	public static HomeAssistantUnits DATA_EXBIBYTES { get; } = new HomeAssistantUnits("EiB");
	public static HomeAssistantUnits DATA_ZEBIBYTES { get; } = new HomeAssistantUnits("ZiB");
	public static HomeAssistantUnits DATA_YOBIBYTES { get; } = new HomeAssistantUnits("YiB");
	public static HomeAssistantUnits DATA_RATE_BITS_PER_SECOND { get; } = new HomeAssistantUnits("bit/s");
	public static HomeAssistantUnits DATA_RATE_KILOBITS_PER_SECOND { get; } = new HomeAssistantUnits("kbit/s");
	public static HomeAssistantUnits DATA_RATE_MEGABITS_PER_SECOND { get; } = new HomeAssistantUnits("Mbit/s");
	public static HomeAssistantUnits DATA_RATE_GIGABITS_PER_SECOND { get; } = new HomeAssistantUnits("Gbit/s");
	public static HomeAssistantUnits DATA_RATE_BYTES_PER_SECOND { get; } = new HomeAssistantUnits("B/s");
	public static HomeAssistantUnits DATA_RATE_KILOBYTES_PER_SECOND { get; } = new HomeAssistantUnits("kB/s");
	public static HomeAssistantUnits DATA_RATE_MEGABYTES_PER_SECOND { get; } = new HomeAssistantUnits("MB/s");
	public static HomeAssistantUnits DATA_RATE_GIGABYTES_PER_SECOND { get; } = new HomeAssistantUnits("GB/s");
	public static HomeAssistantUnits DATA_RATE_KIBIBYTES_PER_SECOND { get; } = new HomeAssistantUnits("KiB/s");
	public static HomeAssistantUnits DATA_RATE_MEBIBYTES_PER_SECOND { get; } = new HomeAssistantUnits("MiB/s");
	public static HomeAssistantUnits DATA_RATE_GIBIBYTES_PER_SECOND { get; } = new HomeAssistantUnits("GiB/s");
}
