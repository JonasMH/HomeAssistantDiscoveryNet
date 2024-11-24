using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ToMqttNet.Test.Unit;

public class MqttConnectionServiceTests
{
	private readonly MqttConnectionService _sut;
	private readonly MeterFactoryStub _meterFactoryStub;
	private readonly MqttClientStub _clientStub;

	public MqttConnectionServiceTests(ITestOutputHelper testOutputHelper)
	{
		_meterFactoryStub = new MeterFactoryStub();
		_clientStub = new MqttClientStub();
		_sut = new MqttConnectionService(
			testOutputHelper.CreateLogger<MqttConnectionService>(),
			Options.Create(new MqttConnectionOptions()),
			_clientStub,
			new MqttCounters(_meterFactoryStub));
	}

	[Fact]
	public async Task ShouldSetConnectionsToOne()
	{
		// Arrange
		using var listener = new MeterListener();
		var connections = -1;
		listener.InstrumentPublished = (instrument, listener) =>
		{
			if (instrument.Meter.Name == "ToMqttNet")
			{
				listener.EnableMeasurementEvents(instrument);
			}
		};
		listener.SetMeasurementEventCallback<int>((instrument, measurement, tags, state) =>
		{
			if (instrument.Name == "mqtt_client.connections")
			{
				connections = measurement;
			}
		});
		listener.Start();
		var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

		// Act
		_clientStub.IsConnected = true;
		await _sut.StartAsync(cancellationTokenSource.Token);
		await _clientStub.CallConnectionStateChangedAsync(new MqttClientConnectedEventArgs(new MqttClientConnectResult()));

		// Assert
		listener.RecordObservableInstruments();
		Assert.Equal(1, connections);
	}
	[Fact]
	public async Task ShouldIncreaseMessagesSent()
	{
		// Arrange
		using var listener = new MeterListener();
		var messagesSent = -1L;
		listener.InstrumentPublished = (instrument, listener) =>
		{
			if(instrument.Meter.Name == "ToMqttNet")
			{
				listener.EnableMeasurementEvents(instrument);
			}
		};
		listener.SetMeasurementEventCallback<long>((instrument, measurement, tags, state) =>
		{
			if (instrument.Name == "mqtt_client.messages_sent_total")
			{
				messagesSent = measurement;
			}
		});

		listener.Start();
		var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

		await _sut.StartAsync(cancellationTokenSource.Token);
		await _clientStub.CallConnectionStateChangedAsync(new MqttClientConnectedEventArgs(new MqttClientConnectResult()));

		var message = new MqttApplicationMessageBuilder()
			.WithTopic("my-topic")
			.WithPayload("my-payload")
			.Build();

		// Act
		await _sut.PublishAsync(message);

		// Assert
		Assert.Equal(1, messagesSent);
	}
}

public class MqttClientStub : IManagedMqttClient
{
	public IMqttClient InternalClient => throw new NotImplementedException();

	public bool IsConnected { get; set; }

	public bool IsStarted => throw new NotImplementedException();

	public ManagedMqttClientOptions Options => throw new NotImplementedException();

	public int PendingApplicationMessagesCount => throw new NotImplementedException();

	public event Func<ApplicationMessageProcessedEventArgs, Task> ApplicationMessageProcessedAsync = null!;
	public event Func<MqttApplicationMessageReceivedEventArgs, Task> ApplicationMessageReceivedAsync = null!;
	public event Func<ApplicationMessageSkippedEventArgs, Task> ApplicationMessageSkippedAsync = null!;
	public event Func<MqttClientConnectedEventArgs, Task> ConnectedAsync = null!;

	public Task CallConnectedAsync(MqttClientConnectedEventArgs args)
	{
		return ConnectedAsync.Invoke(args);
	}

	public event Func<ConnectingFailedEventArgs, Task> ConnectingFailedAsync = null!;
	public event Func<EventArgs, Task> ConnectionStateChangedAsync = null!;
	public Task CallConnectionStateChangedAsync(EventArgs args)
	{
		return ConnectionStateChangedAsync.Invoke(args);
	}
	public event Func<MqttClientDisconnectedEventArgs, Task> DisconnectedAsync = null!;
	public Task CallDisconnectedAsync(MqttClientDisconnectedEventArgs args)
	{
		return DisconnectedAsync.Invoke(args);
	}
	public event Func<ManagedProcessFailedEventArgs, Task> SynchronizingSubscriptionsFailedAsync = null!;
	public event Func<SubscriptionsChangedEventArgs, Task> SubscriptionsChangedAsync;

	public List<MqttApplicationMessage> EnqueuedMessage = [];
	public List<MqttTopicFilter> Subscriptions = [];

	public void Dispose(){}

	public Task EnqueueAsync(MqttApplicationMessage applicationMessage)
	{
		EnqueuedMessage.Add(applicationMessage);
		return Task.CompletedTask;
	}

	public Task EnqueueAsync(ManagedMqttApplicationMessage applicationMessage)
	{
		throw new NotImplementedException();
	}

	public Task PingAsync(CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task StartAsync(ManagedMqttClientOptions options)
	{
		return Task.CompletedTask;
	}

	public Task StopAsync(bool cleanDisconnect = true)
	{
		return Task.CompletedTask;
	}

	public Task SubscribeAsync(ICollection<MqttTopicFilter> topicFilters)
	{
		Subscriptions.AddRange(topicFilters);
		return Task.CompletedTask;
	}

	public Task UnsubscribeAsync(ICollection<string> topics)
	{
		return Task.CompletedTask;
	}

	public Task SubscribeAsync(IEnumerable<MqttTopicFilter> topicFilters)
	{
		return Task.CompletedTask;
	}

	public Task UnsubscribeAsync(IEnumerable<string> topics)
	{
		return Task.CompletedTask;
	}
}

public class MeterFactoryStub : IMeterFactory
{
	public Meter Create(MeterOptions options)
	{
		return new Meter(options);
	}

	public void Dispose(){}
}