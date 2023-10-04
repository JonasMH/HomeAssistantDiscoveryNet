using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ToMqttNet;

public static class MqttConnectionServiceCollectionExtensions
{
	public static OptionsBuilder<MqttConnectionOptions> AddMqttConnection(this IServiceCollection services)
	{
		services.AddSingleton<MqttConnectionService>();
		services.AddSingleton<IMqttConnectionService>(x => x.GetRequiredService<MqttConnectionService>());
		services.AddHostedService(x => x.GetRequiredService<MqttConnectionService>());

		return services.AddOptions<MqttConnectionOptions>();
	}
}
