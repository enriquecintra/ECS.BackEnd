# Teste Téncion BackEnd e FrontEnd - Enrique Cintra de Sousa

Projeto de BackEnd

### Pré-requisitos
Baixar a solução e executar os dois projetos, tanto BackEnd quanto o FrontEnd.

## Projeto BackEnd 
Abrirá uma página swwager para teste direto nas apis. Também é possível autenticar via Bearer direto na página swagger para utilização de algumas apis que necessecitam de autenticação.

## Projeto BackEnd 
Abrirá uma página em React para utilização das apis.

### Banco de Dados
Hospedei no MongoDB Atlas um cluster para testar a aplicação, não e necessário modificar o appsetting.json.

Caso queiram iniciar um novo banco no Mongo é possível modificar a chave "DataBase" da "ConnectionStrings" no appsetting.json.
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
Criei um Cache Redis no Azure para exemplificar na aplicação, também não é necessário modificar o appsetting.json