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
    ('00000000001', 'Neto Rosário', '1996-12-01', 'Rua Sebastiana Pereira da Silva nº 393, Morro Grande', 1),
    ('00000000002', 'Michel Nakata', '1947-01-25', 'Rua Pero Vaz de Caminha nº 517, Guarujá', 2),
    ('00000000003', 'Heitor Lourenço', '1945-01-21', 'Rua João Lemos Cavalheiro nº 505, Popular', 3),
    ('00000000004', 'Sebastião Peres', '2001-05-02', 'Rua Tangará nº 845, Petrópolis', 4),
    ('00000000005', 'Marcelo Camargo', '1950-10-11', 'Rua Doutor Caetano Costa Júnior nº 847, Centro', 5),
    ('00000000006', 'Daiana Linhares', '2004-08-15', 'Rua José Soares Silvério nº 732, Santa Maria', 6),
    ('00000000007', 'Solange Pereira', '1960-11-14', 'Rua Xanxerê nº 270, Petrópolis', 7),
    ('00000000008', 'Gabriela Simões', '1980-12-01', 'Rua Sebastião de Camargo nº 524, Passo Fundo', 8),
    ('00000000009', 'Elza Soares', '1996-04-02', 'Rua Aliatar de Vargas Vieira nº 383, Penha', 9),
    ('00000000010', 'Isabel Paiva', '1957-06-14', 'Rua Natalício Pereira Ramos nº 420, Vila Maria', 0);
-----------------------------------------------------------------------------------------------------
CREATE TABLE InventoryProducts
(
    product_id BIGINT IDENTITY(1, 1) NOT NULL,
    product_name VARCHAR(200) NOT NULL,
    product_description VARCHAR(400) NOT NULL,
    is_active BIT NOT NULL,
    expiration_date DATE NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(36,2) NOT NULL,
    is_visible BIT NOT NULL,
    image_name VARCHAR(255) NULL,
    has_image BIT NOT NULL,
    CONSTRAINT PK_product_id PRIMARY KEY (product_id),
);

INSERT INTO InventoryProducts
VALUES
    ('Água s/ gás 500 ml', 'Água mineral Puris 500 ml sem gás', 1, '2023-06-01', 100, 4.00, 1, 'agua.jpg', 0),
    ('Água c/ gás 500 ml', 'Água mineral Puris 500 ml com gás', 1, '2023-06-01', 100, 4.00, 1, 'agua.jpg', 0),
    ('Refrigerante Laranjinha 2 L', 'Refrigerante Fanta sabor Laranjinha 2 L', 1, '2023-06-01', 100, 12.00, 1, 'fanta.jpg', 0),
    ('Refrigerante Guaraná 2 L', 'Refrigerante Antarctica sabor Guaraná 2 L', 1, '2023-06-01', 100, 12.00, 1, 'guarana.jpg', 0),
    ('Refrigerante Cola 2 L', 'Refrigerante Coca-Cola sabor Cola 2 L', 1, '2023-06-01', 100, 12.50, 1, 'coca.jpg', 0),
    ('Pizza - Azeitona', 'Pizza grande 12 fatias sabor Azeitona', 1, '2025-01-01', 20, 70, 1, 'azeitona.png', 0),
    ('Pizza - Bacon', 'Pizza grande 12 fatias sabor Bacon', 1, '2025-01-01', 20, 70, 1, 'bacon.png', 0),
    ('Pizza - Calabresa', 'Pizza grande 12 fatias sabor Calabresa', 1, '2025-01-01', 20, 70, 1, 'calabresa.png', 0),
    ('Pizza - Calabresa c/ cebola', 'Pizza grande 12 fatias sabor Calabresa c/ cebola', 1, '2025-01-01', 20, 70, 1, 'calabresa-acebolada.png', 0),
    ('Pizza - Champignon', 'Pizza grande 12 fatias sabor Champignon', 1, '2025-01-01', 20, 70, 1, 'champignon.png', 0),
    ('Pizza - Frango catupiry', 'Pizza grande 12 fatias sabor Frango catupiry', 1, '2025-01-01', 20, 70, 1, 'frango-catupiry.png', 0),
    ('Pizza - Linguiça Blumenau', 'Pizza grande 12 fatias sabor Linguiça Blumenau', 1, '2025-01-01', 20, 80, 1, 'linguiça-blumenau.png', 0),
    ('Pizza - Lombo catupiry', 'Pizza grande 12 fatias sabor Lombo catupiry', 1, '2025-01-01', 20, 70, 1, 'lombo-catupiry.png', 0),
    ('Pizza - Marguerita', 'Pizza grande 12 fatias sabor Marguerita', 1, '2025-01-01', 20, 70, 1, 'marguerita.png', 0),
    ('Pizza - Milho', 'Pizza grande 12 fatias sabor Milho', 1, '2025-01-01', 20, 70, 1, 'milho.png', 0),
    ('Pizza - Mussarela', 'Pizza grande 12 fatias sabor Mussarela', 1, '2025-01-01', 20, 70, 1, 'mussarela.png', 0),
    ('Pizza - Pepperoni', 'Pizza grande 12 fatias sabor Pepperoni', 1, '2025-01-01', 20, 80, 1, 'pepperoni.png', 0),
    ('Pizza - Portuguesa', 'Pizza grande 12 fatias sabor Portuguesa', 1, '2025-01-01', 20, 70, 1, 'portuguesa.png', 0),
    ('Pizza - Quatro queijos', 'Pizza grande 12 fatias sabor Quatro queijos', 1, '2025-01-01', 20, 70, 1, 'quatro-queijos.png', 0),
    ('Pizza - Siciliana', 'Pizza grande 12 fatias sabor Siciliana', 1, '2025-01-01', 20, 70, 1, 'siciliana.png', 0),
    ('Pizza - Tomate seco', 'Pizza grande 12 fatias sabor Tomate seco', 1, '2025-01-01', 20, 80, 1, 'tomate-seco.png', 0);
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
    ('Saiu para entrega'),
    ('Entregue');
-----------------------------------------------------------------------------------------------------
CREATE TABLE Orders
(
    order_id BIGINT IDENTITY(1, 1) NOT NULL,
    order_status_id SMALLINT NOT NULL,
    customer_id BIGINT NULL,
    order_date_time DATETIME2 NOT NULL,
    total_price DECIMAL(36,2) NOT NULL,
    CONSTRAINT PK_order_id PRIMARY KEY (order_id),
    CONSTRAINT FK_orders_customer FOREIGN KEY (customer_id) REFERENCES Customers (customer_id) ON DELETE SET NULL,
    CONSTRAINT FK_orders_orderstatus FOREIGN KEY (order_status_id) REFERENCES OrderStatus (order_status_id),
);

INSERT INTO Orders
VALUES
    (3, NULL, '2022-11-21 19:59:00', 168),
    (3, NULL, '2022-11-21 20:08:00', 148),
    (3, '00000000001', '2022-11-21 21:15:00', 92),
    (3, '00000000002', '2022-11-22 20:12:00', 94),
    (3, '00000000003', '2022-11-22 21:22:00', 82),
    (3, NULL, '2022-11-22 22:37:00', 92),
    (2, NULL, '2022-11-23 19:17:00', 106),
    (2, '00000000001', '2022-11-23 19:25:00', 78),
    (1, '00000000002', '2022-11-23 20:03:00', 218),
    (0, '00000000003', '2022-11-23 22:14:00', 70);
-----------------------------------------------------------------------------------------------------
CREATE TABLE CartProducts
(
    order_id BIGINT NOT NULL,
    product_id BIGINT NOT NULL,
    quantity INT NOT NULL,
    total_price DECIMAL(36,2) NOT NULL,
    CONSTRAINT FK_CartProducts_Orders FOREIGN KEY (order_id) REFERENCES Orders (order_id),
    -- CONSTRAINT FK_CartProducts_Products FOREIGN KEY (product_id) REFERENCES InventoryProducts (product_id)
)

INSERT INTO CartProducts
VALUES
    -- pedido / produto / quantidade / preço
    (1, 1, 2, 8),
    (1, 17, 2, 160),
    (2, 1, 1, 4),
    (2, 2, 1, 4),
    (2, 18, 1, 70),
    (2, 19, 1, 70),
    (3, 3, 1, 12),
    (3, 12, 1, 80),
    (4, 3, 2, 24),
    (4, 19, 1, 70),
    (5, 4, 1, 12),
    (5, 20, 1, 70),
    (6, 5, 1, 12),
    (6, 21, 1, 80),
    (7, 3, 3, 36),
    (7, 7, 1, 70),
    (8, 2, 2, 8),
    (8, 8, 2, 70),
    (9, 1, 2, 8),
    (9, 10, 1, 70),
    (9, 11, 1, 70),
    (9, 13, 1, 70),
    (10, 10, 1, 70);
-----------------------------------------------------------------------------------------------------
-- select *
-- from Customers

-- select *
-- from InventoryProducts

-- SELECT *
-- FROM InventoryProducts
-- WHERE product_name = 'Água s/ gás 500 ml' AND product_description = 'Água mineral Puris 500 ml sem gás' AND expiration_date = '2025-01-01'

-- SELECT p.product_id, p.product_name, p.unit_price, op.quantity, op.total_price
--                     FROM OrderProducts op
--                     JOIN Orders o ON(op.order_id = o.order_id)
--                     JOIN InventoryProducts p ON(op.product_id = p.product_id)
--                         WHERE op.order_id = 3

-- SELECT o.order_status_id, o.customer_id, o.order_date_time, c.cpf
-- FROM Orders o
--     LEFT JOIN Customers c ON (o.customer_id = c.customer_id)

-- SELECT o.order_status_id, o.customer_id, o.order_date_time, c.cpf
-- FROM Orders o
--     LEFT JOIN Customers c ON (o.customer_id = c.customer_id)
-- WHERE o.order_status_id <> 3;

-- SELECT *
-- FROM Customers
-- WHERE customer_id = 1;



-- UPDATE Orders SET 
-- order_status_id = 2
-- WHERE order_id = 1

SELECT *
FROM Orders
SELECT *
FROM InventoryProducts