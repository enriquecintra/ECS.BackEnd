# Teste T�cnico BackEnd e FrontEnd

### Pr�-requisitos
Baixar a solu��o e executar os dois projetos, tanto BackEnd quanto o FrontEnd.

## Projeto BackEnd 
Abrir� uma p�gina swagger para testar diretamente as apis. Tamb�m � poss�vel autenticar via Bearer na pr�pria p�gina swagger para utiliza��o de algumas apis que necessecitam de autentica��o.

## Projeto BackEnd 
Abrir� uma p�gina em React para utiliza��o das apis.

### Banco de Dados
Hospedei um cluster no MongoDB Atlas para testar a aplica��o, n�o e necess�rio modificar o appsetting.json.

### Cache Redis
Criei um Cache Redis no Azure para exemplificar na aplica��o, tamb�m n�o � necess�rio modificar o appsetting.json

Caso queiram usar o servidores de voc�s basta modificar a se��o ConnectionStrings do appsetting.json
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "MongoDb": "mongodb+srv://admin:enrique123@ecs.mw8gt.mongodb.net/TesteDatabase?retryWrites=true&w=majority",
    "DataBase": "TesteDatabase",
    "Redis": "ecs.redis.cache.windows.net,abortConnect=false,ssl=true,allowAdmin=true,password=fpTJrzfdmvyDSGm8vxIdeuFfalEoJyPfxOiSXHYPP7s="
  },
  "Settings": {
    "secretKey": "586ae5c9cf4d4d159f103a5fb4ed7a7f"
  }
}
```

