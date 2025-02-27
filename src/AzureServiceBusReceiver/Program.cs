using Azure.Messaging.ServiceBus;

string connectionString = "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
string topicName = "sb-test-topic";
string subscriptionName = "sb-test-topic-subscription";

// Crie um client para o Service Bus
ServiceBusClient client = new(connectionString);

// Função para receber mensagens
async Task ReceiveMessagesAsync()
{
    ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);

    try
    {
        Console.WriteLine("Aguardando mensagens...");

        while (true)
        {
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            if (receivedMessage != null)
            {
                string body = receivedMessage.Body.ToString();
                Console.WriteLine($"Mensagem recebida: {body}");

                // Complete a mensagem para que ela seja removida da fila
                await receiver.CompleteMessageAsync(receivedMessage);
            }
        }
    }
    finally
    {
        await receiver.DisposeAsync();
    }
}

await ReceiveMessagesAsync();

await client.DisposeAsync();
