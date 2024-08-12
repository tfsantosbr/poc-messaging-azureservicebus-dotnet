using Azure.Messaging.ServiceBus;

string connectionString = "Endpoint=sb://localhost/;SharedAccessKeyName=all;SharedAccessKey=CLwo3FQ3S39Z4pFOQDefaiUd1dSsli4XOAj3Y9Uh1E=;EnableAmqpLinkRedirect=false";
string topicName = "sb-test-topic"; // Substitua pelo nome da fila

// Crie um client para o Service Bus
ServiceBusClient client = new(connectionString);

// Função para receber mensagens
async Task ReceiveMessagesAsync()
{
    ServiceBusReceiver receiver = client.CreateReceiver(topicName);

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
