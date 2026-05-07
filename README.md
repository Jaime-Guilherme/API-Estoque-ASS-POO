# API Estoque ASS

Sistema de Gerenciamento de Estoque para Assistência Técnica de Eletrônicos

**Disciplina:** Análise Orientada a Objetos  
**Aluno:** Jaime Guilherme Caceda  
**Data:** 06/05/2026

## Objetivo

Desenvolver uma API em ASP.NET Core que aplique os conceitos de Análise e Programação Orientada a Objetos, com ênfase no **encapsulamento** e na proteção das regras de negócio dentro da camada de domínio.

## Regras de Negócio (Protegidas por Encapsulamento)

- Preço de compra deve ser maior que zero
- Quantidade inicial não pode ser negativa
- Não é permitido realizar saída maior que o estoque disponível
- Código, Nome e Categoria são campos obrigatórios
- Todas as alterações no Item passam por métodos controlados da classe

## Tecnologias Utilizadas

- ASP.NET Core Web API
- Entity Framework Core + SQLite
- Repository Pattern
- Rich Domain Model
- DTOs (Data Transfer Objects)
- Injeção de Dependência
- Swagger para documentação

## Funcionalidades Implementadas

- Cadastro de componentes eletrônicos
- Listagem de todos os itens
- Busca por código
- Entrada de estoque
- Saída de estoque (com validação)
- Validações automáticas de regras de negócio

## Como Executar o Projeto

1. Clone o repositório
2. Abra o terminal na pasta do projeto
3. Execute os comandos:
4. dotnet restore
5. dotnet ef database update
6. dotnet run

Acesse o Swagger:
http://localhost:5000/swagger

Conceitos de Análise Orientada a Objetos Aplicados
Encapsulamento forte (private set + métodos privados de validação)
Rich Domain Model na classe Item
Separação de responsabilidades (Controller, Service, Repository)
Validações centralizadas na entidade de domínio

Autor
Jaime Guilherme Caceda
Disciplina: Análise Orientada a Objetos
