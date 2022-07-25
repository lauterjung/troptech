USE [master]
GO

DROP DATABASE IF EXISTS HOSPITALDB;
CREATE DATABASE HOSPITALDB;
GO

USE HOSPITALDB;
GO

CREATE TABLE Controle_Remedios
(
    nome VARCHAR(50) NOT NULL,
    data_inicio DATE NOT NULL,
    quantidade_dias INT NOT NULL,
    n_vezes_dia INT NOT NULL,
    dosagem VARCHAR(20) NOT NULL,
    nome_remedio VARCHAR(50) NOT NULL,
);
GO

ALTER TABLE Controle_remedios ALTER COLUMN
    nome VARCHAR(100) NOT NULL;

ALTER TABLE Controle_remedios ALTER COLUMN
    n_vezes_dia SMALLINT NOT NULL;

EXEC sp_rename  'Controle_remedios.nome', 'nome_paciente', 'COLUMN';
EXEC sp_rename  'Controle_remedios.n_vezes_dia', 'vezes_ao_dia', 'COLUMN';
GO

-- USE [master]
-- GO
-- DROP DATABASE HOSPITALDB;
