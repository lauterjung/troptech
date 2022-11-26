
-----------------------------------------------------------------------------------------------------



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
