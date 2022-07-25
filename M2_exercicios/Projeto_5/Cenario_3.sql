USE [master]
GO

DROP DATABASE IF EXISTS SECRETARIADB;
CREATE DATABASE SECRETARIADB;
GO

USE SECRETARIADB;
GO

CREATE TABLE Uso_salas_reunioes
(
    hora TIME(7) NOT NULL,
    sala_1 VARCHAR(100) NULL,
    sala_2 VARCHAR(100) NULL,
    sala_3 VARCHAR(100) NULL,
);
GO

CREATE TABLE Usuarios
(
    nome VARCHAR(50) NOT NULL,
    cargo VARCHAR(50) NULL,
    ramal VARCHAR(20) NULL,
);
GO

CREATE TABLE Caracteristicas_salas
(
    sala_id INT NOT NULL,
    numero_lugares INT NOT NULL,
);
GO

ALTER TABLE Uso_salas_reunioes ALTER COLUMN
    hora TIME(0) NOT NULL;

ALTER TABLE Usuarios ALTER COLUMN
    nome VARCHAR(100) NOT NULL;

EXEC sp_rename  'Usuarios.nome', 'nome_usuario', 'COLUMN';
EXEC sp_rename  'Uso_salas_reunioes.hora', 'horario', 'COLUMN';
GO

-- USE [master]
-- GO
-- DROP DATABASE SECRETARIADB;
