CREATE DATABASE HOSPITALDB;

USE HOSPITALDB;

-- EX 1A
DROP TABLE Pacientes;

CREATE TABLE Pacientes
(
    nome VARCHAR(50) NOT NULL,
    sobrenome VARCHAR(50) NOT NULL,
    cpf BIGINT,
    endereco VARCHAR(100),
    tem_plano_saude BIT,
    nome_plano_saude VARCHAR(50),
    telefone VARCHAR(20),
    nome_mae VARCHAR(100) NOT NULL,
);

-- EX1 B
ALTER TABLE Pacientes ALTER COLUMN
	cpf BIGINT NOT NULL;

ALTER TABLE Pacientes ALTER COLUMN
    endereco VARCHAR(100) NOT NULL;

ALTER TABLE Pacientes ALTER COLUMN
    tem_plano_saude BIT NOT NULL;

ALTER TABLE Pacientes ALTER COLUMN
    telefone VARCHAR(20) NOT NULL;

ALTER TABLE Pacientes ALTER COLUMN
    nome_mae VARCHAR(100) NOT NULL;

-- EX1 C
EXEC sp_rename 'Pacientes.nome', 'nome_completo', 'COLUMN';
EXEC sp_rename 'Pacientes.endereco', 'endereco_completo';
EXEC sp_rename 'Pacientes.tem_plano_saude', 'possui_plano_saude', 'COLUMN';
EXEC sp_rename 'Pacientes.nome_mae', 'nome_completo_mae', 'COLUMN';

-- EX1 D
ALTER TABLE Pacientes DROP COLUMN sobrenome;

-- EX1 E
ALTER TABLE Pacientes ALTER COLUMN 
	nome_completo VARCHAR(255);
ALTER TABLE Pacientes ALTER COLUMN 
	nome_completo_mae VARCHAR(255);

-- EX2 A
DROP TABLE Cirurgias;

CREATE TABLE Cirurgias
(
    paciente VARCHAR(100) NOT NULL,
    medico VARCHAR(100) NOT NULL,
    [data] DATETIME2 NOT NULL,
);

-- EX2 B
EXEC sp_rename 'Cirurgias.paciente', 'nome_paciente', 'COLUMN';
EXEC sp_rename 'Cirurgias.medico', 'nome_medico', 'COLUMN';
EXEC sp_rename 'Cirurgias.data', 'data_agendada', 'COLUMN';

-- EX2 C
ALTER TABLE Cirurgias ADD
    sala_cirurgica VARCHAR(50),
    nome_cirurgia VARCHAR(50),
    requer_acompanhante BIT

-- EX2 D
ALTER TABLE Cirurgias ALTER COLUMN 
	nome_paciente NVARCHAR(100);

ALTER TABLE Cirurgias ALTER COLUMN 
	nome_medico NVARCHAR(100);