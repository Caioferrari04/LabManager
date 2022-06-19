# Lab Manager

Mini-aplicação com CRUD para administração de computadores e laboratórios em um banco de dados.

---

## Funcionalidades

- CRUD de Computadores:
    - Cadastro de computadores
    - Listagem de computadores
    - Exibição de um computador por ID
    - Deleção de um computador
    - Atualização de um computador

- CRUD de Laboratórios:
    - Cadastro de laboratórios
    - Listagem de laboratórios
    - Exibição de laboratório por ID
    - Deleção de um laboratório
    - Atualização de um laboratório

---

## Tecnologias utilizadas

- .NET 6.0
- SQLite 6.0
- Dapper 2.0

---

## Uso

Use o comando abaixo para baixar o repositório em seu computador

```bash
git clone https://github.com/Caioferrari04/LabManager.git
```

Para utilizar a aplicação, pode se usar os seguintes comandos:

---

## Computadores
CREATE, Substitua os valores para inserir novas tuplas na tabela:
 ```
 dotnet run -- Computer New id ram processador
 ```

READ, liste utilizando:

 ```
 dotnet run -- Computer List
 ```

READ (single), obtenha um computador específico utilizando:

 ```
 dotnet run -- Computer Show id
 ```

 UPDATE, atualize um computador específico utilizando:
 ```
 dotnet run -- Computer Update id ram processador
 ```

DELETE, remova um computador específico utilizando:
 ```
 dotnet run -- Computer Delete id
 ```
---
## Laboratórios
CREATE, Substitua os valores para inserir novas tuplas na tabela:
 ```
 dotnet run -- Lab New id number name block
 ```

READ, liste utilizando:

 ```
 dotnet run -- Lab List
 ```

READ (single), obtenha um laboratório específico utilizando:

 ```
 dotnet run -- Lab Show id
 ```

UPDATE, atualize um laboratório específico utilizando:
 ```
 dotnet run -- Lab Update id number name block
 ```

DELETE, remova um laboratório específico utilizando:
 ```
 dotnet run -- Lab Delete id
 ```