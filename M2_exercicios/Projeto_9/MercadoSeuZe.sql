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
    produto_id BIGINT IDENTITY(1,1) NOT NULL,
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
    cpf VARCHAR(20) NOT NULL,
    nome VARCHAR(200) NOT NULL,
    data_nascimento DATE NOT NULL,
    pontos_fidelidade DECIMAL(38, 2) NULL,
    rua VARCHAR(50) NOT NULL,
    numero_da_casa INT NOT NULL,
    bairro VARCHAR(50) NOT NULL,
    cep VARCHAR(10) NOT NULL,
    complemento VARCHAR(50) NULL,
    CONSTRAINT PK_cliente_id PRIMARY KEY (cpf),
)

CREATE TABLE Pedidos
(
    pedido_id BIGINT IDENTITY(1,1) NOT NULL,
    data_pedido DATE NOT NULL,
    hora TIME NULL,
    produto_id BIGINT NOT NULL,
    quantidade_produto INT NOT NULL,
    valor_total DECIMAL(38,2) NOT NULL,
    cpf_cliente VARCHAR(20) NULL,
    CONSTRAINT PK_pedido_id PRIMARY KEY (pedido_id),
    CONSTRAINT FK_pedidos_produtos FOREIGN KEY (produto_id) REFERENCES Produtos (produto_id),
    CONSTRAINT FK_pedidos_clientes FOREIGN KEY (cpf_cliente) REFERENCES Clientes (cpf)
)

INSERT INTO Produtos
VALUES
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

INSERT INTO Clientes
VALUES
    ('1', 'Teste', '1992-01-01', NULL, 'Av. ABC', 1, 'Conta Dinheiro', '88.888.888', NULL),
    ('00000000001', 'Miguel', '1992-01-01', NULL, 'Av. ABC', 1, 'Conta Dinheiro', '88.888.888', NULL),
    ('00000000002', 'Helena', '1992-02-01', NULL, 'Av. ABC', 2, 'Conta Dinheiro', '88.888.888', NULL),
    ('00000000003', 'Arthur', '1992-03-01', 38, 'Av. ABC', 3, 'Conta Dinheiro', '88.888.888', NULL),
    ('00000000004', 'Alice', '1992-04-01', NULL, 'Av. DEF', 1, 'Conta Dinheiro', '99.999.999', NULL),
    ('00000000005', 'Gael', '1992-05-05', 95, 'Av. DEF', 2, 'Conta Dinheiro', '99.999.999', NULL),
    ('00000000006', 'Laura', '1992-06-06', NULL, 'Av. DEF', 3, 'Conta Dinheiro', '99.999.999', NULL),
    ('00000000007', 'Heitor', '1992-07-07', NULL, 'Av. GHI', 1, 'Conta Dinheiro', '88.000.888', NULL),
    ('00000000008', 'Maria Alice', '1992-08-08', NULL, 'Av. JKL', 1, 'Conta Dinheiro', '88.111.111', NULL),
    ('00000000009', 'Theo', '1992-09-09', NULL, 'Av. JKL', 2, 'Conta Dinheiro', '88.111.111', NULL),
    ('00000000010', 'Valentina', '1992-10-10', NULL, 'Av. JKL', 3, 'Conta Dinheiro', '88.111.111', NULL);

INSERT INTO Pedidos
VALUES
    ('2022-08-18', '13:55:22', 1, 1, 5.25, '00000000001'),
    ('2022-08-17', '13:56:22', 2, 1, 6.75, '00000000001'),
    ('2022-08-16', '13:57:22', 3, 1, 7.52, '00000000001'),
    ('2022-08-16', '13:58:22', 6, 1, 0.40, '00000000002'),
    ('2022-08-17', '13:59:22', 5, 1, 4.25, '00000000003'),
    ('2022-08-18', '13:00:22', 6, 1, 0.40, '00000000004'),
    ('2022-08-18', '14:55:22', 6, 1, 0.40, '00000000005'),
    ('2022-08-15', '15:55:22', 6, 1, 0.40, '00000000006'),
    ('2022-08-14', '16:55:22', 7, 1, 5.20, '00000000007'),
    ('2022-08-18', '17:55:22', 8, 1, 10.25, '00000000008')
    
SELECT *
FROM Produtos;
SELECT *
FROM Clientes;
SELECT *
FROM Pedidos;

SELECT pd.pedido_id, p.nome AS produto, pd.quantidade_produto, pd.valor_total, c.nome AS cliente, pd.data_pedido, pd.hora
FROM Pedidos pd
    JOIN Clientes c ON (c.cpf = pd.cpf_cliente)
    JOIN Produtos p ON (pd.produto_id = p.produto_id);
