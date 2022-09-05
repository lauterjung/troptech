USE [master]
GO

DROP DATABASE IF EXISTS SECRETARIADB;
GO

CREATE DATABASE SECRETARIADB;
GO

USE SECRETARIADB;
GO

CREATE TABLE Salas
(
    sala_id INT IDENTITY(1,1) NOT NULL,
    nome_sala VARCHAR(20) NOT NULL,
    numero_lugares INT NOT NULL,
    CONSTRAINT PK_sala_id PRIMARY KEY (sala_id),
);

CREATE TABLE Funcionarios
(
    funcionario_id INT IDENTITY(1,1) NOT NULL,
    nome VARCHAR(200) NOT NULL,
    cargo VARCHAR(100) NOT NULL,
    ramal VARCHAR(5) NOT NULL,
    CONSTRAINT PK_funcionario_id PRIMARY KEY (funcionario_id),
);

CREATE TABLE Reservas
(
    reserva_id INT IDENTITY(1,1) NOT NULL,
    sala_id INT NOT NULL,
    data_hora_inicio DATETIME NOT NULL,
    data_hora_fim DATETIME NOT NULL,
    funcionario_id INT NOT NULL,
    CONSTRAINT PK_reserva_id PRIMARY KEY (reserva_id),
    CONSTRAINT FK_reserva_id_sala_id FOREIGN KEY (sala_id) REFERENCES Salas (sala_id),
    CONSTRAINT FK_reserva_id_funcionario_id FOREIGN KEY (funcionario_id) REFERENCES Funcionarios (funcionario_id),
);

INSERT INTO Salas VALUES
('Sala_1', 50),
('Sala_2', 60),
('Sala_3', 200);

INSERT INTO Funcionarios VALUES
('1', 'CEO', '1'),
('Miguel', 'Programador', '11111');

INSERT INTO Reservas VALUES
(1, '2022-09-01 13:00:00', '2022-09-01 16:00:00', 1),
(1, '2022-09-05 8:00:00', '2022-09-05 12:00:00', 1),
(1, '2022-09-06 8:00:00', '2022-09-06 2:00:00', 1);

SELECT * FROM Reservas
WHERE data_hora_inicio >= GETDATE();

SELECT r.*, f.nome AS nome_funcionario, s.nome_sala
FROM Reservas r
JOIN Salas s ON (r.sala_id = s.sala_id)
JOIN Funcionarios f ON (f.funcionario_id = r.funcionario_id)
WHERE data_hora_inicio >= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()));

SELECT * FROM Funcionarios
