USE master
GO

DROP DATABASE IF EXISTS TROPPIZZADB;
GO

CREATE DATABASE TROPPIZZADB;
GO

USE TROPPIZZADB
GO

SET DATEFORMAT ymd;  
GO

-- CREATE TABLE Enderecos
-- (
--     id_endereco INT IDENTITY(1, 1) NOT NULL,
--     cep VARCHAR(10) NOT NULL,
--     rua VARCHAR(100) NOT NULL,
--     bairro VARCHAR(50) NOT NULL,
--     numero INT NOT NULL,
--     complemento VARCHAR(100) NULL,
--     CONSTRAINT PK_id_endereco PRIMARY KEY (id_endereco)
-- );

CREATE TABLE Customers
(
    client_id VARCHAR(11) NOT NULL,
    full_name VARCHAR(200) NOT NULL,
    birth_date DATETIME2 NOT NULL,
    client_address VARCHAR(500) NOT NULL,
    fidelity_points INT NOT NULL,
    has_fidelity_discount BIT NOT NULL,
    CONSTRAINT PK_client_id PRIMARY KEY (client_id),
);

--------------------------------
CREATE TABLE Ingredients
(
    ingredient_id INT IDENTITY(1, 1) NOT NULL,
    ingredient_name VARCHAR(200) NOT NULL,
    quantity DECIMAL(36, 2) NOT NULL,
    quantity_unit VARCHAR(20) NOT NULL,
    CONSTRAINT PK_ingredient_id PRIMARY KEY (ingredient_id)
);

CREATE TABLE Toppings
(
    topping_id INT IDENTITY(1, 1) NOT NULL,
    topping_name VARCHAR(200) NOT NULL,
    topping_type VARCHAR(20) NOT NULL,
    CONSTRAINT topping_id PRIMARY KEY (topping_id)
);

CREATE TABLE IngredientsToToppings
(
    topping_id INT NOT NULL,
    ingredient_id INT NOT NULL,
    used_quantity DECIMAL(36, 2) NOT NULL,
    CONSTRAINT FK_Conversion_Ingredients FOREIGN KEY (ingredient_id) REFERENCES Ingredients (ingredient_id),
    CONSTRAINT FK_Conversion_Toppings FOREIGN KEY (topping_id) REFERENCES Toppings (topping_id)
)

-----------------------------------------------------------------------------
INSERT INTO Customers
VALUES
    ('00000000001', 'Miguel Sobrenome1', '1990-01-21', 'Endereço 1', 1, 0),
    ('00000000002', 'Helena Sobrenome2', '1990-01-22', 'Endereço 2', 2, 0),
    ('00000000003', 'Arthur Sobrenome3', '1990-01-21', 'Endereço 3', 3, 0),
    ('00000000004', 'Alice Sobrenome4', '1990-01-21', 'Endereço 4', 4, 0),
    ('00000000005', 'Gael Sobrenome5', '1990-01-21', 'Endereço 5', 5, 0),
    ('00000000006', 'Laura Sobrenome6', '1990-01-21', 'Endereço 6', 6, 0),
    ('00000000007', 'Heitor Sobrenome7', '1990-01-21', 'Endereço 7', 7, 0),
    ('00000000008', 'Maria Alice Sobrenome8', '1990-01-21', 'Endereço 8', 8, 0),
    ('00000000009', 'Theo Sobrenome9', '1990-01-21', 'Endereço 9', 9, 0),
    ('00000000010', 'Valentina Sobrenome10', '1990-01-21', 'Endereço 10', 0, 0);

-----------------------------------------------------------------------------
INSERT INTO Ingredients
VALUES
    ('Molho de tomate', 100, 'u'),
    ('Queijo', 100, 'u'),
    ('Orégano', 100, 'u'),
    ('Calabresa', 100, 'u'),
    ('Tomate', 100, 'u'),
    ('Manjericão', 100, 'u');

INSERT INTO Toppings
VALUES
    ('Marguerita', 'Tradicional'),
    ('Calabresa', 'Tradicional');

INSERT INTO IngredientsToToppings
VALUES
    (1, 1, 1),
    (1, 2, 1),
    (1, 3, 1),
    (1, 5, 1),
    (1, 6, 1),
    (2, 1, 1),
    (2, 2, 1),
    (2, 3, 1),
    (2, 4, 1);

-- CREATE TABLE Passagens
-- (
--     id_passagem INT IDENTITY(1, 1) NOT NULL,
--     origem VARCHAR(100) NOT NULL,
--     destino VARCHAR(100) NOT NULL,
--     valor DECIMAL(36, 2) NOT NULL,
--     data_hora_origem DATETIME2 NOT NULL,
--     data_hora_destino DATETIME2 NOT NULL,
--     passagem_vinculada BIT NOT NULL,
--     CONSTRAINT PK_id_passagem PRIMARY KEY (id_passagem),
-- );

-- CREATE TABLE Viagens
-- (
--     codigo VARCHAR(6) NOT NULL,
--     data_hora_compra DATETIME2 NOT NULL,
--     valor_total DECIMAL(36, 2) NOT NULL,
--     cpf VARCHAR(11) NOT NULL,
--     direcao INT NOT NULL,
--     id_passagem_ida INT NOT NULL,
--     id_passagem_volta INT NULL,
--     CONSTRAINT PK_codigo PRIMARY KEY (codigo),
--     CONSTRAINT FK_Viagens_Clientes FOREIGN KEY (cpf) REFERENCES Clientes (cpf),
--     CONSTRAINT FK_Viagens_Passagens_Ida FOREIGN KEY (id_passagem_ida) REFERENCES Passagens (id_passagem),
--     CONSTRAINT FK_Viagens_Passagens_Volta FOREIGN KEY (id_passagem_volta) REFERENCES Passagens (id_passagem)
-- );

-- INSERT INTO Enderecos
-- VALUES
--     ('88012012', 'Rua A B C', 'Bairro A', 1, 'Apto. 1'),
--     ('88012012', 'Rua A B C', 'Bairro A', 2, NULL),
--     ('88013013', 'Rua D E F', 'Bairro D', 200, 'Bloco B'),
--     ('88013013', 'Rua D E F', 'Bairro D', 400, NULL),
--     ('88014014', 'Rua G H I', 'Bairro G', 100, 'Apto. 2'),
--     ('88014014', 'Rua G H I', 'Bairro G', 107, NULL),
--     ('88015015', 'Rua J K L', 'Bairro J', 2, 'Apto. 3'),
--     ('88015015', 'Rua J K L', 'Bairro J', 4, NULL),
--     ('88016016', 'Rua M N O', 'Bairro M', 55, 'Apto. 4'),
--     ('88016016', 'Rua M N O', 'Bairro M', 66, NULL);