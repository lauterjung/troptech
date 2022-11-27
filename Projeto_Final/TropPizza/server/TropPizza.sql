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
-----------------------------------------------------------------------------------------------------
CREATE TABLE Customers
(
    customer_id BIGINT IDENTITY(1, 1) NOT NULL,
    cpf VARCHAR(11) NOT NULL UNIQUE,
    full_name VARCHAR(200) NOT NULL,
    birth_date DATE NOT NULL,
    customer_address VARCHAR(500) NOT NULL,
    fidelity_points DECIMAL(36,2) NOT NULL,
    CONSTRAINT PK_customer_id PRIMARY KEY (customer_id),
);

INSERT INTO Customers
VALUES
    ('00000000001', 'Miguel Sobrenome1', '1990-01-21', 'Endereço 1', 1),
    ('00000000002', 'Helena Sobrenome2', '1990-01-22', 'Endereço 2', 2),
    ('00000000003', 'Arthur Sobrenome3', '1990-01-21', 'Endereço 3', 3),
    ('00000000004', 'Alice Sobrenome4', '1990-01-21', 'Endereço 4', 4),
    ('00000000005', 'Gael Sobrenome5', '1990-01-21', 'Endereço 5', 5),
    ('00000000006', 'Laura Sobrenome6', '1990-01-21', 'Endereço 6', 6),
    ('00000000007', 'Heitor Sobrenome7', '1990-01-21', 'Endereço 7', 7),
    ('00000000008', 'Maria Alice Sobrenome8', '1990-01-21', 'Endereço 8', 8),
    ('00000000009', 'Theo Sobrenome9', '1990-01-21', 'Endereço 9', 9),
    ('00000000010', 'Valentina Sobrenome10', '1990-01-21', 'Endereço 10', 0);
-----------------------------------------------------------------------------------------------------
CREATE TABLE Products
(
    product_id BIGINT IDENTITY(1, 1) NOT NULL,
    product_name VARCHAR(200) NOT NULL,
    product_description VARCHAR(400) NOT NULL,
    is_active BIT NOT NULL,
    expiration_date DATE NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(36,2) NOT NULL,
    total_price DECIMAL(36,2) NOT NULL,
    is_visible BIT NOT NULL,
    image_path VARCHAR(255) NULL,
    CONSTRAINT PK_product_id PRIMARY KEY (product_id),
);

INSERT INTO Products
VALUES
    ('Água s/ gás 500 ml', 'Água mineral Puris 500 ml sem gás', 1, '2025-01-01', 10000, 3.50, 350, 1, NULL),
    ('Água c/ gás 500 ml', 'Água mineral Puris 500 ml com gás', 1, '2025-01-01', 10000, 3.50, 350, 1, NULL),
    ('Refrigerante Laranjinha 500 ml', 'Refrigerante Água da Serra sabor Laranjinha 500 ml', 1, '2025-01-01', 10000, 6.50, 650, 1, NULL),
    ('Refrigerante Guaraná 500 ml', 'Refrigerante Água da Serra sabor Guaraná 500 ml', 1, '2025-01-01', 10000, 6.50, 650, 1, NULL),
    ('Refrigerante Cola 500 ml', 'Refrigerante Coca-Cola sabor Cola 500 ml', 1, '2025-01-01', 10000, 8.50, 850, 1, NULL),
    ('Água c/ gás 500 ml', 'Água mineral Puris 500 ml com gás', 1, '2025-01-01', 10000, 3.50, 350, 1, NULL),
    ('Água c/ gás 500 ml', 'Água mineral Puris 500 ml com gás', 1, '2025-01-01', 10000, 3.50, 350, 1, NULL),
    ('Pizza Média - Marguerita', 'Pizza tamanho média sabor Marguerita', 1, '2023-12-31', 20, 40, 800, 1, NULL),
    ('Pizza Grande - Marguerita', 'Pizza tamanho grande sabor Marguerita', 1, '2023-12-31', 20, 60, 1200, 1, NULL),
    ('Pizza Gigante - Marguerita', 'Pizza tamanho grande sabor Marguerita', 1, '2023-12-31', 20, 80, 1600, 1, NULL),
    ('Pizza Média - Calabresa', 'Pizza tamanho média sabor Calabresa', 1, '2023-12-31', 20, 40, 800, 1, NULL),
    ('Pizza Grande - Calabresa', 'Pizza tamanho grande sabor Calabresa', 1, '2023-12-31', 20, 60, 1200, 1, NULL),
    ('Pizza Gigante - Calabresa', 'Pizza tamanho grande sabor Calabresa', 1, '2023-12-31', 20, 80, 1600, 1, NULL);
-----------------------------------------------------------------------------------------------------
CREATE TABLE OrderStatus
(
    order_status_id SMALLINT IDENTITY(0, 1) NOT NULL,
    order_status_name VARCHAR(20) NOT NULL,
    CONSTRAINT PK_order_status_id PRIMARY KEY (order_status_id),
);

INSERT INTO OrderStatus
VALUES
    ('Pendente'),
    ('Em preparo'),
    ('Delivery'),
    ('Finalizado');
-----------------------------------------------------------------------------------------------------
CREATE TABLE Orders
(
    order_id BIGINT IDENTITY(1, 1) NOT NULL,
    order_status_id SMALLINT NOT NULL,
    customer_cpf VARCHAR(11) NULL,
    order_date_time DATETIME2 NOT NULL,
    CONSTRAINT PK_order_id PRIMARY KEY (order_id),
    -- CONSTRAINT FK_orders_customer FOREIGN KEY (customer_cpf) REFERENCES Customers (cpf),
    CONSTRAINT FK_orders_orderstatus FOREIGN KEY (order_status_id) REFERENCES OrderStatus (order_status_id),
);

INSERT INTO Orders
VALUES
    (3, NULL, '2023-11-21 14:00:00'),
    (3, NULL, '2023-11-21 15:00:00'),
    (3, '00000000001', '2023-11-21 16:00:00'),
    (3, '00000000002', '2023-11-21 17:00:00'),
    (3, '00000000003', '2023-11-21 18:00:00'),
    (0, NULL, '2023-11-21 20:00:00'),
    (0, NULL, '2023-11-21 19:00:00'),
    (0, '00000000001', '2023-11-21 18:00:00'),
    (1, '00000000002', '2023-11-21 17:00:00'),
    (2, '00000000003', '2023-11-21 16:00:00');
-----------------------------------------------------------------------------------------------------
CREATE TABLE OrderProducts
(
    order_id BIGINT NOT NULL,
    product_id BIGINT NOT NULL,
    quantity INT NOT NULL,
    total_price DECIMAL(36,2) NOT NULL,
    CONSTRAINT FK_OrderProducts_Orders FOREIGN KEY (order_id) REFERENCES Orders (order_id),
    CONSTRAINT FK_OrderProducts_Products FOREIGN KEY (product_id) REFERENCES Products (product_id)
)

INSERT INTO OrderProducts
VALUES
-- pedido / produto / quantidade / preço
    (1, 1, 2, 7),
    (2, 1, 1, 3.5),
    (2, 2, 1, 3.5),
    (3, 1, 1, 3.5),
    (3, 2, 1, 3.5),
    (3, 8, 1, 40),
    (4, 1, 2, 7),
    (4, 2, 2, 7),
    (4, 8, 2, 80),
    (5, 1, 2, 7),
    (6, 1, 2, 7),
    (7, 1, 2, 7),
    (8, 1, 2, 7),
    (9, 1, 2, 7),
    (10, 1, 2, 7);
-----------------------------------------------------------------------------------------------------
select *
from Customers

select *
from Products

SELECT *
FROM Products
WHERE product_name = 'Água s/ gás 500 ml' AND product_description = 'Água mineral Puris 500 ml sem gás' AND expiration_date = '2025-01-01'

SELECT p.product_id, p.product_name, p.unit_price, op.quantity, op.total_price
                    FROM OrderProducts op
                    JOIN Orders o ON(op.order_id = o.order_id)
                    JOIN Products p ON(op.product_id = p.product_id)
                        WHERE op.order_id = 3