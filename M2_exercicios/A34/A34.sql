--------------------------
----------DIA_1-----------
--------------------------

-- 1. Crie um banco de dados chamado TropTechModasDB;
USE master
GO

DROP DATABASE IF EXISTS TROPTECHMODASDB;
GO

CREATE DATABASE TROPTECHMODASDB;
GO

USE TROPTECHMODASDB
GO

-- 2. Crie as tabelas do banco baseando-se na descrição do Projeto 2 e no diagrama;
-- 3. Um cliente pode ter ou não um endereço cadastrado;
-- 4. Considere que a coluna CadastroUnico deverá armazenar o CPF ou CNPJ, dependendo do tipo do cliente que também deve ser guardado na mesma tabela na coluna TipoPessoa, sendo que o valor 1 é para pessoa física e 2 para pessoa jurídica;
-- 5. O campo Id da tabela de Endereço deve ser auto incremento;
CREATE TABLE Enderecos
(
    endereco_id INT IDENTITY(1,1) NOT NULL,
    rua VARCHAR(100) NOT NULL,
    numero INT NOT NULL,
    cidade VARCHAR(50) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    pais VARCHAR(50) NOT NULL,
    CONSTRAINT PK_ENDERECO_ID PRIMARY KEY (endereco_id),
)

CREATE TABLE Clientes
(
    cadastro_unico VARCHAR(20) NOT NULL,
    nome VARCHAR(150) NOT NULL,
    telefone VARCHAR(15) NOT NULL,
    endereco_id INT NULL,
    tipo_pessoa INT NOT NULL,
    CONSTRAINT PK_CADASTRO_UNICO PRIMARY KEY (cadastro_unico) ,
    CONSTRAINT FK_CLIENTES_ENDERECOS FOREIGN KEY (endereco_id) REFERENCES Enderecos (endereco_id),
)

-- Queries CRUD
-- 1. Insira pelo menos 10 clientes diferentes, pelos menos 3 deles não devem ter endereço e pelo menos 3 devem ter endereço, 5 clientes devem ser pessoa física e 5 pessoa jurídica;
INSERT INTO Enderecos
VALUES
    ('Rua A B C', 1, 'Blumenau', 'Santa Catarina', 'Brasil'),
    ('Avenida D E F', 2, 'Buenos Aires', 'Buenos Aires', 'Argentina'),
    ('Rua G H I', 3, 'Lages', 'Santa Catarina', 'Brasil'),
    ('Avenida D E F', 4, 'Lages', 'Santa Catarina', 'Brasil'),
    ('Rua A B C', 5, 'Lages', 'Santa Catarina', 'Brasil'),
    ('Rua D E F', 6, 'Lages', 'Santa Catarina', 'Brasil'),
    ('Rua D E F', 7, 'Lages', 'Santa Catarina', 'Brasil'),
    ('Rua A B C', 8, 'Blumenau', 'Santa Catarina', 'Brasil'),
    ('Rua A B C', 9, 'Blumenau', 'Santa Catarina', 'Brasil'),
    ('Rua D E F', 10, 'Lages', 'Santa Catarina', 'Brasil');

SELECT *
FROM Enderecos
INSERT INTO Clientes
VALUES
    ('111.111.111-11', 'Abcde B C', '3333-3333', 1, 1),
    ('222.222.222-22', 'D E F', '3333-3334', 2, 1),
    ('333.333.333-33', 'G H I', '3333-3335', 3, 1),
    ('444.444.444-44', 'J K L', '3333-3336', 4, 1),
    ('555.555.555-55', 'M N O', '3333-3337', NULL, 1),
    ('11.111.111/0001-11', 'P Q R', '3333-3338', 5, 2),
    ('22.222.222/0001-11', 'S T U', '3333-3339', 6, 2),
    ('33.333.333/0001-11', 'V W X', '3333-3340', 7, 2),
    ('44.444.444/0001-11', 'Y Z', '3333-3341', NULL, 2),
    ('55.555.555/0001-11', 'Z Y X', '3333-3342', NULL, 2);

-- 2. Remova um cliente com endereço, o endereço também deve ser deletado, a remoção deve ocorrer considerando o Cadastro Único;
DECLARE @endereco_id_para_deletar INT;

SELECT @endereco_id_para_deletar = endereco_id 
FROM Clientes
WHERE cadastro_unico = '444.444.444-44';

DELETE FROM Clientes
WHERE cadastro_unico = '444.444.444-44';

DELETE FROM Enderecos 
WHERE endereco_id = @endereco_id_para_deletar;

-- 3. Remova um cliente sem endereço
DELETE FROM Clientes
WHERE cadastro_unico = '55.555.555/0001-11';

-- 4. Atualize o endereço de um cliente;
UPDATE Enderecos SET rua = 'Rua A A A', estado = 'Santa Catarina' WHERE endereco_id = 3;

DECLARE @endereco_id_para_alterar INT;

SELECT @endereco_id_para_alterar = endereco_id
FROM Clientes
WHERE cadastro_unico = '222.222.222-22';

UPDATE Enderecos SET rua = 'Rua A A A', estado = 'Santa Catarina' WHERE endereco_id = @endereco_id_para_alterar;

-- 5. Adicione endereço para um cliente que não possuía endereço;
INSERT INTO Enderecos
VALUES
    ('Rua A B C', 11, 'Blumenau', 'Santa Catarina', 'Brasil');

DECLARE @current_key BIGINT = SCOPE_IDENTITY();

UPDATE Clientes SET endereco_id = @current_key WHERE cadastro_unico = '44.444.444/0001-11';

-- 6. Delete apenas o endereço recém-criado, o cliente que possuía o endereço deve ficar sem;
UPDATE Clientes SET endereco_id = NULL WHERE cadastro_unico = '44.444.444/0001-11';

DELETE FROM Enderecos
WHERE endereco_id = @current_key;

-- Queries de Consulta
-- 1. Crie uma query para a funcionalidade de apresentar todos os clientes e seus endereços, independente se o cliente possui endereço ou não;
SELECT c.nome, CONCAT_WS(' - ', e.rua, e.numero, e.cidade, e.estado, e.pais) AS endereco_completo
FROM Clientes c
LEFT JOIN Enderecos e ON (c.endereco_id = e.endereco_id)

-- 2. Crie uma query que busque o cliente pelo nome, a consulta pode retornar um ou mais clientes e deve considerar a busca parcial, por exemplo, se existir um cliente com nome “Alfredo” e o usuário digitar “Alf” deve retornar o cliente “Alfredo”;
DECLARE @find VARCHAR(150);   
SET @find = 'A%';  

SELECT nome
FROM Clientes
WHERE nome LIKE @find;

-- 3. Considere que a query de busca de cliente por nome também deve buscar palavras no meio de nomes, por exemplo, se existir um cliente com nome “Maria Clara” e a busca for feita por “Clara” deve retornar também a “Maria Clara”;
SET @find = '%A%';  

SELECT nome
FROM Clientes
WHERE nome LIKE @find;


--------------------------
----------DIA_2-----------
--------------------------

-- 1. Crie as tabelas do banco baseando-se na descrição do Projeto 2 e no diagrama;
-- 2. Considere que a tabela Cliente é a mesma criada anteriormente, não é necessário criar outra;
-- 3. Uma venda sempre deve ter um cliente, valor e descrição;
-- 4. O id da venda deve ser auto incremento;
CREATE TABLE Vendas
(
    venda_id INT IDENTITY(1,1) NOT NULL,
    descricao VARCHAR(500) NOT NULL,
    valor DECIMAL NOT NULL,
    cadastro_unico_cliente VARCHAR(20) NOT NULL,
    CONSTRAINT PK_VENDA_ID PRIMARY KEY (venda_id),
    CONSTRAINT FK_VENDAS_CLIENTES FOREIGN KEY (cadastro_unico_cliente) REFERENCES Clientes (cadastro_unico),
)

-- Queries CRUD
-- 1. Insira pelo menos 10 vendas diversificando-as por cliente, deixe apenas um cliente sem venda registrada;
INSERT INTO Vendas
VALUES
    ('Bicicleta', 1950.00, '111.111.111-11'),
    ('Carro', 19990.00, '111.111.111-11'),
    ('Moto', 7000.00, '111.111.111-11'),
    ('Bolacha', 5.00, '111.111.111-11'),
    ('Biscoito', 5.00, '222.222.222-22'),
    ('Teclado', 50.00, '222.222.222-22'),
    ('Mouse', 35.00, '333.333.333-33'),
    ('Tela', 500.00, '22.222.222/0001-11'),
    ('SSD', 350.00, '555.555.555-55'),
    ('Chinelo', 40.00, '11.111.111/0001-11');

-- 2. Delete uma venda;
DELETE FROM Vendas
WHERE venda_id = 10;

-- 3. Delete um cliente que possua vendas;
DECLARE @cliente_deletar VARCHAR(20) = '222.222.222-22';

DELETE FROM Vendas
WHERE cadastro_unico_cliente = @cliente_deletar;

DELETE FROM Clientes
WHERE cadastro_unico = @cliente_deletar;

-- 4. Atualize a descrição de uma venda;
UPDATE Vendas SET descricao = 'SSD 240 GB' 
WHERE venda_id = 9;

-- Queries de Consultas
-- 1. Criar query que apresente todas as vendas com todo os atributos, para o cliente deve apresentar apenas nome e telefone;
SELECT v.*, c.nome, c.telefone FROM Vendas v
LEFT JOIN Clientes c ON (c.cadastro_unico = v.cadastro_unico_cliente)

-- 2. Criar query que apresente todas as vendas de um cliente específico;
DECLARE @cliente_alvo VARCHAR(20) = '111.111.111-11'
SELECT v.*, c.nome, c.telefone FROM Vendas v
LEFT JOIN Clientes c ON (c.cadastro_unico = v.cadastro_unico_cliente)
WHERE c.cadastro_unico = @cliente_alvo

-- 3. Criar query que retorna uma venda por id com as informações: valor, nome do cliente, e endereço completo no formato “Rua X, 555, Cidade, Estado, País”. Se o cliente não possuir endereço deve retornar mesmo assim;
DECLARE @venda_id_alvo INT = 1;

SELECT v.valor, c.nome, CONCAT_WS(', ', e.rua, e.cidade, e.estado, e.pais) AS endereco_completo
FROM Vendas v 
JOIN Clientes c ON (c.cadastro_unico = v.cadastro_unico_cliente)
JOIN Enderecos e ON (c.endereco_id = e.endereco_id)
WHERE v.venda_id = @venda_id_alvo


--------------------------
----------DIA_3-----------
--------------------------

-- 1. Valor total de vendas da loja;
SELECT COUNT(*) AS vendas_total
FROM Vendas;

-- 2. Quantidade de cliente que já efetuaram compras;
SELECT count(DISTINCT c.cadastro_unico) AS clientes_compradores
FROM Clientes c
    RIGHT JOIN Vendas v ON (v.cadastro_unico_cliente = c.cadastro_unico)

-- 3. Quantidade de clientes que ainda não efetuaram nenhuma compra;
SELECT COUNT(*) AS clientes_sem_compras
FROM Clientes c
    LEFT JOIN Vendas v ON (v.cadastro_unico_cliente = c.cadastro_unico)
WHERE v.venda_id IS NULL;

-- 4. Compra com maior valor;
SELECT MAX(valor) AS maior_valor
FROM Vendas;

-- 5. Cliente que não tem o endereço cadastrado, deve apresentar o nome e telefone do cliente;
SELECT nome, telefone
FROM Clientes c
    LEFT JOIN Enderecos e ON (e.endereco_id = c.cadastro_unico)
WHERE c.endereco_id IS NULL;

-- 6. Total do faturamento da loja no formato "R$ VALOR";
SELECT CONCAT('R$ VALOR: ', SUM(valor)) AS faturamento
FROM Vendas;

-- 7. Valor total que um cliente gastou na loja, o valor deve ser apresentado com prefixo R$;
DECLARE @cliente_alvo2 VARCHAR(20) = '111.111.111-11';

SELECT SUM(v.valor) AS valor_total_gasto
FROM Clientes c
    JOIN Vendas v ON (v.cadastro_unico_cliente = c.cadastro_unico)
WHERE c.cadastro_unico = @cliente_alvo2;

-- 8. Quantidade de clientes que são pessoa física e jurídica. Como um bônus, tente apresentar os valores na mesma tabela;
SELECT
    (SELECT SUM(tipo_pessoa)
    FROM Clientes
    WHERE tipo_pessoa = 1) AS PF,
    (SELECT SUM(tipo_pessoa)
    FROM Clientes
    WHERE tipo_pessoa = 2) AS PJ;

-- 1. Crie queries para apresentar o valor faturado por cada estado;
SELECT e.estado, SUM(v.valor)
FROM Vendas v
    JOIN Clientes c ON (v.cadastro_unico_cliente = c.cadastro_unico)
    LEFT JOIN Enderecos e ON (e.endereco_id = c.endereco_id)
WHERE e.estado IS NOT NULL
GROUP BY e.estado

-- 2. Para evitar que Estados e Países sejam cadastrados de forma errônea impactando nos indicadores da questão 1, vamos criar tabelas para estado e país e migrar os dados existentes em Endereco para as novas tabelas.
-- a. Crie uma tabela chamada Pais que deve possuir uma chave primária inteira e incremental com nome Id e outra coluna com o nome do país.
CREATE TABLE Paises
(
    pais_id INT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(50) NOT NULL,
    CONSTRAINT PK_pais_id PRIMARY KEY (pais_id),
)

-- b. Crie uma tabela chamada Estado que deve possuir uma chave primária inteira e incremental com o nome Id, outra coluna para armazenar o nome e por fim uma coluna chamada PaisId que deve ser chave estrangeira com a tabela Pais;
CREATE TABLE Estados
(
    estado_id INT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(50) NOT NULL,
    pais_id INT NOT NULL,
    CONSTRAINT PK_estado_id PRIMARY KEY (estado_id),
    CONSTRAINT FK_estado_pais FOREIGN KEY (pais_id) REFERENCES Paises(pais_id),
)

-- c. Faça um script que leia todos os países da tabela Endereco e insira na tabela Pais;
INSERT INTO Paises
SELECT DISTINCT pais
FROM Enderecos

-- d. Faça um script que leia todos os estados da tabela Endereco e insira na tabela Estado;
INSERT INTO Estados
SELECT DISTINCT e.estado, p.pais_id
FROM Enderecos e
    JOIN Paises p ON (e.pais = p.nome)

SELECT *
FROM Estados

-- e. Crie uma nova coluna na tabela Endereco chamada EstadoId que deve ser chave estrangeira com a tabela Estado, a princípio deve aceitar nulo;
ALTER TABLE Enderecos ADD
    estado_id INT,
    CONSTRAINT FK_enderecos_estados FOREIGN KEY (estado_id) REFERENCES Estados(estado_id);

-- f. Atualize a coluna EstadoId com o Id do estado equivalente ao endereço;
UPDATE Enderecos 
    SET estado_id = es.estado_id
    FROM Enderecos e
    LEFT JOIN Estados es ON (e.estado = es.nome)

-- g. Remova as colunas Estado e Pais da tabela Endereco;
ALTER TABLE Enderecos
    DROP COLUMN estado, pais

-- h. Alterar coluna EstadoId da tabela Endereco para não aceitar nulo;
ALTER TABLE Enderecos ALTER COLUMN
    estado_id INT NOT NULL