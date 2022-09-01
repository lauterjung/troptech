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

-- CREATE TABLE Cestas(
-- cesta_id BIGINT IDENTITY(1,1) NOT NULL,
-- descricao VARCHAR(50) NOT NULL,
-- valor DECIMAL NOT NULL,
-- CONSTRAINT PK_cesta_id PRIMARY KEY (cesta_id),
-- )

CREATE TABLE Contratos(
contrato_id BIGINT NOT NULL,
tipo VARCHAR(50) NOT NULL,
valor_total DECIMAL NOT NULL,
quantidade_parcelas INT NOT NULL,
valor_parcelas DECIMAL NOT NULL,
data_inicial DATE NOT NULL,
data_final DATE NOT NULL,
cpf VARCHAR(11) NOT NULL,
CONSTRAINT PK_contrato_id PRIMARY KEY (contrato_id),
CONSTRAINT FK_contratos_clientes FOREIGN KEY (cpf) REFERENCES Clientes (cpf),
)

CREATE TABLE Contas(
numero INT NOT NULL,
digito INT NOT NULL,
agencia INT NOT NULL,
tipo VARCHAR(50) NOT NULL,
saldo DECIMAL(38,2) NOT NULL,
limite DECIMAL(38,2),
data_abertura DATE NOT NULL,
cesta INT,
cpf VARCHAR(11) NOT NULL,
CONSTRAINT PK_numero PRIMARY KEY (numero),
CONSTRAINT FK_contas_clientes FOREIGN KEY (cpf) REFERENCES Clientes (cpf),
-- CONSTRAINT FK_contas_cestas FOREIGN KEY (cesta_id) REFERENCES Cestas (cesta_id),
)

-- 2) Com o banco criado preencha o banco com os dados da planilha da Aline que estão em anexo na  atividade no classroom.
-- INSERT INTO Cestas
-- VALUES
-- ('Platina', 12.50),
-- ('Prata', 25.50),
-- ('Ouro', 40.50),
-- ('Não tem', 40.50);

INSERT INTO Clientes
VALUES
('25520831025', 'Enzo Ribeiro', '1995-06-18'),
('27446351039', 'Maria Mendes', '1971-08-01'),
('78014068009', 'Nilson Souza', '1963-07-22'),
('93260976094', 'Marina Delfes', '2002-11-25'),
('97945506046', 'Alberto Rodrigues', '1987-04-19');

INSERT INTO Contratos
VALUES
(1, 'Habitacional', 350000.00, 200, 1750, '2022-08-08', '08/04/2039', '25520831025'),
(2, 'Consignado', 50000.00, 30, 1666.666667, '2022-08-08', '08/02/2025', '27446351039'),
(3, 'CDC', 2000.00, 10, 200, '2022-08-08', '08/04/2039', '78014068009'),
(4, 'Habitacional', 100000.00, 150, 666.6666667, '2022-08-08', '08/02/2035', '93260976094'),
(5, 'CDC', 3500.00, 7, 500, '2022-08-08', '08/04/2064', '97945506046');



INSERT INTO Contas
VALUES
(12345, 4, 0420, '001', 1500.00, 200.00, '2022-01-01', 3, '97945506046'),
(12457, 0, 0420, '1288', 2400.00, 200.00, '2022-08-01', 4, '78014068009'),
(15742, 1, 1665, '013', 3500.00, 200.00, '2012-01-12', 4, '27446351039'),
(25412, 2, 0420, '001', 11500.00, 200.00, '2022-07-31', 1, '93260976094'),
(35715, 5, 3885, '1288', 2500.00, 200.00, '1999-01-11', 4, '25520831025'),
(78945, 4, 3285, '001', 15000.00, 200.00, '2022-01-01', 2, '78014068009'),
(89562, 0, 0420, '013', 500.00, 200.00, '2022-02-02', 4, '97945506046')
