# HomeAssistantDiscoveryNet

This project contains two libraries that are both published to Nuget

1. `HomeAssistantDiscoveryNet` Library, contains all HA Discovery Documents
2. `ToMqttNet` a managed way to keep a MQTT connection in ASP.NET

## HomeAssistantDiscoveryNet Library

Contains the following (Home Assistant MQTT Discovery Documents)[https://www.home-assistant.io/integrations/mqtt/#mqtt-discovery] as C\# classes:

- AlarmControlPanel
- BinarySensor
- Button
- Camera
- Climate
- Cover
- DefaultLight
- DeviceTracker
- DeviceTrigger
- Event
- Fan
- Humidifier
- Image
- JsonLight
- LawnMower
- Lock
- Number
- Scene
- Select
- Sensor
- Siren
- Switch
- TagScanner
- TemplateLight
- Text
- Update
- Vacuum
- Valve
- WaterHeater

This makes it easy to create discovery documents from C\# without having to worry about mistyping property names etc.

It also including de(serilization) using `System.Text.Json` source generators (AoT Compatible)

### How to serialize discovery docs

```csharp
var cfg = new MqttBinarySensorDiscoveryConfig
{
    Name = $"Recommend Charging",
    ValueTemplate = "{{ 'ON' if value_json.recommend else 'OFF' }}",
    StateTopic = $"some-node/status/recommend-charging",
    UniqueId = $"some-node-recommend-charging",
};

var json = cfg.ToJson();
```

Results in

```json
{
  "component": "binary_sensor",
  "state_topic": "some-node/status/recommend-charging",
  "value_template": "{{ 'ON' if value_json.recommend else 'OFF' }}",
  "name": "Recommend Charging",
  "unique_id": "some-node-recommend-charging"
}
```

### How to deserialize discovery docs

```csharp
var parser = new MqttDiscoveryConfigParser(NullLoggerFactory.Instance, []);
var topic = "some-node/binary/some_sensor";
var message = "{\"component\": \"binary_sensor\", \"state_topic\": \"some-node/status/recommend-charging\", \"value_template\": \"{{ 'ON' if value_json.recommend else 'OFF' }}\", \"name\": \"Recommend Charging\", \"unique_id\": \"some-node-recommend-charging\"}";

var result = parser.Parse(topic, message);

Assert.IsType<MqttBinarySensorDiscoveryConfig>(result);
```

## ToMqttNet Library

This sets up a managed connection to a MQTT broker with

- Makes use of [MQTTnet](https://github.com/dotnet/MQTTnet) for the connection
- Dependency injection
- `System.Diagnostics.Metrics` Based metrics
- AoT compatible
- Home Assistant Discovery integration

### How to set up the ToMqttNet Library

In `Program.cs`/`Startup.cs`

```csharp
var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddMqttConnection()
    .Configure<IOptions<MqttOptions>>((options, mqttConfI) =>
    {
        var mqttConf = mqttConfI.Value;
        options.NodeId = "myintegration";
        options.ClientOptions.ChannelOptions = new MqttClientTcpOptions
        {
            Server = mqttConf.Server,
            Port = mqttConf.Port,
        };
    });

// ...
```

### How to use the ToMqttNet Library

```csharp
// Remember to register this service in ASP.NET (Or call the .Execute)
public class CounterMqttBackgroundService(MqttConnectionService mqtt) : BackgroundService
{
    private readonly MqttConnectionService _mqtt = mqtt;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var discoveryDoc = new MqttSensorDiscoveryConfig()
        {
            UniqueId = "myintegration_mycounter",
            Name = "My Counter",
            ValueTemplate = "{{ value_json.value }}",
            StateTopic = _mqtt.MqttOptions.NodeId + "/status/counter", // myintegration/status/counter
        };

        await _mqtt.PublishDiscoveryDocument(discoveryDoc);

        var counter = 0L;
        while (!stoppingToken.IsCancellationRequested)
        {
            await _mqtt.PublishAsync(new MqttApplicationMessageBuilder()
                .WithTopic(_mqtt.MqttOptions.NodeId + "/status/counter")
                .WithPayload(JsonSerializer.Serialize(new {value = counter}))
                .Build());
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            counter++;
        }
    }
}
```

## Examples / usages of HomeAssistantDiscoveryNet and ToMqttNet

- [JonasMH/Dantherm2Mqtt](https://github.com/JonasMH/Dantherm2Mqtt)
