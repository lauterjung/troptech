USE master
GO

DROP DATABASE IF EXISTS MERCADOSEUZEDB;
GO

CREATE DATABASE MERCADOSEUZEDB;
GO

USE MERCADOSEUZEDB
GO

CREATE TABLE Produtos
(
    produto_id INT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(100) NOT NULL,
    descricao VARCHAR(500) NOT NULL,
    data_vencimento DATE NOT NULL,
    preco_unitario DECIMAL(38, 2) NOT NULL,
    unidade VARCHAR(10) NOT NULL,
    quantidade_estoque INT NOT NULL,
    CONSTRAINT PK_ENDERECO_ID PRIMARY KEY (produto_id),
)

select * from Produtos