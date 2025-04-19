# 📦 SmartStock – Sistema de Gerenciamento de Estoque e Vendas

Sistema de console desenvolvido em **C#** com **Dapper** para gerenciar **produtos**, **clientes**, **vendas** e **estoque** de uma loja fictícia. O **SmartStock** simula uma aplicação real de gestão comercial usada por pequenas empresas.

---

## 📄 Descrição do Projeto

O **SmartStock** é um sistema focado na organização dos processos internos de uma loja, como:

- Cadastro de produtos, categorias e clientes.
- Registro de vendas com múltiplos produtos.
- Controle automático do estoque.
- Geração de relatórios através de stored procedures.

---

## 🧱 Funcionalidades do Sistema

### 🛒 Produtos e Categorias

- Cadastro, edição e remoção de **produtos**.
- Associação de cada produto a uma **categoria** (relação One-to-Many).
- Atualização de **preço** e **quantidade em estoque**.

### 👤 Clientes

- Cadastro e manutenção de clientes com **nome**, **e-mail** e **CPF**.

### 💰 Vendas

- Registro de vendas com múltiplos produtos (relação Many-to-Many).
- Cada venda contém:
  - Cliente
  - Data da venda
  - Itens (produto, quantidade, preço unitário)
  - Valor total da venda
- Atualização automática do estoque ao registrar uma venda.

### 📊 Relatórios

- Histórico de vendas por **cliente**.
- Listagem de vendas dentro de um **período específico**.
- Exibição de venda + itens com `QueryMultiple`.
- Relatórios gerados por meio de **stored procedures**.

---

## 🧠 Tecnologias e Conceitos Aplicados

### 💻 C# e Programação Orientada a Objetos (POO)

- Criação de entidades como `Produto`, `Categoria`, `Cliente`, `Venda`, `ItemVenda`.
- Uso de **interfaces** e **repositórios genéricos**.
- Aplicação do **Repository Pattern**.
- Separação do código por **camadas** (entidades, repositórios, serviços).

### 🛠️ Dapper

- Execução de comandos com `Execute`, `Query`, `QuerySingle`.
- Conexão com banco de dados via `SqlConnection`.
- Execução de **stored procedures com parâmetros**.
- Uso de **transações** ao registrar vendas.
- Relacionamentos:
  - One-to-One: `Venda -> Cliente`
  - One-to-Many: `Categoria -> Produto`
  - Many-to-Many: `Venda <-> Produto` (via `ItemVenda`)
- Evita SQL Injection com **parâmetros anônimos**.

---

## 📚 Stored Procedures Utilizadas

```sql
-- Buscar vendas por CPF
CREATE PROCEDURE sp_BuscarVendasPorCliente
    @CPF VARCHAR(14)
AS
BEGIN
    SELECT ...
END

-- Listar vendas dentro de um período
CREATE PROCEDURE sp_ListarVendasPorPeriodo
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT ...
END
