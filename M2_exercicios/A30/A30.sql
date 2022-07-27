-- A
USE master
GO

DROP DATABASE IF EXISTS VIDEOLOCADORADB;
GO

CREATE DATABASE VIDEOLOCADORADB;
GO

USE VIDEOLOCADORADB;
GO

-- B
CREATE TABLE Locatarios
(
    locatario_id INT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(50) NOT NULL,
    endereco_completo VARCHAR(250) NOT NULL,
    data_nascimento DATE,
    CONSTRAINT PK_locatario_id PRIMARY KEY(locatario_id),
)

-- C
CREATE TABLE Categorias
(
    categoria_id BIGINT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(50) NOT NULL,
    CONSTRAINT PK_CATEGORIA_ID PRIMARY KEY(categoria_id),
)

-- D
CREATE TABLE Filmes
(
    filme_id BIGINT IDENTITY(1,1) NOT NULL,
    titulo VARCHAR(50) NOT NULL,
    ano VARCHAR(50) NOT NULL,
    categoria_id BIGINT,
    locado BIT DEFAULT 0 NOT NULL ,
    locatario_id INT NULL,
    CONSTRAINT PK_filme_id PRIMARY KEY(filme_id),
    CONSTRAINT FK_categoria_id FOREIGN KEY(categoria_id) REFERENCES Categorias(categoria_id),
    CONSTRAINT FK_locatario_id FOREIGN KEY(locatario_id) REFERENCES Locatarios(locatario_id)
)

-- E
CREATE TABLE Categorias_filmes
(
    categoria_filme_id INT IDENTITY(1,1) NOT NULL,
    categoria_id BIGINT NOT NULL,
    filme_id BIGINT NOT NULL,
    CONSTRAINT categoria_filme_id PRIMARY KEY(categoria_filme_id),
    CONSTRAINT FK_categoria_filme_id_categoria FOREIGN KEY(categoria_id) REFERENCES Categorias(categoria_id),
    CONSTRAINT FK_categoria_filme_id_filme FOREIGN KEY(filme_id) REFERENCES Filmes(filme_id),
)

-- F
INSERT INTO Locatarios
VALUES('Miguel', 'Av. Luiz de Camões, 1000, Conta Dinheiro, Lages-SC', '1992-01-01');
INSERT INTO Locatarios
VALUES('Arthur', 'Av. Luiz de Camões, 1001, Conta Dinheiro, Lages-SC', '1992-01-02');
INSERT INTO Locatarios
VALUES('Gael', 'Av. Luiz de Camões, 1002, Conta Dinheiro, Lages-SC', '1992-01-03');
INSERT INTO Locatarios
VALUES('Heitor', 'Av. Luiz de Camões, 1003, Conta Dinheiro, Lages-SC', '1992-01-04');
INSERT INTO Locatarios
VALUES('Theo', 'Av. Luiz de Camões, 1004, Conta Dinheiro, Lages-SC', '1992-01-05');
INSERT INTO Locatarios
VALUES('Davi', 'Av. Luiz de Camões, 1005, Conta Dinheiro, Lages-SC', '1992-01-06');
INSERT INTO Locatarios
VALUES('Gabriel', 'Av. Luiz de Camões, 1006, Conta Dinheiro, Lages-SC', '1992-01-07');
INSERT INTO Locatarios
VALUES('Bernardo', 'Av. Luiz de Camões, 1007, Conta Dinheiro, Lages-SC', '1992-01-08');
INSERT INTO Locatarios
VALUES('Samuel', 'Av. Luiz de Camões, 1008, Conta Dinheiro, Lages-SC', '1992-01-09');
INSERT INTO Locatarios
VALUES('João', 'Av. Luiz de Camões, 1009, Conta Dinheiro, Lages-SC', '1992-01-10');

INSERT INTO Categorias
VALUES('drama');
INSERT INTO Categorias
VALUES('acao');
INSERT INTO Categorias
VALUES('suspense');
INSERT INTO Categorias
VALUES('romance');
INSERT INTO Categorias
VALUES('aventura');
INSERT INTO Categorias
VALUES('comedia');
INSERT INTO Categorias
VALUES('terror');
INSERT INTO Categorias
VALUES('ficcao');
INSERT INTO Categorias
VALUES('documentario');
INSERT INTO Categorias
VALUES('faroeste');

INSERT INTO Filmes
VALUES('A Lista de Schindler', '1993', (SELECT TOP(1) categoria_id FROM Categorias WHERE nome = 'drama'), DEFAULT, 1);
INSERT INTO Filmes
VALUES('2001: Uma Odisséia no Espaço', '1968', 1, DEFAULT, 2);
INSERT INTO Filmes
VALUES('E.T. - O Extraterrestre', '1982', NULL, DEFAULT, 3);
INSERT INTO Filmes
VALUES('O Poderoso Chefão: Parte II', '1974', NULL, DEFAULT, 4);
INSERT INTO Filmes
VALUES('Casablanca', '1942', NULL, DEFAULT, 5);
INSERT INTO Filmes
VALUES('Pulp Fiction - Tempo de Violência', '1994', NULL, DEFAULT, 6);
INSERT INTO Filmes
VALUES('Um Sonho de Liberdade', '1994', NULL, DEFAULT, 1);
INSERT INTO Filmes
VALUES('Cidadão Kane', '1941', NULL, DEFAULT, 1);
INSERT INTO Filmes
VALUES('O Mágico de Oz', '1939', NULL, DEFAULT, 1);
INSERT INTO Filmes
VALUES('O Poderoso Chefão', '1972', NULL, DEFAULT, 1);

-- DELETE FROM Filmes
-- WHERE ano = '1993';

-- DELETE FROM Filmes
-- WHERE categoria_id = 1;

-- DELETE FROM Categorias
-- WHERE categoria_id = 1;

-- SELECT *
-- FROM Locatarios;

-- SELECT *
-- FROM Categorias;

-- SELECT *
-- FROM Filmes;