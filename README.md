# Teste T�ncion BackEnd e FrontEnd - Enrique Cintra de Sousa

Projeto de BackEnd

### Pr�-requisitos
Baixar a solu��o e executar os dois projetos, tanto BackEnd quanto o FrontEnd.

## Projeto BackEnd 
Abrir� uma p�gina swwager para teste direto nas apis. Tamb�m � poss�vel autenticar via Bearer direto na p�gina swagger para utiliza��o de algumas apis que necessecitam de autentica��o.

## Projeto BackEnd 
Abrir� uma p�gina em React para utiliza��o das apis.

### Banco de Dados
Hospedei no MongoDB Atlas um cluster para testar a aplica��o, n�o e necess�rio modificar o appsetting.json.

Caso queiram iniciar um novo banco no Mongo � poss�vel modificar a chave "DataBase" da "ConnectionStrings" no appsetting.json.
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
    "Redis": "ecs.redis.cache.windows.net,abortConnect=false,ssl=true,allowAdmin=true,password=fpTJrzfdmvyDSGm8vxIdeuFfalEoJyPfxOiSXHYPP7s=",
    "RedisAWS": "ecs-redis.dgi8pl.clustercfg.use2.cache.amazonaws.com:6379,abortConnect=false"
  },
  "Settings": {
    "secretKey": "586ae5c9cf4d4d159f103a5fb4ed7a7f"
  }
}
```

### Cache Redis
Criei um Cache Redis no Azure para exemplificar na aplica��o, tamb�m n�o � necess�rio modificar o appsetting.json