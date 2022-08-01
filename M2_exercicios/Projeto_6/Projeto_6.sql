-- 1) Crie o banco de dados e as respectivas tabelas conforme os dados acima.
USE master
GO

DROP DATABASE IF EXISTS AGENCIABANCARIADB;
GO

CREATE DATABASE AGENCIABANCARIADB;
GO

USE AGENCIABANCARIADB
GO

CREATE TABLE Clientes(
cpf VARCHAR(11) NOT NULL,
nome VARCHAR(100) NOT NULL,
data_nascimento DATE NOT NULL
CONSTRAINT PK_cpf PRIMARY KEY (cpf),
)

CREATE TABLE Cestas(
cesta_id BIGINT IDENTITY(1,1) NOT NULL,
descricao VARCHAR(50) NOT NULL,
valor DECIMAL NOT NULL,
CONSTRAINT PK_cesta_id PRIMARY KEY (cesta_id),
)

CREATE TABLE Contratos(
contrato_id BIGINT IDENTITY(1,1) NOT NULL,
tipo VARCHAR(50) NOT NULL,
valor_total DECIMAL NOT NULL,
quantidade_parcelas BIGINT NOT NULL,
cpf VARCHAR(11) NOT NULL,
CONSTRAINT PK_contrato_id PRIMARY KEY (contrato_id),
CONSTRAINT FK_contratos_clientes FOREIGN KEY (cpf) REFERENCES Clientes (cpf),
)

CREATE TABLE Contas(
numero INT NOT NULL,
digito INT NOT NULL,
agencia INT NOT NULL,
tipo VARCHAR(50) NOT NULL,
saldo MONEY NOT NULL,
limite MONEY NOT NULL,
data_abertura DATE NOT NULL,
cesta_id BIGINT NOT NULL,
cpf VARCHAR(11) NOT NULL,
CONSTRAINT PK_numero PRIMARY KEY (numero),
CONSTRAINT FK_contas_clientes FOREIGN KEY (cpf) REFERENCES Clientes (cpf),
CONSTRAINT FK_contas_cestas FOREIGN KEY (cesta_id) REFERENCES Cestas (cesta_id),
)

-- 2) Com o banco criado preencha o banco com os dados da planilha da Aline que estão em anexo na  atividade no classroom.
INSERT INTO Cestas
VALUES
('Platina', 12.50),
('Prata', 25.50),
('Ouro', 40.50),
('Não tem', 40.50);

INSERT INTO Clientes
VALUES
('25520831025', 'Enzo Ribeiro', '1995-06-18'),
('27446351039', 'Maria Mendes', '1971-08-01'),
('78014068009', 'Nilson Souza', '1963-07-22'),
('93260976094', 'Marina Delfes', '2002-11-25'),
('97945506046', 'Alberto Rodrigues', '1987-04-19');

INSERT INTO Contratos
VALUES
('Habitacional', 350000.00, 200, '25520831025'),
('Consignado', 50000.00, 30, '27446351039'),
('CDC', 2000.00, 10, '78014068009'),
('Habitacional', 100000.00, 150, '93260976094'),
('CDC', 3500.00, 7, '97945506046');

INSERT INTO Contas
VALUES
(12345, 4, 0420, '001', 1500.00, 200.00, '2022-01-01', 3, '97945506046'),
(12457, 0, 0420, '1288', 2400.00, 200.00, '2022-08-01', 4, '78014068009'),
(15742, 1, 1665, '013', 3500.00, 200.00, '2012-01-12', 4, '27446351039'),
(25412, 2, 0420, '001', 11500.00, 200.00, '2022-07-31', 1, '93260976094'),
(35715, 5, 3885, '1288', 2500.00, 200.00, '1999-01-11', 4, '25520831025'),
(78945, 4, 3285, '001', 15000.00, 200.00, '2022-01-01', 2, '78014068009'),
(89562, 0, 0420, '013', 500.00, 200.00, '2022-02-02', 4, '97945506046')

-- 3) Crie um script para mostrar o nome de cada cliente com número de conta, agência e saldo.
SELECT cl.nome, co.numero, co.agencia, co.saldo
FROM Contas co
JOIN Clientes cl ON (cl.cpf = co.cpf);

-- 4) Crie um script para mostrar o nome de cada cliente, tipo de contrato, valor total e quantidade de parcelas;
SELECT cl.nome, ct.tipo, ct.valor_total, ct.quantidade_parcelas
FROM Clientes cl
LEFT JOIN Contratos ct ON (cl.cpf = ct.cpf);

-- 5) Crie um script para mostrar todas as contas com suas respectivas cesta de serviço.
SELECT co.numero, co.digito, co.agencia, co.tipo, ce.descricao
FROM Contas co
LEFT JOIN Cestas ce ON (co.cesta_id = ce.cesta_id)

-- 6) Crie um script para mostrar apenas as contas que não possuem cesta de serviço.
SELECT co.numero, co.digito, co.agencia, co.tipo, ce.descricao
FROM Contas co
LEFT JOIN Cestas ce ON (co.cesta_id = ce.cesta_id)
WHERE co.cesta_id = 4

-- 7) Crie um script para mostrar quantidade de clientes, contas e contratos que existem hoje na  base de dados.
SELECT (SELECT COUNT(*) FROM Clientes) AS n_clientes,
       (SELECT COUNT(*) FROM Contas) AS n_contas,
       (SELECT COUNT(*) FROM Contratos) AS n_contratos;

-- 8) Crie um script que contabilize todas as contas que foram abertas em 2022.
SELECT COUNT(*) AS n_contas_2022 FROM Contas 
WHERE YEAR(data_abertura) = '2022'

-- 9) Crie um script que faça uma média do valor total, outro que mostre maior valor total dos contratos cadastrados e um, com a soma do valor total só dos contratos habitacionais.
SELECT (SELECT AVG(valor_total) FROM Contratos) AS media,
       (SELECT MAX(valor_total) FROM Contratos) AS valor_maximo,
       (SELECT SUM(valor_total) FROM Contratos) AS soma;

-- 10) Crie um script que limpa todos os dados de todas as tabelas na sequência Correta.
DELETE FROM Contas;
DELETE FROM Contratos;
DELETE FROM Clientes;
DELETE FROM Cestas;

DBCC CHECKIDENT(Cestas);
DBCC CHECKIDENT(Contratos);
