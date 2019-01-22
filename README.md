# Gerenciamento de Patrimônios

[![LENNON](https://img.shields.io/badge/desenvolvido%20por-LENNON-red.svg?longCache=true&style=for-the-badge)](https://lennonalves.com.br)

Neste projeto são utilizadas as seguintes tecnologias e conceitos:

  - NetCore 2.2
  - Entity Framework
  - SQL Server
  - Docker
  - Domain Driven Design
  - Swagger UI

## A Aplicacao

Tem como finalidade o gerenciamento de patrimônios utilizando um Sistema Web. Nele você consegue fazer todas as operações básicas de `patrimônios`

- GET patrimonios - Obter todos os patrimônios
- GET patrimonios/{id} - Obter um patrimônio por ID
- POST patrimonios - Inserir um novo patrimônio
- PUT patrimonios/{id} - Alterar os dados de um patrimônio
- DELETE patrimonios/{id} - Excluir um patrimônio

e `marcas`

- GET patrimonios - Obter todas as marcas
- GET patrimonios/{id} - Obter uma marca por ID
- GET marcas/{id}/patrimonios - Obter todos os patrimônios de uma marca
- POST patrimonios - Inserir uma nova marca
- PUT patrimonios/{id} - Alterar os dados de uma marca
- DELETE patrimonios/{id} - Excluir uma marca

Os `patrimônios` possuem os campos

- `Id` - Chave primária
- `Nome` - Obrigatório
- `MarcaId` - Obrigatório
- `Descricao`
- `NumeroTombo` - Gerado automaticamente - Proibido alteração

As `marcas` possuem os campos

- `Id` - Chave primária
- `Nome` - Obrigatório

## Como utilizar

 - Execute o container contendo SQL Server

```
$ docker pull mcr.microsoft.com/mssql/server:2017-latest
$ docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Developer2019" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

- Realize o update da database

```
$ ~/GerenciamentoPatrimonios/Aplicacao/4 - Infra/GP.Dados
$ dotnet ef database update
```

ATENÇÃO: Utilize o comando `docker ps` para listar todos os containers em funcionamento. Verifique se o container está em execução e se atente às portas utilizadas no(s) `appsettings.json` e no `connection.json` da API.

 - Realize o build da aplicação

```
$ ~/GerenciamentoPatrimonios/Aplicacao/1\ -\ Servicos/GP.WebApi/
$ rm -Rf published/
$ dotnet build
$ dotnet restore
$ dotnet publish -c release -o published /property:PublishWithAspNetCoreTargetManifest=false
```

 - Crie a imagem da aplicação

```
$ docker build --no-cache -f Dockerfile -t gerenciamentopatrimonios .
```

- Execute o container contendo a aplicação

```
$ docker run -d --name gerenciamentopatrimonios-api -p 5151:5151 --restart=always gerenciamentopatrimonios
```



Navegue pela API acessando o endereço `localhost` ou pelo endereço IP gerado pelo seu serviço Docker (`docker-machine ip`) e a porta configurada no container.

## Requisitos

Para que os containers possam ser *startados* corretamente, é necessário que você tenha o Docker instalado e configurado corretamente.

 - [Docker for Windows] - Veja como ter o Docker para seu Windows.
 - [Docker for Mac] - Veja como ter o Docker para seu Mac.
 - [Docker for Linux Server] - Veja como ter o Docker para o seu Linux Server.
 - [Docker for Debian] - Veja como ter o Docker para seu Debian.
 - [Docker for Fedora] - Veja como ter o Docker para seu Fedora.
 - [Docker for Ubuntu] - Veja como ter o Docker para seu Ubuntu.
 - [Docker for AWS] - Veja como ter o Docker para seu ambiente na AWS.
 - [Docker for Azure] - Veja como ter o Docker para seu ambiente na Azure.

[Docker for Windows]: <https://www.docker.com/docker-windows>
[Docker for Mac]: <https://www.docker.com/docker-mac>
[Docker for Linux Server]: <https://www.docker.com/docker-centos>
[Docker for Debian]: <https://www.docker.com/docker-debian>
[Docker for Fedora]: <https://www.docker.com/docker-fedora>
[Docker for Ubuntu]: <https://www.docker.com/docker-ubuntu>
[Docker for AWS]: <https://www.docker.com/docker-aws>
[Docker for Azure]: <https://www.docker.com/docker-microsoft-azure>