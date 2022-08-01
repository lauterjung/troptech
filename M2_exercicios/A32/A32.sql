-- EX1
USE master
GO

DROP DATABASE IF EXISTS ESTACIONAMENTODB;
GO

CREATE DATABASE ESTACIONAMENTODB;
GO

USE ESTACIONAMENTODB
GO

CREATE TABLE Clientes
(
    cpf BIGINT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    data_nascimento DATE NOT NULL
        CONSTRAINT PK_cpf PRIMARY KEY (cpf),
);

CREATE TABLE Modelos
(
    modelo_id BIGINT IDENTITY(1,1) NOT NULL,
    descricao VARCHAR(250),
    CONSTRAINT PK_modelo_id PRIMARY KEY (modelo_id),
);

CREATE TABLE Patios
(
    patio_id BIGINT IDENTITY(1,1) NOT NULL,
    endereco VARCHAR(250) NOT NULL,
    capacidade INT NOT NULL,
    CONSTRAINT PK_patio_id PRIMARY KEY (patio_id),
);

CREATE TABLE Veiculos
(
    placa_id VARCHAR(10) NOT NULL,
    modelo_id BIGINT NOT NULL,
    cor VARCHAR(20) NOT NULL,
    ano INT NOT NULL,
    cpf_cliente VARCHAR(11) NOT NULL,
    CONSTRAINT PK_placa_id PRIMARY KEY (placa_id),
    CONSTRAINT FK_veiculos_modelos FOREIGN KEY (modelo_id) REFERENCES Modelos (modelo_id),
);

CREATE TABLE Estacionamentos
(
    estacionamento_id BIGINT IDENTITY(1,1) NOT NULL,
    patio_id BIGINT NOT NULL,
    placa_veiculo VARCHAR(10) NOT NULL,
    data_entrada DATE NOT NULL,
    data_saida DATE NULL,
    CONSTRAINT PK_estacionamento_id PRIMARY KEY (estacionamento_id),
    CONSTRAINT FK_estacionamentos_patios FOREIGN KEY (estacionamento_id) REFERENCES Patios (patio_id),
    CONSTRAINT FK_estacionamentos_veiculos FOREIGN KEY (placa_veiculo) REFERENCES Veiculos (placa_id),
);

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
    SELECT placa_id AS placa
    FROM Veiculos
UNION
    SELECT nome
    FROM Clientes;

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

---------------------------------------------------------------------------
-- EX1
SELECT AVG(capacidade)
FROM Patios

-- EX2
SELECT COUNT(e.estacionamento_id)
FROM Estacionamentos e
WHERE e.data_saida IS NOT NULL

-- EX3
SELECT MAX(v.ano)
FROM Veiculos v

-- EX4
SELECT MIN(v.ano)
FROM Veiculos v

-- EX5
SELECT e.data_entrada, p.patio_id
FROM Estacionamentos e
    JOIN Patios p ON (e.patio_id = p.patio_id);

-- EX6
SELECT SUBSTRING(v.placa_id, 5, 8)
FROM Veiculos v


-- EX7
UPDATE Veiculos SET cor = UPPER(cor);
SELECT cor
FROM Veiculos

-- EX8
SELECT CONCAT_WS(' | ', c.nome, v.placa_id, m.descricao, e.data_entrada, p.endereco)
FROM Estacionamentos e
    JOIN Veiculos v ON (e.placa_veiculo = v.placa_id)
    JOIN Patios p ON (e.patio_id = p.patio_id)
    JOIN Clientes c ON (v.cpf_cliente = c.cpf)
    JOIN Modelos m ON (m.modelo_id = v.modelo_id)

-----------------
-- EX2
-- EX1
USE master
GO

DROP DATABASE IF EXISTS MATERIAISCONSTRUCAODB;
GO

CREATE DATABASE MATERIAISCONSTRUCAODB;
GO

USE MATERIAISCONSTRUCAODB
GO


-- EX2
CREATE TABLE Clientes
(
    cliente_id BIGINT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(100) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    endereco VARCHAR(250) NOT NULL,
    CONSTRAINT PK_cliente_id PRIMARY KEY (cliente_id),
);

CREATE TABLE Lojas
(
    loja_id BIGINT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(100) NOT NULL,
    cidade VARCHAR(50) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    cnpj VARCHAR(20) NOT NULL,
    CONSTRAINT PK_loja_id PRIMARY KEY (loja_id),
);

CREATE TABLE Pedidos
(
    pedido_id BIGINT IDENTITY(1,1) NOT NULL,
    numero BIGINT NOT NULL,
    [data] DATE NOT NULL,
    valor DECIMAL NOT NULL,
    cliente_id BIGINT NOT NULL,
    loja_id BIGINT NOT NULL,
    CONSTRAINT PK_pedido_id PRIMARY KEY (pedido_id),
    CONSTRAINT FK_pedidos_clientes FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id),
    CONSTRAINT FK_pedidos_lojas FOREIGN KEY (loja_id) REFERENCES Lojas(loja_id),
);

-- EX3
INSERT INTO Clientes 
VALUES('A B C', '99999-0123', 'Rua A B C')
INSERT INTO Clientes 
VALUES('D E F', '99999-0456', 'Rua D E F')
INSERT INTO Clientes 
VALUES('G H I', '99999-0789', 'Rua G H I')
INSERT INTO Clientes 
VALUES('J K L', '99999-1111', 'Rua J K L')
INSERT INTO Clientes 
VALUES('M N O', '99999-2222', 'Rua A B C')

INSERT INTO Lojas 
VALUES('L1', 'Cidade A', '33333-0123', '22.222.222/0001-22')
INSERT INTO Lojas 
VALUES('L2', 'Cidade B', '33333-0456', '33.333.333/0001-33')
INSERT INTO Lojas 
VALUES('L3', 'Cidade B', '33333-0789', '44.444.444/0001-44')
INSERT INTO Lojas 
VALUES('L4', 'Cidade C', '33333-1111', '55.555.555/0001-55')

INSERT INTO Pedidos 
VALUES(1, '2022-01-01', 500.05, 1, 1)
INSERT INTO Pedidos 
VALUES(2, '2022-01-02', 1000.05, 4, 2)
INSERT INTO Pedidos 
VALUES(5, '2022-01-02', 80.00, 1, 3)
INSERT INTO Pedidos 
VALUES(3, '2022-01-01', 5, 1, 1)
INSERT INTO Pedidos 
VALUES(100, '2022-01-03', 55, 2, 1)
INSERT INTO Pedidos 
VALUES(10, '2022-01-04', 505, 2, 1)
INSERT INTO Pedidos 
VALUES(1, '2022-05-01', 999, 2, 4)
INSERT INTO Pedidos 
VALUES(1, '2022-06-01', 2000, 1, 4)
INSERT INTO Pedidos 
VALUES(5, '2022-01-01', 10000, 1, 1)
INSERT INTO Pedidos 
VALUES(500, '2022-01-01', 5, 3, 4)

-- EX4
SELECT MAX(p.valor) 
FROM Pedidos p

-- EX5
SELECT MIN(p.valor) 
FROM Pedidos p

-- EX6
SELECT AVG(p.valor) 
FROM Pedidos p

-- EX7
SELECT SUM(p.valor) 
FROM Pedidos p

-- EX8
SELECT l.cidade, SUM(p.numero)
FROM Pedidos p
JOIN Lojas l ON (l.loja_id = p.loja_id)
GROUP BY l.cidade

-- EX9
SELECT CONCAT(l.nome, ' - ', l.cidade) AS loja_completa 
FROM Lojas l

-- EX10
SELECT MONTH(p.[data])
FROM Pedidos p
