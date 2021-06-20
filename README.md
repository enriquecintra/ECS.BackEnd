# Teste Técnico BackEnd e FrontEnd

### Pré-requisitos
Baixar a solução e executar os dois projetos, tanto BackEnd quanto o FrontEnd.

## Projeto BackEnd 
Abrirá uma página swagger para testar diretamente as apis. Também é possível autenticar via Bearer na própria página swagger para utilização de algumas apis que necessecitam de autenticação.

## Projeto BackEnd 
Abrirá uma página em React para utilização das apis.

### Banco de Dados
Hospedei um cluster no MongoDB Atlas para testar a aplicação, não e necessário modificar o appsetting.json.

### Cache Redis
Criei um Cache Redis no Azure para exemplificar na aplicação, também não é necessário modificar o appsetting.json

Caso queiram usar o servidores de vocês basta modificar a seção ConnectionStrings do appsetting.json
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

