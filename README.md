# Lab Manager

Mini-aplicação para cadastro e leitura de computadores em um banco de dados.

## Funcionalidades

- Cadastro de computadores em um banco de dados SQLite
- Leitura de computadores em um banco de dados SQLite

## Tecnologias utilizadas

- .NET 6.0

## Uso

Use o comando abaixo para baixar o repositório em seu computador

```bash
git clone https://github.com/Caioferrari04/LabManager.git
```

Para utilizar a aplicação, pode se usar os seguintes comandos:

CREATE: Substitua os valores para inserir novas tuplas na tabela 
 ```
 dotnet run -- Computer New id ram processador
 ```

E para listar, basta utilizar:

 ```
 dotnet run -- Computer List
 ```