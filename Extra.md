dotnet watch

dotnet new sln -o SalaReunioes
cd
dotnet new console -n SalaReunioes.ConsoleApp -f net5.0 
dotnet new classlib -n SalaReunioes.Domain -f net5.0 
dotnet new classlib -n SalaReunioes.Infra.Data -f net5.0
dotnet new webapi -n SalaReunioes.WebApi -f net5.0

dotnet sln add .\SalaReunioes.ConsoleApp\ 
dotnet sln add .\SalaReunioes.Domain\ 
dotnet sln add .\SalaReunioes.Infra.Data\ 
dotnet sln add .\SalaReunioes.WebApi\
dotnet add .\SalaReunioes.ConsoleApp\ reference .\SalaReunioes.Domain\ 
dotnet add .\SalaReunioes.ConsoleApp\ reference .\SalaReunioes.Infra.Data\ 
dotnet add .\SalaReunioes.Infra.Data\ reference .\SalaReunioes.Domain\ 
dotnet add .\SalaReunioes.WebApi\ reference .\SalaReunioes.Domain\ 
dotnet add .\SalaReunioes.WebApi\ reference .\SalaReunioes.Infra.Data\ 


cd 
dotnet add package System.Data.SqlClient

dotnet add
program template

using System;

namespace primeiro_projeto { class Program { static void Main(string[] args) { var resultado = media >= 7 ? "Aprovado" : "Reprovado";

        Console.Clear();
    }
}

}





Console

cls // utilize para limpar o console dotnet new console // utilizar para criar um novo projeto na última versão do .net instalada na sua máquina dotnet new console --framework net5.0 // utilize para criar um novo projeto na versão 5.0 quando existir uma versão mais nova instalada na máquina cd {caminho de uma pasta} // utilize para ir para alguma pasta no cmd code // utilize para abrir o code na pasta que está o cmd dotnet run // utilize para rodar o projeto

dotnet new sln dotnet new sln --name Nome dotnet new sln --output Nome // folder dotnet sln list dotnet sln [arq sln] add [projeto] dotnet sln [arq sln] remove [projeto] dotnet add [projeto atual] reference [projeto a ser referenciado] dotnet new --list dotnet new classlib -o NomeSolucao.Classes -f net6.0
VSCode Hotkeyes

ctrl + k + c -> para comentar um código ctrl + k + u -> para descomentar um código ALT + SHIFT + F -> Use para identar o código
Debug

internalConsole - > “integratedTerminal”.
C# console

Console.CursorLeft
Data types

int[] x; // pode armazenar valores inteiros string[] s; // pode armazenar valores em texto string.IsEmpty() // orwhitespc public override ToString (obj) double[] d; // pode armazenar valores numéricos com virgula Student[] stud1; // pode armazenar objetos de classes // Two-dimensional array. int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }; // The same array with dimensions specified. int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }; // A similar array with string elements. string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" }, { "five", "six" } }; // Three-dimensional array. int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } }; // The same array with dimensions specified. int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };

// linked list using System.Collections.Generic; LinkedList<string> listaVinculada; listaVinculada = new LinkedList<string>();

listaVinculada.AddFirst("Primeiro Item"); listaVinculada.AddLast("Último item"); listaVinculada.AddAfter(primeiroItem, "Segundo item"); listaVinculada.AddBefore(ultimoItem, "Penúltimo item");

LinkedListNode<string> primeiroItem = listaVinculada.First; LinkedListNode<string> ultimoItem = listaVinculada.Last; LinkedListNode<string> penultimoItem = listaVinculada.Find("Penultimo item");

primeiroItem.Value;

for (var node = listaVinculada.First; node != null; node = node.Next) { Console.WriteLine(node.Value); }

x.Find // Indicate 'fox' node. current = sentence.Find("fox");

// Add 'quick' and 'brown' before 'fox': sentence.AddBefore(current, "quick"); sentence.AddBefore(current, "brown");

// Stack Stack pilha = new Stack(); pilha.Push(1); pilha.Pop(); pilha.Peek(); pilha.Clone(); pilha.Clear(); foreach (var elemento in coleção)

// Queue Queue fila = new Queue(); fila.Enqueue(1);

fila.Enqueue ("Thiago");

fila.Dequeue(); fila.Peek(); fila.Clone(); fila.Clear();

// DateTime new DateTime (ano, mês, dia, hora, minuto, segundo) CultureInfo idioma = new CultureInfo("pt-BR") Convert.ToDateTime("2022-05-05")
Methods

public [static] void Method(){} public static int Soma(params int[] values) { sum = 0; foreach(value in values) { sum += value; }
return(sum); }

como mostrar parâmetro na passagem do método? :
OoP

// Modificadores readonly // sem set static public private ...

virtual // customização opcional, necessita constar na base public // sem customização opcional, está na base abstract // customização necessária, não está na base

//polimorfismo - sobrecarga public static Number operator + (Number a, Number b) {return (a.value + b.value)}

public static int operator + (int a, int b) {return (a + b)}

public static bool operator true (Number a) {return a._value != 0;}

public static bool operator true (Number a) {return a._value == 0;}

public static explicit operator string(Number number) {return Number._value.ToString();}

public static implicit operator string(Number number) {return Number._value.ToString();}

// polimorfismo - paramétrico: classes ou tipos genéricos typeof(x) object.GetType()

// método genérico static bool Is<T>(int value) {return value.GetType() == typeof(T);}

static bool Is<T>(Object value) {return value.GetType() == typeof(T);} Is<int>(x)

// classe genérica class Converter <T> { static bool Is(Object value) {return value.GetType() == typeof(T);} } Converter<int>.Is(x)

// Polimorfismo de inclusão class OperationFactory { public static Operation Create (string @operator, decimal n1, decimal n2) => @operator switch { "+" => new Addition(n1, n2), "-" => new Subtraction(n1, n2), "*" => new Multiplication(n1, n2), "/" => new Division(n1, n2), _ => throw new ArgumentException("Operacao nao suportada"); }; }

Object test = null; List<string> list = new List<string>() {"a", "b"}

public class NewException : SystemException { public NewException(string message) : base (message) { } }
Testing

DADO {ator = usuário} QUANDO {ação} E {parâmetros} ENTÃO {resultado esperado}

AddSingleNumberReturnsSameNumber() Naming your tests The name of your test should consist of three parts: The name of the method being tested. The scenario under which it's being tested. The expected behavior when the scenario is invoked.

Arranging your tests Arrange, Act, Assert is a common pattern when unit testing. As the name implies, it consists of three main actions: Arrange your objects, creating and setting them up as necessary. Act on an object. Assert that something is as expected.

dotnet test

https://docs.microsoft.com/en-us/dotnet/api/nunit.framework.assert?view=xamarin-ios-sdk-12

var ex = Assert.Throws<Exception>(() => new Quadrado(-4)); Assert.That(ex.Message, Is.EqualTo("Mensagem"));

.NET Core Test Explorer

"dotnet-test-explorer.testProjectPath": "*/Tests.@(csproj|vbproj|fsproj)"
SQL

localhost\SQLEXPRESS // host .\SQLEXPRESS // host
data types

https://docs.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16 https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types

// create CREATE DATABASE NOME; DROP TABLE NOME;

CREATE TABLE CARRO ( PLACA VARCHAR(10) NOT NULL, ANOFABRICAO INT NOT NULL, MODELO VARCHAR(100), VALORPEGADIO FLOAT, -- default = NULL TEMPODEUSO INT NOT NULL, QTDADEPASSAGEIROS INT NULL );

SELECT * FROM CARRO;

Adcionar nova coluna: ALTER TABLE Produtos ADD QUANTIDADE int NULL

Alterando nome de uma coluna: EXEC sp_rename 'Produtos.VALOR', 'PRECO', 'COLUMN';

Alterando possibilidade de inserir nulo: ALTER TABLE Produtos ALTER COLUMN VALIDADE DATETIME NOT NULL; ALTER TABLE Produtos ALTER COLUMN PRECO INT NULL;

Alterando o Tipo de uma coluna: ALTER TABLE Produtos ALTER COLUMN PRECO DECIMAL (5, 2); ALTER TABLE Produtos ALTER COLUMN NOME VARCHAR(50);

Excluindo uma coluna: ALTER TABLE Produtos DROP COLUMN VALIDADE;

INSERT INTO Produtos (Nome, Valor, Quantidade) VALUES (‘Televisão’, 1500, 100)

INSERT INTO Produtos VALUES (‘Televisão’, 1500, 100), (‘Televisão 2’, 1500, null);

UPDATE Produtos SET Nome = ‘SmartTV’ WHERE Nome = ‘Televisão’

DELETE FROM Produtos WHERE Nome = ‘SmartTV’

AS = alias

USE GESTAOHOSPITALAR CREATE TABLE PAGAMENTO ( ID INT IDENTITY(1,1) NOT NULL, MES INT NOT NULL, SALARIO DECIMAL NOT NULL, CONSTRAINT PK_PAGAMENTO PRIMARY KEY (ID) ); -- IDENTITY (N1,N2) N1 = VALOR 1 LINHA / N2 = INCREMENTO

ALTER TABLE ADD CONSTRAINT PKPAGAMENTO PRIMARY KEY (ID) ALTER TABLE VENDA ADD CONSTRAINT FKPRODUTO FOREIGN KEY (PRODUTOID) REFERENCES PRODUTO (ID);

CREATE DATABASE CONTROLEESTOQUE;

USE CONTROLEESTOQUE CREATE TABLE PRODUTO ( ID INT IDENTITY(1,1) NOT NULL, NOME VARCHAR(50) NOT NULL, PRECO FLOAT NOT NULL, DESCRICAO VARCHAR(100), QTDADEESTOQUE INT NOT NULL, CONSTRAINT PK_PRODUTO PRIMARY KEY (ID));

USE CONTROLEESTOQUE CREATE TABLE VENDA( ID INT IDENTITY(1,1) NOT NULL, PRODUTOID INT NOT NULL, TOTAL FLOAT NOT NULL, CONSTRAINT PKVENDA PRIMARY KEY (ID), CONSTRAINT FKPRODUTO FOREIGN KEY (PRODUTOID) REFERENCES PRODUTO (ID));

USE CONTROLEESTOQUE CREATE TABLE PRODUTOSVENDA( ID INT IDENTITY(1,1) NOT NULL, VENDAID INT NOT NULL, PRODUTOID INT NOT NULL, CONSTRAINT PKPRODUTOSVENDA PRIMARY KEY (ID), CONSTRAINT FKVENDA FOREIGN KEY (VENDAID) REFERENCES VENDA (ID), CONSTRAINT FK_PRODUTO FOREIGN KEY (PRODUTOID) REFERENCES PRODUTO (ID)
);

SELECT L.ID, L.NOME, F.ID, F.TITULO FROM FILME F INNER JOIN LOCATORIO L ON (L.ID = F.LOCATORIOID)

SELECT L.ID, L.NOME, F.ID, F.LOCATORIOID, F.TITULO FROM FILME F LEFT JOIN LOCATORIO L ON (L.ID = F.LOCATORIOID)

SELECT L.ID, L.NOME, F.ID, F.LOCATORIOID, F.TITULO FROM FILME F RIGHT JOIN LOCATORIO L ON (L.ID = F.LOCATORIOID)

SELECT L.ID, L.NOME, F.ID, F.LOCATORIOID, F.TITULO FROM FILME F FULL JOIN LOCATORIO L ON (L.ID = F.LOCATORIOID)

SELECT * FROM Professores

SELECT AVG(ValorHora) AS MediaValorHora FROM Professores; SELECT COUNT(ProfessorAutor) AS NumeroProfessores FROM Professores; SELECT MAX(CargaHoraria) AS MaiorCargaHoraria FROM Professores; SELECT MIN(CargaHoraria) AS MenorCargaHoraria FROM Professores; SELECT SUM(ValorHora) AS TotalValorHora FROM Professores;

SELECT GETDATE() AS DataAtual; SELECT DAY(DataNascimento) AS DiaDoMes FROM Professores; SELECT DAY(GETDATE()) AS DiaDeHoje; SELECT ISDATE(DataNascimento) AS EhUmaData FROM Professores; SELECT ISDATE(Endereco) AS EhUmaData FROM Professores; SELECT MONTH(DataNascimento) as Mes FROM Professores; SELECT YEAR(DataNascimento) as Ano FROM Professores; SELECT DATEADD(YEAR, 1, DataNascimento) as AnoAdicionado FROM Professores; SELECT DATEADD(MONTH, 2, DataNascimento) as MesAdicionado FROM Professores; SELECT DATEADD(DAY, 10, DataNascimento) as DiaAdicionado FROM Professores;

SELECT SUBSTRING(Endereco, 1, 3) AS TextoExtraido FROM Professores; SELECT REPLACE(Endereco, 'Rua', 'R.') AS EnderecoAlterado FROM Professores; SELECT LOWER(NomeCompleto) as NomeMinusculo FROM Professores; SELECT UPPER(NomeCompleto) as NomeMaiusculo FROM Professores; SELECT CONCAT(NomeCompleto, ', ', Endereco) AS NomeEEndereco FROM Professores;

SELECT @@SERVERNAME; SELECT @@SERVICENAME; SELECT @@VERSION; SELECT @@LANGUAGE;

SELECT NomeCompleto, DataNascimento, CargaHoraria, COALESCE(Endereco, 'Não informado') AS Endereco FROM Professores; SELECT NEWID(); SELECT CAST(ValorHora AS INT) AS ValorConvertido FROM Professores;

SELECT TOP(2) * FROM Professores;

UPDATE Professores SET Endereco = REPLACE(Endereco, 'Rua', 'R.')

CREATE TABLE ENDERECOESTACIONAMENTO( ID INT NOT NULL, RUA VARCHAR(100) NOT NULL, NUMERO INT NOT NULL, BAIRRO VARCHAR(100) NOT NULL, CIDADE VARCHAR(100) NOT NULL, ESTADO VARCHAR(100) NOT NULL );

CREATE CLUSTERED INDEX PKIDENDERECO ON ENDERECOESTACIONAMENTO (ID);

CREATE NONCLUSTERED INDEX IX_RUA ON ENDERECOESTACIONAMENTO (RUA);

SELECT * FROM ENDERECOESTACIONAMENTO WHERE RUA = 'LALA'

SELECT * FROM CLIENTE

create NONCLUSTERED INDEX IXNOMECLIENTE ON CLIENTE (NOME);

INSERT INTO CLIENTE (CPF, NOME, DATANASCIMENTO) VALUES (59837066082, 'Eduardo', '31-01-2000');

delete from cliente where CPF = 59837066082

CREATE UNIQUE INDEX IXU_NOME ON CLIENTE (Nome);

SELECT NOME, CPF FROM CLIENTE WHERE DATANASCIMENTO = '24-05-1994'

create NONCLUSTERED INDEX ixDATANASCIMENTOcpf on cliente (DATANASCIMENTO) INCLUDE (Nome, cpf);

DROP INDEX ixDATANASCIMENTOcpf ON CLIENTE;

ALTER INDEX IXU_NOME ON CLIENTE REBUILD;

ALTER INDEX IXU_NOME ON CLIENTE REORGANIZE;

dotnet add package System.Data.SqlClient

server=INSTANCIABANCO;database=NOMEBANCO;user id=USUARIO;word=SENHA; Ou Data Source=INSTANCIABANCO;initial catalog=NOMEBANCO;uid=USUARIO;pwd= SENHA;

string connectionString = "server=.\SQLexpress;initial catalog=NOME_BANCO;integrated security=true"; SqlConnection conection = new SqlConnection(connectionString);

SqlConnection conection = new SqlConnection(); connection.ConnectionString = connectionString;

connection.Open(); connection.Close();

INTO? SqlCommand command = new SqlCommand("INSERT ALUNO VALUES(25548, 'LUIZ SUAREZ', 36)", connection); command.ExecuteNonQuery();

SqlCommand command = new SqlCommand(); command.Connection(connection); command.CommandText = @"INSERT ALUNO VALUES(25548, 'LUIZ SUAREZ', 36)"; connection.ExecuteNonQuery();

command.CommandText = @"SELECT * FROM Alunos"; SqlDataReader leitor = command.ExecuteReader();

while(leitor.Read()) { var matricula = leitor[0]; var matricula2 = leitor["matricula"]; }

var matricula = 1234; SqlParameter parameter = new SqlParameter(); parameter.ParameterName = "@MATRICULA"; parameter.Value = matricula;

command.Parameters.Add(parameter); command.Parameters.AddWithValue("@MATRICULA", matricula);

using (SqlConnection connection = new SqlConnection(_connectionString)) { connection.Open();

using (SqlCommand command = new SqlCommand(connection))
{
    string sql = @"SELECT * FROM X";
    command.CommandText = sql;
    command.ExecuteNonQuery();
}

}

Sln

    Sln.ConsoleApp (Console App) (conhece todos) Sln.Domain (Class Lib) (não conhece ninguém) Sln.Infra.Data (Class Lib) (conhece domain)

public IActionResult Get()
return Ok(); // 200
return NoContent(); // 204
return BadRequest(); // 400


ActionResult<T>