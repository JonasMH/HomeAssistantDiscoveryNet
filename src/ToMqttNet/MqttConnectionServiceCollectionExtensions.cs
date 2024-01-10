using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;
using System.Diagnostics.Metrics;

namespace ToMqttNet;

public static class MqttConnectionServiceCollectionExtensions
{
	public static OptionsBuilder<MqttConnectionOptions> AddMqttConnection(this IServiceCollection services)
	{
		services.AddSingleton(x =>
		{
			var meterFactory = x.GetService<IMeterFactory>() ?? throw new InvalidOperationException("Unable to find IMeterFactory in service collection. You may need to call .AddMetrics(). This should be automatically called in .NET8");
			return new MqttCounters(meterFactory);
		});
		services.AddSingleton<MqttConnectionService>();
		services.AddSingleton<IMqttConnectionService>(x => x.GetRequiredService<MqttConnectionService>());
		services.AddHostedService(x => x.GetRequiredService<MqttConnectionService>());
		services.AddKeyedSingleton(typeof(MqttConnectionService), (services, key) => new MqttFactory().CreateManagedMqttClient());

		return services.AddOptions<MqttConnectionOptions>();
	}
}
