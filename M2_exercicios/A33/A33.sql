-- -- EX1
-- USE master
-- GO

-- DROP DATABASE IF EXISTS ESTACIONAMENTODB;
-- GO

-- CREATE DATABASE ESTACIONAMENTODB;
-- GO

-- USE ESTACIONAMENTODB
-- GO

-- CREATE TABLE Clientes(
-- cpf BIGINT NOT NULL,
-- nome VARCHAR(100) NOT NULL,
-- data_nascimento DATE NOT NULL
-- CONSTRAINT PK_cpf PRIMARY KEY (cpf),
-- )

-- CREATE TABLE Modelos(
-- modelo_id BIGINT IDENTITY(1,1) NOT NULL,
-- descricao VARCHAR(250),
-- CONSTRAINT PK_modelo_id PRIMARY KEY (modelo_id),
-- )

-- CREATE TABLE Patios(
-- patio_id BIGINT IDENTITY(1,1) NOT NULL,
-- endereco VARCHAR(250) NOT NULL,
-- capacidade INT NOT NULL,
-- CONSTRAINT PK_patio_id PRIMARY KEY (patio_id),
-- )

-- CREATE TABLE Veiculos(
-- placa_id VARCHAR(10) NOT NULL,
-- modelo_id BIGINT NOT NULL,
-- cor VARCHAR(20) NOT NULL,
-- ano INT NOT NULL,
-- cpf_cliente VARCHAR(11) NOT NULL,
-- CONSTRAINT PK_placa_id PRIMARY KEY (placa_id),
-- CONSTRAINT FK_veiculos_modelos FOREIGN KEY (modelo_id) REFERENCES Modelos (modelo_id),
-- )

-- CREATE TABLE Estacionamentos(
-- estacionamento_id BIGINT IDENTITY(1,1) NOT NULL,
-- patio_id BIGINT NOT NULL,
-- placa_veiculo VARCHAR(10) NOT NULL,
-- data_entrada DATE NOT NULL,
-- data_saida DATE NULL,
-- CONSTRAINT PK_estacionamento_id PRIMARY KEY (estacionamento_id),
-- CONSTRAINT FK_estacionamentos_patios FOREIGN KEY (estacionamento_id) REFERENCES Patios (patio_id),
-- CONSTRAINT FK_estacionamentos_veiculos FOREIGN KEY (placa_veiculo) REFERENCES Veiculos (placa_id),
-- )

-- INSERT INTO Clientes
-- VALUES(00000000001, 'A B C', '1990-01-01');
-- INSERT INTO Clientes
-- VALUES(00000000002, 'D E F', '1990-01-02');
-- INSERT INTO Clientes
-- VALUES(00000000003, 'G H I', '1990-01-03');

-- INSERT INTO Modelos
-- VALUES('Audi');
-- INSERT INTO Modelos
-- VALUES('Chevrolet');
-- INSERT INTO Modelos
-- VALUES('Toyota');

-- INSERT INTO Patios
-- VALUES('Rua ABC', 50);
-- INSERT INTO Patios
-- VALUES('Rua DEF', 100);
-- INSERT INTO Patios
-- VALUES('Rua GHI', 200);

-- INSERT INTO Veiculos
-- VALUES('ABC-0123', 1, 'Vermelho', 1990, 00000000001);
-- INSERT INTO Veiculos
-- VALUES('DEF-0456', 1, 'Verde', 1991, 00000000002);
-- INSERT INTO Veiculos
-- VALUES('GHI-0789', 2, 'Azul', 1991, 00000000003);
-- INSERT INTO Veiculos
-- VALUES('JKL-1111', 2, 'Verde', 1993, 00000000003);

-- INSERT INTO Estacionamentos
-- VALUES(1, 'ABC-0123', '2022-01-01', NULL);
-- INSERT INTO Estacionamentos
-- VALUES(3, 'DEF-0456', '2022-01-02', '2022-01-03');
-- INSERT INTO Estacionamentos
-- VALUES(3, 'GHI-0789', '2022-01-03', NULL);

-- 1) Dentro do banco de dados “Estacionamento” crie a procedure abaixo:
CREATE PROCEDURE ADDVEICULOS
@cnt INT = 1
AS BEGIN
WHILE @cnt < 200000
BEGIN
INSERT INTO VEICULOS
VALUES (CONCAT('MK ', @cnt), 1, 'Verde', 1991, 00000000002);
SET @cnt = @cnt + 1;
END;
END;

-- 2) Agora chame sua execução:
EXEC ADDVEICULOS;

-- 3) Faça a busca pelos veículos com a condição para trazer pelo ano igual a 2016 e guarde o tempo;
SELECT COUNT(*) FROM Veiculos

SELECT * FROM Veiculos
WHERE ano  = 2016;
-- 11 ms

-- 4) Crie um index não clusterizado para a coluna do ano;
CREATE NONCLUSTERED INDEX IX_ano on Veiculos (ano);

-- 5) Faça a busca pelos veículos com a condição para trazer pelo ano igual a 2016 e compare o tempo;
SELECT * FROM Veiculos
WHERE ano  = 2016;
-- 7 ms

-- 6) Crie um index para não poder cadastrar um novo estacionamento com a placa do veiculo igual, faça o insert para garantir que esteja funcional;
CREATE UNIQUE INDEX UIX_placa ON Estacionamentos (placa_veiculo);

INSERT INTO Estacionamentos
VALUES(1, 'MK1', '2022-01-01', NULL);

-- 7) Crie um index não clusterizado para placa do veículo na tabela estacionamento que faça a  inclusão do id do estacionamento e a data de entrada.
CREATE NONCLUSTERED INDEX IX_placa_veiculo_estacionamento_id_data_entrada ON Estacionamentos (placa_veiculo) INCLUDE (estacionamento_id, data_entrada);

-- 8) Crie um index não clusteriado para data de entrada com o include por id, placaveiculo e a data de saída
CREATE NONCLUSTERED INDEX IX_data_entrada_estacionamento_id_placa_veiculo_data_saida ON Estacionamentos (data_entrada) INCLUDE (estacionamento_id, placa_veiculo, data_saida);

-- 9) Faça a exclusão do index criado no exercício 6;
DROP INDEX UIX_placa ON Estacionamentos;

-- 10) Faça a inserção de mais 10 registros na tabela estacionamento e faça o rebuild de todos os index que a tabela contém.
-- CREATE PROCEDURE ADDVEICULOS10
-- @cnt INT = 200001
-- AS BEGIN
-- WHILE @cnt < 200011
-- BEGIN
-- INSERT INTO VEICULOS
-- VALUES (CONCAT('MK ', @cnt), 1, 'Verde', 1991, 00000000002);
-- SET @cnt = @cnt + 1;
-- END;
-- END;

-- EXEC ADDVEICULOS10;

-- ALTER INDEX IX_ano on Veiculos (ano);

-- ALTER INDEX IX_placa_veiculo_estacionamento_id_data_entrada ON Estacionamentos REBUILD;

-- ALTER INDEX IX_data_entrada_estacionamento_id_placa_veiculo_data_saida ON Estacionamentos REBUILD;

CREATE TABLE new_table(
    nome VARCHAR(50),
    sobrenome VARCHAR(50),
    numero INT,
)
BULK INSERT new_table
FROM 'C:\Users\User\Dropbox\program\git\troptech\Pasta1.csv'
WITH(
    FIELDTERMINATOR = ',',
    FIRSTROW = 2,
    ROWTERMINATOR = '\r\n'
)
