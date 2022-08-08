-- Alexandre tem uma coleção grande de revistas em quadrinhos. Por isso, resolveu emprestar para os amigos. Assim foi criado o Clube da Leitura. Mas para não perder nenhuma revista, seu pai lhe fez uma aplicação que cadastra as revistas e controla o empréstimo. Para cada revista cadastram-se: o tipo da coleção (por exemplo: Os vingadores, Homem Aranha, Batman etc.), o número da edição, o ano da revista e a cor da caixa onde está guardada. Para cada empréstimo cadastram-se: o amigo que pegou a revista, qual foi a revista, a data de empréstimo, preço e a data de devolução. Cada criança só pode pegar uma revista por empréstimo. O cadastro do amigo consiste de: o nome, o nome da mãe, o telefone e de onde é o amigo (do prédio ou da escola). Faça os scripts para ajudar o pai de Alexandre na sua nova aplicação.

-- 1) Crie o banco de dados e as respectivas tabelas conforme os dados acima.
USE master
GO

DROP DATABASE IF EXISTS CLUBELEITURADB;
GO

CREATE DATABASE CLUBELEITURADB;
GO

USE CLUBELEITURADB;
GO

CREATE TABLE Revistas
(
    id_revista INT IDENTITY(1,1) NOT NULL,
    tipo_colecao VARCHAR(100) NOT NULL,
    numero_edicao INT NOT NULL,
    ano_revista INT NOT NULL,
    cor_caixa VARCHAR(20) NOT NULL,
    CONSTRAINT PK_id_revista PRIMARY KEY (id_revista),
)

CREATE TABLE Amigos
(
    id_amigo INT IDENTITY(1,1) NOT NULL,
    nome_amigo VARCHAR(100) NOT NULL,
    nome_mae VARCHAR(100) NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    local_amigo VARCHAR(10) NOT NULL,
    CONSTRAINT PK_id_amigo PRIMARY KEY (id_amigo),
)

CREATE TABLE Emprestimos
(
    id_emprestimo INT IDENTITY(1,1) NOT NULL,
    id_amigo INT NOT NULL,
    id_revista INT NOT NULL,
    data_emprestimo DATE NOT NULL,
    preco DECIMAL(38, 2) DEFAULT 0.0 NOT NULL,
    data_devolucao DATE NULL,
    CONSTRAINT PK_id_emprestimo PRIMARY KEY (id_emprestimo),
    CONSTRAINT FK_emprestimos_amigos FOREIGN KEY (id_amigo) REFERENCES Amigos(id_amigo),
    CONSTRAINT FK_emprestimos_revistas FOREIGN KEY (id_revista) REFERENCES Revistas(id_revista),
)

-- 2) Com o banco criado preencha o banco com 6 amigos diferentes, 10 revistas diferentes, e 10 empréstimos para os 6 amigos.
INSERT INTO Revistas
VALUES
    ('Batman', '5', 1992, 'preta'),
    ('Batman', '6', 1992, 'preta'),
    ('Batman', '7', 1992, 'preta'),
    ('Superman', '5', 1994, 'vermelha'),
    ('Superman', '8', 1994, 'vermelha'),
    ('Superman', '15', 1995, 'vermelha'),
    ('Homem Aranha', '12', 1996, 'vermelha'),
    ('Homem Aranha', '50', 2008, 'preta'),
    ('Homem Aranha', '541', 2015, 'preta'),
    ('Watchmen', '1', 2010, 'preta');

INSERT INTO Amigos
VALUES
    ('Miguel', 'Helena', '3333-1111', 'prédio'),
    ('Arthur', 'Alice', '3333-1111', 'escola'),
    ('Gael', 'Helena', '3333-1111', 'prédio'),
    ('Heitor', 'Laura', '3333-1111', 'prédio'),
    ('Theo', 'Maria Alice', '3333-1111', 'prédio'),
    ('Davi', 'Valentina', '3333-1111', 'escola');

INSERT INTO Emprestimos
VALUES
    (1, 1, '2022-06-10', DEFAULT, '2022-06-15'),
    (1, 2, '2022-06-10', DEFAULT, '2022-06-16'),
    (1, 3, '2022-06-14', DEFAULT, '2022-06-16'),
    (1, 4, '2022-07-10', DEFAULT, '2022-07-15'),
    (2, 1, '2022-07-10', DEFAULT, '2022-07-15'),
    (2, 2, '2022-08-10', DEFAULT, NULL),
    (2, 5, '2022-06-11', DEFAULT, '2022-06-15'),
    (3, 6, '2022-06-12', DEFAULT, NULL),
    (4, 7, '2022-06-13', DEFAULT, '2022-06-15'),
    (6, 8, '2022-06-14', DEFAULT, NULL);

-- 3) Crie um script que atualiza todos os preços dos empréstimos das revistas. Segue a lista de preços:18.25, 15.25, 11.25, 12.25, 14.25, 15.25, 17.25, 21.25, 8.25, 5.25 A edição pela ordem sequencial de cadastro. Ex: Id -> 1 Preco = 18.25...
UPDATE Emprestimos
SET preco = 
       CASE id_emprestimo
            WHEN 1 THEN 18.25
            WHEN 2 THEN 15.25
            WHEN 3 THEN 11.25
            WHEN 4 THEN 12.25
            WHEN 5 THEN 14.25
            WHEN 6 THEN 15.25
            WHEN 7 THEN 17.25
            WHEN 8 THEN 21.25
            WHEN 9 THEN 8.25
            WHEN 10 THEN 5.25
       END
WHERE id_emprestimo IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

-- 4) Crie um script para mostrar todos os empréstimos que o preço fique entre 12,00 e 16,00. Além disso mostre o identificador do emprestimo, a data de devolução e o nome de cada amigo.
SELECT e.id_emprestimo, a.nome_amigo, e.data_devolucao, e.preco
FROM Emprestimos e
    JOIN Amigos a ON (e.id_amigo = a.id_amigo)
WHERE preco > 12
    AND preco < 16;

-- 5) Crie um script para mostrar os empréstimos das revistas do tipo de coleção “Batman” e “Homem Aranha”. Mostre o identificador do empréstimo, a data de devolução, o preço e o tipo de coleção da revista.
SELECT e.id_emprestimo, e.data_devolucao, e.preco, r.tipo_colecao
FROM Emprestimos e
JOIN Revistas r ON (e.id_revista = r.id_revista)
WHERE r.tipo_colecao = 'Batman'
    OR r.tipo_colecao = 'Homem Aranha';

-- 6) Crie um script para todos os amigos que contém, outro que comece e outro que termine com a letra “A” no seu nome.
-- Contém
SELECT nome_amigo
FROM Amigos
WHERE nome_amigo LIKE '%A%';

-- Comece
SELECT nome_amigo
FROM Amigos
WHERE nome_amigo LIKE 'A%';

-- Termine
SELECT nome_amigo
FROM Amigos
WHERE nome_amigo LIKE '%A';

-- 7) Crie um script para mostrar a média, outro a soma, outro o maior valor, outro menor valor de preço de todas as revistas emprestadas em 2022. Utilize um alias para sinalizar cada um.
SELECT (SELECT CAST(AVG(preco) AS DECIMAL(38, 2))
    FROM Emprestimos) AS media_valor,
    (SELECT SUM(preco)
    FROM Emprestimos) AS soma_valor,
    (SELECT MAX(preco)
    FROM Emprestimos) AS valor_maximo;

-- 8) Crie um script para mostrar quantidade de amigos, revistas e emprestimos que existem hoje na base de dados. Utilize um alias para sinalizar cada um.
SELECT (SELECT COUNT(*)
    FROM Amigos) AS qtd_amigos,
    (SELECT COUNT(*)
    FROM Revistas) AS qtd_revistas,
    (SELECT COUNT(*)
    FROM Emprestimos) AS qtd_emprestimos;

-- 9) Crie um script que mostre o identificador de empréstimo, data de empréstimo, data de devolução, preço, o tipo de coleção da revista e o nome de cada amigo que emprestou. Ao final ordene pela data de devulução do empréstimo.
SELECT e.id_emprestimo, e.data_emprestimo, e.data_devolucao, e.preco, r.tipo_colecao, a.nome_amigo
FROM Emprestimos e
JOIN Revistas r ON (e.id_revista = r.id_revista)
JOIN Amigos a ON (e.id_amigo = a.id_amigo)
ORDER BY e.data_devolucao;

-- 10) Crie um script que limpa todos os dados de todas as tabelas na sequência Correta inclusive zerando os identificadores.
DELETE FROM Emprestimos;
DELETE FROM Revistas;
DELETE FROM Amigos;

DBCC CHECKIDENT(Amigos, RESEED, 0);
DBCC CHECKIDENT(Revistas, RESEED, 0);
DBCC CHECKIDENT(Emprestimos, RESEED, 0);
