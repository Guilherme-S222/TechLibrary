# Tech Library 📚

Projeto de API para cadastrar usuários, efetuar login e reservar livros.

O projeto é composto por:

- **Back-end:** API construída em C#;
- **Banco de dados:** SQLite;

## Estrutura do Projeto

```plaintext
📂TechLibrary/
 ├── /📂TechLibrary.Api               # Projeto de API
 ├── /📂TechLibrary.Communication     # Projeto de Comunicação
 ├── /📂TechLibrary.Exception         # Projeto de Exceptions   
 ├── 💾TechLibraryDb.db               # Arquivo do banco de dados SQLite
 └── 📝README.md                      # Este arquivo
```

 ## Guia de Execução do Projeto Tech Library 📚

Este guia descreve os passos necessários para executar o projeto **Tech Library**, desde o download do código até o acesso ao Swagger da API.

## 🛠️ Pré-requisitos
Antes de iniciar, certifique-se de ter os seguintes itens instalados:

- **[VSCode download](https://code.visualstudio.com/download)**
- **[.NET download](https://dotnet.microsoft.com/pt-br/download)**
- Um navegador web atualizado.

## ▶️ Passos para executar o projeto
### **1. Baixar o repositório**
- **1.1.** Faça o download do repositório como arquivo ZIP.
- **1.2.** Após o download, extraia o conteúdo do arquivo para um local de sua preferência.

### **2. Configurar o banco de dados**
- **2.1.** Abra o VSCode e selecione a pasta extraída do projeto.
- **2.2.** No painel lateral de navegação, localize o arquivo de configuração do banco de dados:
```
📂TechLibrary/
            └──📂TechLibrary.Api
                └──📂Infraestructure
                    └──📂DataAccess
                        └──📄TechLibraryDbContext.cs
         
```
- **2.3.** No arquivo **TechLibraryDbContext.cs**, atualize o caminho do banco de dados na linha abaixo:
```
optionsBuilder.UseSqlite("Data Source=INSERIR_O_CAMINHO_DO_BANCO_DE_DADOS\\TechLibraryDb.db");
```
- **2.4.** Para encontrar o caminho correto do banco de dados (**TechLibraryDb.db**):

    - Localize o arquivo do banco de dados na pasta do projeto.
        ```
        📂TechLibrary/
                └── 💾TechLibraryDb.db
        ```
    - Clique com o botão direito no arquivo e selecione **Propriedades**.
    - Copie o valor do campo **Local**, que será algo como:
        - C:/Users/seu-usuario/TechLibrary/TechLibraryDb.db
    - Salve o arquivo 📄**TechLibraryDbContext.cs**

### **3. Adicionar chave para criptografar e validar o token de acesso 🔑**
- **3.1.** Acessar o diretório
    ```
        📂TechLibrary/
                └── 📂TechLibrary.Api
                     └──📂Infraestructure
                         └──📂Security
                             └──📂Tokens
                                 └──📂Access
                                     └──📄JwtTokenGenerator.cs
    ```
- Você deve gerar a senha(key) aleatória com 32 caracteres e sem símbolos
- Alterar a variável 🔑`signingKey` e inserir a key para criptografar e validar as partes do token de acesso.
- Copiar a key gerada e alterar também a variável 🔑`signingKey` no arquivo 📄`Program.cs` localizado dentro da pasta 📂TechLibrary.Api do projeto.


### **4. Executar a API**
- **4.1.** No VSCode, abra o terminal integrado.
- **4.2.** Navegue até o diretório da API com os comandos:
```
cd TechLibrary
cd .\TechLibrary.Api\
```
- **4.3.** Compile e inicie a API executando:
```
dotnet run

```
- **4.4.** Aguarde até que a mensagem abaixo apareça no terminal:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5163
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
...

```
- **Anote a URL fornecida**, geralmente algo como: **http://localhost:5163.**

### **5. Testar a API**
- **5.1.** Com a URL anotada, abra seu navegador e acesse a URL da documentação Swagger da API, por exemplo:
```
http://localhost:5163/swagger
```
- **5.2.** Explore os endpoints disponíveis para testar as funcionalidades do projeto.

### 🏁 **Conclusão**
Seguindo os passos acima, você configurou e executou o projeto Tech Library com sucesso! 🚀
#
## Documentação da API 📄

#### Cadastrar usuário

```http
  POST /Users
```

| Parâmetro     | Tipo       | Descrição        |
| :------------ | :-------   | :--------------- |
| `Name`        | `string`   | **Obrigatório**  |
| `Email`       | `string`   | **Obrigatório**  |
| `Password`    | `string`   | **Obrigatório**  |

#### Consulta paginada dos livros

```http
  GET /Books/Filter
```
| Parâmetro    | Tipo     | Descrição         |
| :--------    | :------- | :---------------- |
| `pageNumber` | `integer`| **Obrigatório**.  |
| `title`      | `string` | Opcional.         |

#### Efetuar login

```http
  POST /Login
```

| Parâmetro  | Tipo     | Descrição         |
| :--------  | :------- | :---------------- |
| `email`    | `string` | **Obrigatório**.  |
| `password` | `string` | **Obrigatório**.  |

#### Efetuar reserva de livro

```http
  POST /Checkout/{bookId}
```

| Parâmetro | Tipo     | Descrição        |
| :-------- | :------- | :----------------|
| `bookId ` | `uuid`   | **Obrigatório**. |

## Referência

 - [Visual Studio Code](https://code.visualstudio.com/download)
 - [.NET](https://dotnet.microsoft.com/pt-br/download)
 

