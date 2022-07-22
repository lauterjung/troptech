CREATE DATABASE TROPTECHDB;

USE TROPTECHDB;

CREATE TABLE Alunos (
    nome VARCHAR NOT NULL,
    sobrenome VARCHAR NOT NULL,
    idade INT,
    turma VARCHAR,
    data_nascimento DATE NOT NULL,
    media_final FLOAT,
    porcentagem_faltas INT
);

CREATE TABLE Professores (
    nome_completo VARCHAR NOT NULL,
    data_nascimento DATE NOT NULL,
    carga_horaria INT,
    professor_autor BIT DEFAULT 0,
    endereco VARCHAR,
    valor_hora FLOAT
);
