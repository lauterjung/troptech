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

CREATE TABLE Customers
(
    customer_id INT IDENTITY(1, 1) NOT NULL,
    cpf VARCHAR(11) NOT NULL UNIQUE,
    full_name VARCHAR(200) NOT NULL,
    birth_date DATE NOT NULL,
    customer_address VARCHAR(500) NOT NULL,
    fidelity_points INT NOT NULL,
    has_fidelity_discount BIT NOT NULL,
    CONSTRAINT PK_customer_id PRIMARY KEY (customer_id),
);

CREATE TABLE Products
(
    product_id INT IDENTITY(1, 1) NOT NULL,
    product_name VARCHAR(200) NOT NULL,
    product_description VARCHAR(400) NOT NULL,
    is_active BIT NOT NULL,
    expiration_date DATE NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(36,2) NOT NULL,
    total_price DECIMAL(36,2) NOT NULL,
    CONSTRAINT PK_product_id PRIMARY KEY (product_id),
);


CREATE TABLE Orders
(
    order_id INT IDENTITY(1, 1) NOT NULL,
    order_status INT NOT NULL,
    client_cpf INT NULL,
    product_id INT NOT NULL,
    order_date_time DATETIME2 NOT NULL,
    total_price DECIMAL(36,2) NOT NULL,
    CONSTRAINT PK_order_id PRIMARY KEY (order_id),
);

CREATE TABLE ProductsToOrders
(
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    CONSTRAINT FK_ProductsToOrders_Orders FOREIGN KEY (order_id) REFERENCES Orders (order_id),
    CONSTRAINT FK_ProductsToOrders_Products FOREIGN KEY (product_id) REFERENCES Products (product_id)
)

-----------------------------------------------------------------------------------------------------
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

INSERT INTO Products
VALUES
    ('Água s/ gás 500 ml', 'Água mineral Puris 500 ml sem gás', 1, '2025-01-01', 100, 3.50, 350),
    ('Água c/ gás 500 ml', 'Água mineral Puris 500 ml com gás', 1, '2025-01-01', 100, 3.50, 350),
    ('Refrigerante Laranjinha 500 ml', 'Refrigerante Água da Serra sabor Laranjinha 500 ml', 1, '2025-01-01', 100, 6.50, 650),
    ('Refrigerante Guaraná 500 ml', 'Refrigerante Água da Serra sabor Guaraná 500 ml', 1, '2025-01-01', 100, 6.50, 650),
    ('Refrigerante Cola 500 ml', 'Refrigerante Coca-Cola sabor Cola 500 ml', 1, '2025-01-01', 100, 8.50, 850),
    ('Água c/ gás 500 ml', 'Água mineral Puris 500 ml com gás', 1, '2025-01-01', 100, 3.50, 350),
    ('Água c/ gás 500 ml', 'Água mineral Puris 500 ml com gás', 1, '2025-01-01', 100, 3.50, 350),
    ('Pizza Média - Marguerita', 'Pizza tamanho média sabor Marguerita', 1, '2023-12-31', 20, 40, 800),
    ('Pizza Grande - Marguerita', 'Pizza tamanho grande sabor Marguerita', 1, '2023-12-31', 20, 60, 1200),
    ('Pizza Gigante - Marguerita', 'Pizza tamanho grande sabor Marguerita', 1, '2023-12-31', 20, 80, 1600),
    ('Pizza Média - Calabresa', 'Pizza tamanho média sabor Calabresa', 1, '2023-12-31', 20, 40, 800),
    ('Pizza Grande - Calabresa', 'Pizza tamanho grande sabor Calabresa', 1, '2023-12-31', 20, 60, 1200),
    ('Pizza Gigante - Calabresa', 'Pizza tamanho grande sabor Calabresa', 1, '2023-12-31', 20, 80, 1600);

-----------------------------------------------------------------------------


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
--------------------------------
-- CREATE TABLE Ingredients
-- (
--     ingredient_id INT IDENTITY(1, 1) NOT NULL,
--     ingredient_name VARCHAR(200) NOT NULL,
--     quantity DECIMAL(36, 2) NOT NULL,
--     quantity_unit VARCHAR(20) NOT NULL,
--     CONSTRAINT PK_ingredient_id PRIMARY KEY (ingredient_id)
-- );

-- CREATE TABLE Toppings
-- (
--     topping_id INT IDENTITY(1, 1) NOT NULL,
--     topping_name VARCHAR(200) NOT NULL,
--     topping_type VARCHAR(20) NOT NULL,
--     CONSTRAINT topping_id PRIMARY KEY (topping_id)
-- );

-- CREATE TABLE IngredientsToToppings
-- (
--     topping_id INT NOT NULL,
--     ingredient_id INT NOT NULL,
--     used_quantity DECIMAL(36, 2) NOT NULL,
--     CONSTRAINT FK_Conversion_Ingredients FOREIGN KEY (ingredient_id) REFERENCES Ingredients (ingredient_id),
--     CONSTRAINT FK_Conversion_Toppings FOREIGN KEY (topping_id) REFERENCES Toppings (topping_id)
-- )

-----------------------------------------------------------------------------

-- INSERT INTO Ingredients
-- VALUES
--     ('Molho de tomate', 100, 'u'),
--     ('Queijo', 100, 'u'),
--     ('Orégano', 100, 'u'),
--     ('Calabresa', 100, 'u'),
--     ('Tomate', 100, 'u'),
--     ('Manjericão', 100, 'u');

-- INSERT INTO Toppings
-- VALUES
--     ('Marguerita', 'Tradicional'),
--     ('Calabresa', 'Tradicional');

-- INSERT INTO IngredientsToToppings
-- VALUES
--     (1, 1, 1),
--     (1, 2, 1),
--     (1, 3, 1),
--     (1, 5, 1),
--     (1, 6, 1),
--     (2, 1, 1),
--     (2, 2, 1),
--     (2, 3, 1),
--     (2, 4, 1);

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


select *
from Products

SELECT *
FROM Products
WHERE product_name = 'Água s/ gás 500 ml' AND product_description = 'Água mineral Puris 500 ml sem gás' AND expiration_date = '2025-01-01'

