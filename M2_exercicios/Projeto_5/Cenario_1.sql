USE [master]
GO

DROP DATABASE IF EXISTS CONTADELUZDB;
CREATE DATABASE CONTADELUZDB;
GO

USE CONTADELUZDB;
GO

CREATE TABLE Contas
(
    [data] DATE NOT NULL,
    numero_leitura INT NOT NULL,
    kw_gasto DECIMAL(5,4) NOT NULL,
    valor_a_pagar DECIMAL(10,2) NOT NULL,
    data_pagamento DATE NOT NULL,
    media_consumo DECIMAL(5,4) NOT NULL,
);
GO

ALTER TABLE Contas ALTER COLUMN
	kw_gasto DECIMAL(10,4) NOT NULL;

ALTER TABLE Contas ALTER COLUMN
    media_consumo DECIMAL(10,4) NOT NULL;

EXEC sp_rename 'Contas.data', 'data_leitura', 'COLUMN';
EXEC sp_rename 'Contas.valor_a_pagar', 'valor_da_conta', 'COLUMN';
GO

-- USE [master]
-- GO
-- DROP DATABASE CONTADELUZDB;
