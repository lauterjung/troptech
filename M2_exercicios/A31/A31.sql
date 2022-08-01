-- EX1
USE master
GO

DROP DATABASE IF EXISTS ESTACIONAMENTODB;
GO

CREATE DATABASE ESTACIONAMENTODB;
GO

USE ESTACIONAMENTODB
GO

CREATE TABLE Clientes(
cpf BIGINT NOT NULL,
nome VARCHAR(100) NOT NULL,
data_nascimento DATE NOT NULL
CONSTRAINT PK_cpf PRIMARY KEY (cpf),
)

CREATE TABLE Modelos(
modelo_id BIGINT IDENTITY(1,1) NOT NULL,
descricao VARCHAR(250),
CONSTRAINT PK_modelo_id PRIMARY KEY (modelo_id),
)

CREATE TABLE Patios(
patio_id BIGINT IDENTITY(1,1) NOT NULL,
endereco VARCHAR(250) NOT NULL,
capacidade INT NOT NULL,
CONSTRAINT PK_patio_id PRIMARY KEY (patio_id),
)

CREATE TABLE Veiculos(
placa_id VARCHAR(10) NOT NULL,
modelo_id BIGINT NOT NULL,
cor VARCHAR(20) NOT NULL,
ano INT NOT NULL,
cpf_cliente VARCHAR(11) NOT NULL,
CONSTRAINT PK_placa_id PRIMARY KEY (placa_id),
CONSTRAINT FK_veiculos_modelos FOREIGN KEY (modelo_id) REFERENCES Modelos (modelo_id),
)

CREATE TABLE Estacionamentos(
estacionamento_id BIGINT IDENTITY(1,1) NOT NULL,
patio_id BIGINT NOT NULL,
placa_veiculo VARCHAR(10) NOT NULL,
data_entrada DATE NOT NULL,
data_saida DATE NULL,
CONSTRAINT PK_estacionamento_id PRIMARY KEY (estacionamento_id),
CONSTRAINT FK_estacionamentos_patios FOREIGN KEY (estacionamento_id) REFERENCES Patios (patio_id),
CONSTRAINT FK_estacionamentos_veiculos FOREIGN KEY (placa_veiculo) REFERENCES Veiculos (placa_id),
)

INSERT INTO Clientes
VALUES(00000000001, 'A B C', '1990-01-01');
INSERT INTO Clientes
VALUES(00000000002, 'D E F', '1990-01-02');
INSERT INTO Clientes
VALUES(00000000003, 'G H I', '1990-01-03');

INSERT INTO Modelos
VALUES('Audi');
INSERT INTO Modelos
VALUES('Chevrolet');
INSERT INTO Modelos
VALUES('Toyota');

INSERT INTO Patios
VALUES('Rua ABC', 50);
INSERT INTO Patios
VALUES('Rua DEF', 100);
INSERT INTO Patios
VALUES('Rua GHI', 200);

INSERT INTO Veiculos
VALUES('ABC-0123', 1, 'Vermelho', 1990, 00000000001);
INSERT INTO Veiculos
VALUES('DEF-0456', 1, 'Verde', 1991, 00000000002);
INSERT INTO Veiculos
VALUES('GHI-0789', 2, 'Azul', 1991, 00000000003);
INSERT INTO Veiculos
VALUES('JKL-1111', 2, 'Verde', 1993, 00000000003);

INSERT INTO Estacionamentos
VALUES(1, 'ABC-0123', '2022-01-01', NULL);
INSERT INTO Estacionamentos
VALUES(3, 'DEF-0456', '2022-01-02', '2022-01-03');
INSERT INTO Estacionamentos
VALUES(3, 'GHI-0789', '2022-01-03', NULL);

-- EX2
SELECT placa_id AS placa FROM Veiculos
UNION
SELECT nome FROM Clientes;

SELECT v.placa_id AS placa, c.nome AS nome 
FROM Veiculos v FULL JOIN Clientes c ON c.cpf = v.cpf_cliente;

-- EX3
SELECT c.cpf, c.nome
FROM Veiculos v JOIN Clientes c ON (c.cpf = v.cpf_cliente) 
WHERE v.placa_id = 'JJJ-2020';

SELECT c.cpf, c.nome
FROM Veiculos v JOIN Clientes c ON (c.cpf = v.cpf_cliente) 
WHERE v.placa_id = 'ABC-0123';

-- EX 4
SELECT v.placa_id AS placa, v.cor
FROM Estacionamentos e JOIN Veiculos v ON (e.placa_veiculo = v.placa_id) 
WHERE e.estacionamento_id = 1;

-- EX 5
SELECT v.placa_id AS placa, v.ano
FROM Estacionamentos e JOIN Veiculos v ON (e.placa_veiculo = v.placa_id) 
WHERE e.estacionamento_id = 1;

-- Ex 6
SELECT v.ano, m.descricao
FROM Veiculos v JOIN Modelos m ON (v.modelo_id = m.modelo_id) 
WHERE v.ano >= 2000;

-- Ex 7
SELECT p.endereco, e.data_entrada, e.data_saida
FROM Estacionamentos e 
JOIN Patios p ON (e.patio_id = p.patio_id)
JOIN Veiculos v ON (e.placa_veiculo = v.placa_id)
WHERE v.placa_id = 'JEG-1010';

SELECT p.endereco, e.data_entrada, e.data_saida
FROM Estacionamentos e 
JOIN Patios p ON (e.patio_id = p.patio_id)
JOIN Veiculos v ON (e.placa_veiculo = v.placa_id)
WHERE v.placa_id = 'ABC-0123';

-- EX8
SELECT COUNT(*) AS vezes_estacionado
FROM Estacionamentos e 
JOIN Veiculos v ON (e.placa_veiculo = v.placa_id)
WHERE v.cor LIKE '%erde';

-- EX 9
SELECT c.nome
FROM Clientes c 
JOIN Veiculos v ON (c.cpf = v.cpf_cliente)
JOIN Modelos m ON (v.modelo_id = m.modelo_id)
WHERE m.modelo_id = 1;

-- EX10
SELECT v.placa_id, e.data_entrada, e.data_saida
FROM Estacionamentos e 
JOIN Veiculos v ON (e.placa_veiculo = v.placa_id)
WHERE v.cor = 'verde';

-- EX11
SELECT *
FROM Estacionamentos e 
JOIN Veiculos v ON (e.placa_veiculo = v.placa_id)
WHERE v.placa_id = 'JJJ-2020';

SELECT *
FROM Estacionamentos e 
JOIN Veiculos v ON (e.placa_veiculo = v.placa_id)
WHERE v.placa_id = 'ABC-0123';

-- EX12
SELECT c.nome 
FROM Clientes c
JOIN Veiculos v ON (c.cpf = v.cpf_cliente)
JOIN Estacionamentos e ON (v.placa_id = e.placa_veiculo)
WHERE e.estacionamento_id = 2;

-- EX13
SELECT c.cpf
FROM Clientes c
JOIN Veiculos v ON (c.cpf = v.cpf_cliente)
JOIN Estacionamentos e ON (v.placa_id = e.placa_veiculo)
WHERE e.estacionamento_id = 3;

-- EX14
SELECT m.descricao 
FROM Modelos m
JOIN Veiculos v ON (m.modelo_id = v.modelo_id)
JOIN Estacionamentos e ON (v.placa_id = e.placa_veiculo)
WHERE e.estacionamento_id = 2;

-- EX15
SELECT v.placa_id, c.nome, m.descricao
FROM Veiculos v
JOIN Clientes c ON (v.cpf_cliente = c.cpf)
JOIN Modelos m ON (v.modelo_id = m.modelo_id)

-- EX16 extra
-- Crie uma query que retorna todos os veículos e estacionamentos registrados para o veículo, se o veículo não possuir alocação em nenhum estacionamento também deve ser retornado. As colunas que devem ser apresentas são Placa, CPF Cliente e DataEntrada.
SELECT v.placa_id, v.cpf_cliente, e.data_entrada
FROM Veiculos v 
LEFT JOIN Estacionamentos e ON (v.placa_id = e.placa_veiculo);