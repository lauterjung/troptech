USE HOSPITALDB;
GO

-- EX 1
INSERT INTO Pacientes
VALUES
    ('Fabiano de Souza', 08525566899, 'Rua Ceará, 589, Bairro São Cristóvão, Lages-SC', 1, 'unimed', '49 8895-8854', 'Maria de Souza');

-- EX2
INSERT INTO Pacientes
    (nome_completo, nome_completo_mae, cpf, endereco_completo, possui_plano_saude, nome_plano_saude, telefone)
VALUES
    ('Marizete Pereira', 'Maria Alzete Pereira', 8525578988, 'Rua Pernambuco, 789, Bairro São Cristóvão, Lages-SC', 0, NULL, '49 9985-9966');

-- EX3
UPDATE Pacientes SET endereco_completo = 'Rua Acre, 888, Bairro São Cristóvão, Lages-SC' 
WHERE cpf = 08525566899;

-- EX4
DELETE FROM Pacientes 
WHERE cpf = 08525578988;

-- EX5
SELECT *
FROM Pacientes;

-- EX6
SELECT cpf, possui_plano_saude
FROM Pacientes;

-- EX7
INSERT INTO Cirurgias
    (nome_paciente, nome_medico, data_agendada, sala_cirurgica, nome_cirurgia, requer_acompanhante)
VALUES
    ('Fabiano de Souza', 'José Amaral', '2022-08-24', 'Sala 4', 'amigdalectomia', 1);

-- EX8
ALTER TABLE Cirurgias ADD
	nome_acompanhante NVARCHAR(100) NULL;

-- EX9
INSERT INTO Cirurgias
    (nome_medico, data_agendada, sala_cirurgica, nome_cirurgia, requer_acompanhante)
VALUES
    ('Adair Silva', '2022-08-27', 'Sala 5', 'vasectomia', 0);

-- EX10
UPDATE Cirurgias SET nome_paciente = '(sem nome)' 
WHERE nome_paciente IS NULL;

ALTER TABLE Cirurgias ALTER COLUMN 
    nome_paciente NVARCHAR(100) NOT NULL;