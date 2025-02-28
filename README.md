# Como executar o projeto


## Requisitos

Certifique-se de ter o seguinte requisito instalado em sua máquina:

- **SDK**: .NET SDK 8.0

## Passo a Passo

Siga os passos abaixo para executar a aplicação:

1. **Abra o Terminal**

   Abra o terminal ou prompt de comando e navegue até o diretório do projeto.

2. **Limpe o Projeto**

   Execute o comando a seguir para limpar o projeto:
   ```bash
   dotnet clean

3. **Compile o Projeto**

   Execute o comando a seguir para compilar o projeto:
   ```bash
   dotnet build
   
4. **Execute o Projeto**

   Execute o comando a seguir para iniciar o projeto:
   ```bash
   dotnet run

## Observações

Após executar o comando dotnet run, o terminal exibirá a porta na qual o aplicativo estará rodando. 

OBS: Caso seja necessário resetar o banco de dados, apague os arquivos terminados em .db e a pasta "Migrations", e execute os seguintes comandos para criar as migrations e atualizar o banco respectivamente:

```bash
    dotnet ef migrations add InitialMigration
    dotnet ef database update