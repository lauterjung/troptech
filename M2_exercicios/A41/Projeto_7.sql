USE master
GO

DROP DATABASE IF EXISTS CLUBEDALEITURADB;
GO

CREATE DATABASE CLUBEDALEITURADB;
GO

USE CLUBEDALEITURADB;
GO

CREATE TABLE Revistas
(
    id_revista BIGINT IDENTITY(1,1) NOT NULL,
    tipo_colecao VARCHAR(100) NOT NULL,
    numero_edicao INT NOT NULL,
    ano_revista INT NOT NULL,
    cor_caixa VARCHAR(20) NOT NULL,
    CONSTRAINT PK_id_revista PRIMARY KEY (id_revista),
)

CREATE TABLE Amigos
(
    id_amigo BIGINT IDENTITY(1,1) NOT NULL,
    nome_amigo VARCHAR(100) NOT NULL,
    nome_mae VARCHAR(100) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    local_amigo VARCHAR(10) NOT NULL,
    CONSTRAINT PK_id_amigo PRIMARY KEY (id_amigo),
)

CREATE TABLE Emprestimos
(
    id_emprestimo BIGINT IDENTITY(1,1) NOT NULL,
    id_amigo BIGINT NOT NULL,
    id_revista BIGINT NOT NULL,
    data_emprestimo DATE NOT NULL,
    preco DECIMAL(38, 2) DEFAULT 0.0 NOT NULL,
    data_devolucao DATE NULL,
    CONSTRAINT PK_id_emprestimo PRIMARY KEY (id_emprestimo),
    CONSTRAINT FK_emprestimos_amigos FOREIGN KEY (id_amigo) REFERENCES Amigos(id_amigo),
    CONSTRAINT FK_emprestimos_revistas FOREIGN KEY (id_revista) REFERENCES Revistas(id_revista),
)

-- 2) Com o banco criado preencha o banco com 6 amigos diferentes, 10 revistas diferentes, e 10 empréstimos para os 6 amigos.
INSERT INTO Revistas
VALUES
    ('Batman', '5', 1992, 'preta'),
    ('Batman', '6', 1992, 'preta'),
    ('Batman', '7', 1992, 'preta'),
    ('Superman', '5', 1994, 'vermelha'),
    ('Superman', '8', 1994, 'vermelha'),
    ('Superman', '15', 1995, 'vermelha'),
    ('Homem Aranha', '12', 1996, 'vermelha'),
    ('Homem Aranha', '50', 2008, 'preta'),
    ('Homem Aranha', '541', 2015, 'preta'),
    ('Watchmen', '1', 2010, 'preta');

INSERT INTO Amigos
VALUES
    ('Miguel', 'Helena', '3333-1111', 'Predio'),
    ('Arthur', 'Alice', '3333-1111', 'Escola'),
    ('Gael', 'Helena', '3333-1111', 'Predio'),
    ('Heitor', 'Laura', '3333-1111', 'Predio'),
    ('Theo', 'Maria Alice', '3333-1111', 'Predio'),
    ('Davi', 'Valentina', '3333-1111', 'Escola');

INSERT INTO Emprestimos
VALUES
    (1, 1, '2022-06-10', DEFAULT, '2022-06-15'),
    (1, 2, '2022-06-10', DEFAULT, '2022-06-16'),
    (1, 3, '2022-06-14', DEFAULT, '2022-06-16'),
    (1, 4, '2022-07-10', DEFAULT, '2022-07-15'),
    (2, 1, '2022-07-10', DEFAULT, '2022-07-15'),
    (2, 2, '2022-08-10', DEFAULT, NULL),
    (2, 5, '2022-06-11', DEFAULT, '2022-06-15'),
    (3, 6, '2022-06-12', DEFAULT, NULL),
    (4, 7, '2022-06-13', DEFAULT, '2022-06-15'),
    (6, 8, '2022-06-14', DEFAULT, NULL);

-- 3) Crie um script que atualiza todos os preços dos empréstimos das revistas. Segue a lista de preços:18.25, 15.25, 11.25, 12.25, 14.25, 15.25, 17.25, 21.25, 8.25, 5.25 A edição pela ordem sequencial de cadastro. Ex: Id -> 1 Preco = 18.25...
UPDATE Emprestimos
SET preco = 
       CASE id_emprestimo
            WHEN 1 THEN 18.25
            WHEN 2 THEN 15.25
            WHEN 3 THEN 11.25
            WHEN 4 THEN 12.25
            WHEN 5 THEN 14.25
            WHEN 6 THEN 15.25
            WHEN 7 THEN 17.25
            WHEN 8 THEN 21.25
            WHEN 9 THEN 8.25
            WHEN 10 THEN 5.25
       END
WHERE id_emprestimo IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
