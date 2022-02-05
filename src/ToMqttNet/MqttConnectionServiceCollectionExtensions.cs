using Microsoft.Extensions.DependencyInjection;

namespace ToMqttNet
{
	public static class MqttConnectionServiceCollectionExtensions
	{
		public static IServiceCollection AddMqttConnection(this IServiceCollection services, Action<MqttConnectionOptions> configureOptions)
		{
			services.AddSingleton<MqttConnectionService>();
			services.AddSingleton<IMqttConnectionService>(x => x.GetRequiredService<MqttConnectionService>());
			services.AddHostedService(x => x.GetRequiredService<MqttConnectionService>());
			services.AddOptions<MqttConnectionOptions>()
				.Configure(configureOptions)
				.BindConfiguration(nameof(MqttConnectionOptions))
				.ValidateDataAnnotations();

			return services;
		}
	}
}
