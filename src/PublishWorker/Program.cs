using Azure.Messaging.ServiceBus;

string connectionString = "Endpoint=sb://localhost/;SharedAccessKeyName=all;SharedAccessKey=CLwo3FQ3S39Z4pFOQDefaiUd1dSsli4XOAj3Y9Uh1E=;EnableAmqpLinkRedirect=false";
string topicName = "sb-test-topic"; // Substitua pelo nome da fila

// Crie um client para o Service Bus
ServiceBusClient client = new(connectionString);

// Crie um sender para a fila
ServiceBusSender sender = client.CreateSender(topicName);

// Mensagem a ser enviada
string messageBody = "Hello, Azure Service Bus!";
ServiceBusMessage message = new(messageBody);

try
{
    // Envie a mensagem
    await sender.SendMessageAsync(message);
    Console.WriteLine($"Mensagem enviada: {messageBody}");
}
finally
{
    // Feche o sender e o client
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

