using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HomeAssistantDiscoveryNet;

public static class MqttDiscoveryParserServiceCollectionExtensions
{
	public static IServiceCollection AddMqttConfigParser(this IServiceCollection services, IEnumerable<CustomMqttDiscoveryConfigType> customConfigTypes)
	{
		services.TryAddSingleton<IMqttDiscoveryConfigParser, MqttDiscoveryConfigParser>();

		foreach (var customType in customConfigTypes)
		{
			services.AddSingleton<CustomMqttDiscoveryConfigType>(customType);
		}

		return services;
	}
}
