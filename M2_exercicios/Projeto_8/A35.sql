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
    CONSTRAINT PK_produto_id PRIMARY KEY (produto_id),
)

CREATE TABLE Clientes
(
    cliente_id INT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(100) NOT NULL,
    CONSTRAINT PK_cliente_id PRIMARY KEY (cliente_id),
)

-- CONSTRAINT FK_

INSERT INTO Produtos VALUES
            ('Refrigerante', 'Picolino Cola', '2022-11-15', 5.25, '2 L', 4),
            ('Pão', 'Pão de forma', '2022-08-16', 6.75, '300 g', 5),
            ('Chocolate', 'Chocolate Nestle', '2022-12-27', 7.52, '120 g', 6),
            ('Amaciante', 'Comfort', '2022-08-18', 8.25, '1 L', 7),
            ('Refrigerante', 'Picolino Guaraná', '2022-12-15', 4.25, '2 L', 9),
            ('Pão', 'Pão francês', '2022-08-10', 0.40, '1 u', 50),
            ('Chocolate', 'Chocolate Hersheys', '2022-12-10', 5.20, '120 g', 23),
            ('Sabão em pó', 'Omo', '2023-01-15', 10.25, '1 kg', 7),
            ('Refrigerante', 'Picolino Laranjinha', '2022-12-25', 4.25, '2 L', 1),
            ('Água', 'Picolino Água', '2023-05-15', 2.25, '500 mL', 6);

select * from Produtos