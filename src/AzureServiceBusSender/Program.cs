using Azure.Messaging.ServiceBus;

string connectionString = "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
string topicName = "sb-test-topic";

// Crie um client para o Service Bus
ServiceBusClient client = new(connectionString);

// Função para enviar uma mensagem
async Task SendMessageAsync(string messageBody)
{
    ServiceBusSender sender = client.CreateSender(topicName);
    ServiceBusMessage message = new(messageBody);

    try
    {
        await sender.SendMessageAsync(message);
        Console.WriteLine($"Mensagem enviada: {messageBody}");
    }
    finally
    {
        await sender.DisposeAsync();
    }
}

// Captura de mensagens do usuário
while (true)
{
    Console.Write("Escreva uma mensagem (ou 'sair' para terminar): ");
    string? input = Console.ReadLine();

    if (input is null)
    {
        return;
    }

    if (input?.ToLower() == "sair")
    {
        break;
    }

    if (input is not null)
    {
        await SendMessageAsync(input);
    }
}

await client.DisposeAsync();
