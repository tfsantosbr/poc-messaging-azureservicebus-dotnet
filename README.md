# README

## Links Relacionados

- [Service Bus Emulator](https://devopsifyme.com/simple-azure-service-bus-emulator-finally-here/)

## Comandos para importar certificado no windows

```bash
# Obtenha o nome do diretório atual
containerPrefix=$(basename "$(pwd)")

# Copie o arquivo cacert.cer do contêiner para o host
docker cp "${containerPrefix}-emulator-1:/app/cacert.cer" cacert.cer

# Importar o certificado para o armazenamento de certificados de usuários atuais no Windows
powershell.exe -Command "Import-Certificate -FilePath cacert.cer -CertStoreLocation cert:\CurrentUser\Root"
```

## Exemplo de Connection String

```bash
Endpoint=sb://localhost/;SharedAccessKeyName=all;SharedAccessKey=CLwo3FQ3S39Z4pFOQDefaiUd1dSsli4XOAj3Y9Uh1E=;EnableAmqpLinkRedirect=false
```
