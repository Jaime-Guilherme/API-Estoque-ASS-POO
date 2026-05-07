# API Estoque ASS - Projeto Final POO

## Sobre o Projeto

API REST desenvolvida em **C# com .NET** para gerenciamento de estoque.  
Projeto final da disciplina de **Programação Orientada a Objetos (POO)**.

O sistema permite o controle completo de itens do estoque com operações CRUD, validações de negócio e persistência em banco de dados SQLite.

---

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 10.0 (Minimal API)
- **Arquitetura**: Repository Pattern + Service Layer + DTOs
- **Banco de Dados**: SQLite + Entity Framework Core
- **Documentação**: Swagger UI
- **Ferramentas**: Visual Studio Code

---

## Funcionalidades Implementadas

- Cadastro de itens com validações (nome, categoria, preço, quantidade)
- Listagem de todos os itens
- Busca por código
- Atualização de estoque
- Remoção de itens
- Validações de negócio (preço negativo, quantidade negativa, etc.)
- Documentação interativa via Swagger

---

## Estrutura do Projeto
/
├── Controllers/          # Controladores da API
├── Models/               # Entidades e DTOs
├── Repositories/         # Camada de repositório
├── Services/             # Regras de negócio
├── Data/                 # Contexto do EF Core
├── Migrations/           # Migrações do Entity Framework
├── Textos e Prints/      # Evidências e documentação
├── bin/ e obj/           # Arquivos compilados
├── estoque.db            # Banco de dados SQLite
└── projeto API Estoque ASS.csproj


---

## Como Executar o Projeto

### Pré-requisitos
- .NET 10.0 SDK instalado

### Passos

```bash
# 1. Clone o repositório
git clone https://github.com/Jaime-Guilherme/API-Estoque-ASS-POO.git

# 2. Entre na pasta
cd API-Estoque-ASS-POO

# 3. Execute o projeto
dotnet run
A API estará disponível em: https://localhost:5001 ou http://localhost:5000
Acesse o Swagger em:
https://localhost:5001/swagger

Endpoints Principais

Método,Endpoint,Descrição
GET,/api/itens,Listar todos os itens
GET,/api/itens/{codigo},Buscar item por código
POST,/api/itens,Cadastrar novo item
PUT,/api/itens/{codigo},Atualizar item
DELETE,/api/itens/{codigo},Remover item

Autor

Nome: Jaime Guilherme
Disciplina: Programação Orientada a Objetos
Data de Entrega: Maio/2026


Licença
Projeto desenvolvido para fins acadêmicos.