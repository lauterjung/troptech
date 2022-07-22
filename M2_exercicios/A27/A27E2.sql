CREATE DATABASE VIDEOLOCADORADB;

USE VIDEOLOCADORADB;


CREATE TABLE Categoria (
    categoria_id INT NOT NULL,
    nome VARCHAR NOT NULL,
    PRIMARY KEY(categoria_id),
)

CREATE TABLE Locatario (
    locatario_id INT NOT NULL,
    nome VARCHAR NOT NULL,
    endereco_completo VARCHAR NOT NULL,
    data_nascimento DATE,
    PRIMARY KEY(locatario_id),
)

CREATE TABLE Filme (
    filme_id INT NOT NULL,
    titulo VARCHAR NOT NULL,
    ano VARCHAR NOT NULL,
    categoria_id INT,
    locado BIT DEFAULT 0 NOT NULL ,
    locatario_id INT NOT NULL,
    PRIMARY KEY(filme_id),
    FOREIGN KEY(categoria_id) REFERENCES Categoria(categoria_id),
    FOREIGN KEY(locatario_id) REFERENCES Locatario(locatario_id)
)




