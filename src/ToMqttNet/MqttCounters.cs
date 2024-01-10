using System.Diagnostics.Metrics;

namespace ToMqttNet;

public class MqttCounters
{
	private readonly Meter _scope;

	private readonly Counter<long> _messagesSent;
	private readonly Counter<long> _messagesHandled;
	private readonly Counter<long> _connectionsCreated;
	private Func<int> _pendingMessages = () => 0;
	private int _connections = 0;

	public MqttCounters(IMeterFactory meterFactory)
	{
		_scope = meterFactory.Create("ToMqttNet");

		_messagesHandled = _scope.CreateCounter<long>("mqtt_client.messages_handled_total", "messages", description: "Amount of MQTT packages received");
		_messagesSent = _scope.CreateCounter<long>("mqtt_client.messages_sent_total", "messages", description: "Amount of MQTT packages sent");
		_connectionsCreated = _scope.CreateCounter<long>("mqtt_client.connections_opened", description: "Amount of MQTT connections created");
		_scope.CreateObservableGauge<int>("mqtt_client.connections", () => _connections, unit: "connections", description: "Is MQTT connection active");
		_scope.CreateObservableGauge<int>("mqtt_client.pending_messages", _pendingMessages, unit: "messages", description: "Amount of ingoing MQTT messages pending to be processed by the client");
	}

	public void IncreaseMessagesSent()
	{
		_messagesSent.Add(1);
	}

	public void IncreaseMessagesHandled(bool success)
	{
		_messagesHandled.Add(1, new KeyValuePair<string, object?>("success", success));
	}

	public void NewConnection()
	{
		_connectionsCreated.Add(1);
	}

	public void SetConnections(int amount)
	{
		_connections = amount;
	}

	public void SetPendingMessages(Func<int> amount)
	{
		_pendingMessages = amount;
	}
}