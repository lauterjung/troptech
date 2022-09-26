USE master
GO

DROP DATABASE IF EXISTS SERRAAIRLINESDB;
GO

CREATE DATABASE SERRAAIRLINESDB;
GO

USE SERRAAIRLINESDB
GO

CREATE TABLE Enderecos
(
    id_endereco INT IDENTITY(1, 1) NOT NULL,
    cep VARCHAR(10) NOT NULL,
    rua VARCHAR(100) NOT NULL,
    bairro VARCHAR(50) NOT NULL,
    numero INT NOT NULL,
    complemento VARCHAR(100) NULL,
    CONSTRAINT PK_id_endereco PRIMARY KEY (id_endereco)
);

CREATE TABLE Clientes
(
    cpf VARCHAR(11) NOT NULL,
    nome VARCHAR(100) NOT NULL,
    sobrenome VARCHAR(100) NOT NULL,
    nome_completo VARCHAR(200) NOT NULL,
    id_endereco INT NOT NULL,
    CONSTRAINT PK_cpf PRIMARY KEY (cpf),
    CONSTRAINT FK_Clientes_Enderecos FOREIGN KEY (id_endereco) REFERENCES Enderecos (id_endereco)
);

CREATE TABLE Passagens
(
    id_passagem INT IDENTITY(1, 1) NOT NULL,
    origem VARCHAR(100) NOT NULL,
    destino VARCHAR(100) NOT NULL,
    valor DECIMAL(36, 2) NOT NULL,
    data_hora_origem DATETIME2 NOT NULL,
    data_hora_destino DATETIME2 NOT NULL,
    passagem_vinculada BIT NOT NULL,
    CONSTRAINT PK_id_passagem PRIMARY KEY (id_passagem),
);

CREATE TABLE Viagens
(
    codigo VARCHAR(6) NOT NULL,
    data_hora_compra DATETIME2 NOT NULL,
    valor_total DECIMAL(36, 2) NOT NULL,
    cpf VARCHAR(11) NOT NULL,
    direcao INT NOT NULL,
    id_passagem_ida INT NOT NULL,
    id_passagem_volta INT NULL,
    CONSTRAINT PK_codigo PRIMARY KEY (codigo),
    CONSTRAINT FK_Viagens_Clientes FOREIGN KEY (cpf) REFERENCES Clientes (cpf),
    CONSTRAINT FK_Viagens_Passagens_Ida FOREIGN KEY (id_passagem_ida) REFERENCES Passagens (id_passagem),
    CONSTRAINT FK_Viagens_Passagens_Volta FOREIGN KEY (id_passagem_volta) REFERENCES Passagens (id_passagem)
);

INSERT INTO Enderecos
VALUES
    ('88012012', 'Rua A B C', 'Bairro A', 1, 'Apto. 1'),
    ('88012012', 'Rua A B C', 'Bairro A', 2, NULL),
    ('88013013', 'Rua D E F', 'Bairro D', 200, 'Bloco B'),
    ('88013013', 'Rua D E F', 'Bairro D', 400, NULL),
    ('88014014', 'Rua G H I', 'Bairro G', 100, 'Apto. 2'),
    ('88014014', 'Rua G H I', 'Bairro G', 107, NULL),
    ('88015015', 'Rua J K L', 'Bairro J', 2, 'Apto. 3'),
    ('88015015', 'Rua J K L', 'Bairro J', 4, NULL),
    ('88016016', 'Rua M N O', 'Bairro M', 55, 'Apto. 4'),
    ('88016016', 'Rua M N O', 'Bairro M', 66, NULL);

INSERT INTO Clientes
VALUES
    ('00000000001', 'Miguel', 'Sobrenome1', 'Miguel Sobrenome1', 1),
    ('00000000002', 'Helena', 'Sobrenome2', 'Helena Sobrenome2', 1),
    ('00000000003', 'Arthur', 'Sobrenome3', 'Arthur Sobrenome3', 3),
    ('00000000004', 'Alice', 'Sobrenome4', 'Alice Sobrenome4', 4),
    ('00000000005', 'Gael', 'Sobrenome5', 'Gael Sobrenome5', 5),
    ('00000000006', 'Laura', 'Sobrenome6', 'Laura Sobrenome6', 6),
    ('00000000007', 'Heitor', 'Sobrenome7', 'Heitor Sobrenome7', 7),
    ('00000000008', 'Maria Alice', 'Sobrenome8', 'Maria Alice Sobrenome8', 8),
    ('00000000009', 'Theo', 'Sobrenome9', 'Theo Sobrenome9', 9),
    ('00000000010', 'Valentina', 'Sobrenome10', 'Valentina Sobrenome10', 10);

INSERT INTO Passagens
VALUES
    ('Cidade A', 'Cidade B', 1000, '2022-09-01 03:00:00', '2022-09-01 06:00:00', 1),
    ('Cidade B', 'Cidade A', 1000, '2022-09-02 03:00:00', '2022-09-02 06:00:00', 1),
    ('Cidade A', 'Cidade C', 2000, '2022-09-03 03:00:00', '2022-09-03 13:00:00', 1),
    ('Cidade C', 'Cidade A', 2000, '2022-09-04 03:00:00', '2022-09-04 13:00:00', 1),
    ('Cidade B', 'Cidade C', 700, '2022-09-05 03:00:00', '2022-09-05 10:00:00', 1),
    ('Cidade C', 'Cidade B', 700, '2022-09-06 03:00:00', '2022-09-06 10:00:00', 1),
    ('Cidade D', 'Cidade E', 3000, '2022-09-07 03:00:00', '2022-09-07 16:00:00', 1),
    ('Cidade E', 'Cidade D', 3000, '2022-09-08 03:00:00', '2022-09-08 16:00:00', 1),
    ('Cidade A', 'Cidade D', 9000, '2022-09-09 03:00:00', '2022-09-09 20:00:00', 1),
    ('Cidade A', 'Cidade E', 5000, '2022-09-10 03:00:00', '2022-09-11 12:00:00', 1),
    ('Cidade X', 'Cidade Y', 1000, '2022-09-10 03:00:00', '2022-09-12 12:00:00', 0),
    ('Cidade Y', 'Cidade X', 1000, '2022-09-12 03:00:00', '2022-09-13 12:00:00', 0);

INSERT INTO Viagens
VALUES
    ('AAAAAA', '2022-08-01 10:00:00', 2000, '00000000001', 1, 1, 2),
    ('BBBBBB', '2022-08-02 10:00:00', 4000, '00000000001', 1, 3, 4),
    ('CCCCCC', '2022-08-03 10:00:00', 1400, '00000000001', 1, 5, 6),
    ('DDDDDD', '2022-08-04 10:00:00', 6000, '00000000002', 1, 7, 8),
    ('EEEEEE', '2022-08-05 10:00:00', 9000, '00000000003', 0, 9, NULL),
    ('FFFFFF', '2022-08-06 10:00:00', 5000, '00000000004', 0, 10, NULL);
