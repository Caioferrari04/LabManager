# Lab Manager

Mini-aplicação para cadastro e leitura de computadores em um banco de dados.

## Funcionalidades

- Cadastro de computadores;
- Leitura de computadores;
- Cadastro de laboratórios;
- Leitura de laboratórios.

## Tecnologias utilizadas

- .NET 6.0

## Uso

Use o comando abaixo para baixar o repositório em seu computador

```bash
git clone https://github.com/Caioferrari04/LabManager.git
```

Para utilizar a aplicação, pode se usar os seguintes comandos:

## Computadores
CREATE, Substitua os valores para inserir novas tuplas na tabela:
 ```
 dotnet run -- Computer New id ram processador
 ```

READ, liste utilizando:

 ```
 dotnet run -- Computer List
 ```
## Laboratórios
 CREATE, Substitua os valores para inserir novas tuplas na tabela:
 
  ```
  dotnet run -- Lab New id number name block
  ```

 READ, liste utilizando:

  ```
  dotnet run -- Lab List
  ```