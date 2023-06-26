# Servidor Hasura com GraphQL

## Requisitos
* .NET 6.0;
* Dart SDK atualizado.

## Configurações do Docker

### Executando os Docker Containers
No diretório raíz, digite `docker-compose build` na linha de comando.
Para executar os contâiners, digite `docker-compose up -d` na linha de comando.

## Rodando

### Hasura
* Primeiramente, acesse a URL `localhost:8080` no navegador.
* No menu superior, vá para a aba `DATA`.

#### Conectando à base de dados
* Clique em `Connect Database`, escolha `Postgres` e clique em `Connect Existing Database`.
* Adicione um nome para a base de dados e defina a conexão via `Environment variable` com o valor `PG_DATABASE_URL`.
* À esquerda, em Databases clique na pasta public, dentro da base de dados conectada.
* Crie duas tabelas com as seguintes estruturas:

Tabela: categories

| Coluna      | Tipo    | 
| ----------- | ------- |
| categoryID  | integer |
| name        | text    |

* Defina a Primary Key como categoryID e Unique Key como name.

Tabela: movies

| Coluna      | Tipo    |
| ----------- | ------- |
| movieID     | integer (auto-increment) |
| categoryID  | integer |
| name        | text    |

* Defina a Primary Key como movieID, Foreign Key como categoryID e Unique Key como name.

* Adicione os relacionamentos para cada uma delas.

### Dart Server

* No diretório `tds_hasura_server/bin` ececute o comando `dart server.dart`.

### Cliente
* No diretório `tds_hasura_client` execute o comando `dotnet watch run` na linha de comando.
* Caso a página não abra automaticamente, utilize a URL `localhost:7041`.

