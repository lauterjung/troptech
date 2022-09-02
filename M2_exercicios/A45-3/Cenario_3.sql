USE [master]
GO

DROP DATABASE IF EXISTS SECRETARIADB;
GO

CREATE DATABASE SECRETARIADB;
GO

USE SECRETARIADB;
GO

CREATE TABLE Salas
(
    sala_id INT IDENTITY(1,1) NOT NULL,
    nome_sala VARCHAR(20) NOT NULL,
    numero_lugares INT NOT NULL,
    CONSTRAINT PK_sala_id PRIMARY KEY (sala_id),
);

CREATE TABLE Reservas
(
    reserva_id INT IDENTITY(1,1) NOT NULL,
    sala_id INT NOT NULL,
    data_hora_inicio DATETIME NOT NULL,
    data_hora_fim DATETIME NOT NULL,
    nome_funcionario VARCHAR(200) NOT NULL,
    CONSTRAINT PK_reserva_id PRIMARY KEY (reserva_id),
    CONSTRAINT FK_reserva_id_sala_id FOREIGN KEY (sala_id) REFERENCES Salas (sala_id)
);

-- CREATE TABLE Usuarios
-- (
--     nome VARCHAR(50) NOT NULL,
--     cargo VARCHAR(50) NULL,
--     ramal VARCHAR(20) NULL,
-- );

INSERT INTO Salas VALUES
('Sala_1', 50),
('Sala_2', 60),
('Sala_3', 200);

INSERT INTO Reservas VALUES
(1, '2022-09-01 13:00:00', '2022-09-01 16:00:00', 'Miguel')