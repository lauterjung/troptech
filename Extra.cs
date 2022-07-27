using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultado = media >= 7 ? "Aprovado" : "Reprovado";
			
			Console.Clear();
        }
    }
}

Úteis no Console

cls -> utilize para limpar o console
dotnet new console -> utilizar para criar um novo projeto na última versão do .net instalada na sua máquina
dotnet new console --framework net5.0 -> utilize para criar um novo projeto na versão 5.0 quando existir uma versão mais nova instalada na máquina
cd {caminho de uma pasta} --> utilize para ir para alguma pasta no cmd
code -> utilize para abrir o code na pasta que está o cmd
dotnet run -> utilize para rodar o projeto
ctrl + k + c -> para comentar um código
ctrl + k + u -> para descomentar um código 
[21:09] Prof. Anna Laura: 🎬conteúdos Mais uma dica de atalhos, dessa vez do @Gabriel Henrique Almeida Ludwig. 

ALT + SHIFT + F -> Use para identar o código 

Console.CursorLeft

internalConsole - > “integratedTerminal”.

int[] x; // pode armazenar valores inteiros
string[] s; // pode armazenar valores em texto
double[] d; // pode armazenar valores numéricos com virgula
Student[] stud1; // pode armazenar objetos de classes


// Two-dimensional array.
int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// The same array with dimensions specified.
int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// A similar array with string elements.
string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

// Three-dimensional array.
int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };
// The same array with dimensions specified.
int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };

1. Referência:
using System.Collections.Generic;

2. Declaração:
LinkedList<string> listaVinculada;

3. Instanciação:
listaVinculada = new LinkedList<string>();

listaVinculada.AddFirst("Primeiro Item");
listaVinculada.AddLast("Último item");
listaVinculada.AddAfter(primeiroItem, "Segundo item");
listaVinculada.AddBefore(ultimoItem, "Penúltimo item");

LinkedListNode<string> primeiroItem = listaVinculada.First;
LinkedListNode<string> ultimoItem = listaVinculada.Last;
LinkedListNode<string> penultimoItem = listaVinculada.Find("Penultimo item");

• Acessando seu valor:
primeiroItem.Value;
ultimoItem.Value;
penultimoItem.Value;

for (var node = listaVinculada.First; node != null; node = node.Next)
{
Console.WriteLine(node.Value);
}

x.Find
        // Indicate 'fox' node.
        current = sentence.Find("fox");
        IndicateNode(current, "Test 7: Indicate the 'fox' node:");

        // Add 'quick' and 'brown' before 'fox':
        sentence.AddBefore(current, "quick");
        sentence.AddBefore(current, "brown");
        IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");
		
Stack pilha = new Stack();
pilha.Push(1);
pilha.Push("Thiago");
pilha.Push('T');
pilha.Push(1.2);
pilha.Push(true);
pilha.Pop();
pilha.Peek();
pilha.Clone();
pilha.Clear();
foreach (var elemento in coleção)

Queue fila = new Queue();
fila.Enqueue(1);

fila.Enqueue ("Thiago");
fila.Enqueue ('T');
fila.Enqueue (1.2);
fila.Enqueue (fase);

fila.Dequeue();
fila.Peek();
fila.Clone();
fila.Clear();
		
new DateTime (ano, mês, dia, hora, minuto, segundo)
CultureInfo idioma = new CultureInfo("pt-BR")
Console.WriteLine(data.ToString()); yyyy MM dd hh HH mm ss
String.Format
Short e LongTimeFormat?
Datetime é o tipo
TimeSpan

Convert.ToDateTime("2022-05-05")

string.IsEmpty() // orwhitespc

método
public [static] void Method(){}
public static int Soma(params int[] values)
{
	sum = 0;
	foreach(value in values)
	{
		sum += value;
	}	
	return(sum);
}


public override ToString (obj)

{
return string formatada
}

virtual // customização opcional, necessita constar na base
public // sem customização opcional, está na base
abstract // customização necessária, não está na base

KeyValuePair<string, bool>


//polimorfismo - sobrecarga
public static Number operator + (Number a, Number b)
{return (a._value + b._value)}

public static int operator + (int a, int b)
{return (a + b)}

public static bool operator true (Number a)
{return a._value != 0;}
public static bool operator true (Number a)
{return a._value == 0;}

public static explicit operator string(Number number)
{return Number._value.ToString();}

public static implicit operator string(Number number)
{return Number._value.ToString();}

// polimorfismo - paramétrico: classes ou tipos genéricos

typeof(x)
object.GetType()

// método genérico
static bool Is<T>(int value)
{return value.GetType() == typeof(T);}

static bool Is<T>(Object value)
{return value.GetType() == typeof(T);}
Is<int>(x)

// classe genérica
class Converter <T>
{
static bool Is(Object value)
{return value.GetType() == typeof(T);}
}
Converter<int>.Is(x)

// Polimorfismo de inclusão
class OperationFactory
{
	public static Operation Create (string @operator, decimal n1, decimal n2)
	=> @operator switch
	{
		"+" => new Addition(n1, n2),
		"-" => new Subtraction(n1, n2),
		"*" => new Multiplication(n1, n2),
		"/" => new Division(n1, n2),
		_ => throw new ArgumentException("Operacao nao suportada");
	};
}

readonly // sem set

como mostrar parâmetro na passagem do método? :

Object test = null;
List<string> list = new List<string>() {"a", "b"}

public class NewException : SystemException
{
	public NewException(string message) : base (message)
	{
	}
}

dotnet new sln
dotnet new sln --name Nome
dotnet new sln --output Nome
dotnet sln list
dotnet sln [arq sln] add [projeto]
dotnet sln [arq sln] remove [projeto]
dotnet add [projeto atual] reference [projeto a ser referenciado]
	using solution.class
	
dotnet new --list
dotnet new classlib -o NomeSolucao.Classes -f net6.0

DADO {ator = usuário}
QUANDO {ação}
E {parâmetros}
ENTÃO {resultado esperado}

Add_SingleNumber_ReturnsSameNumber()
Naming your tests
The name of your test should consist of three parts:
    The name of the method being tested.
    The scenario under which it's being tested.
    The expected behavior when the scenario is invoked.

Arranging your tests
Arrange, Act, Assert is a common pattern when unit testing. As the name implies, it consists of three main actions:
    Arrange your objects, creating and setting them up as necessary.
    Act on an object.
    Assert that something is as expected.

dotnet test

https://docs.microsoft.com/en-us/dotnet/api/nunit.framework.assert?view=xamarin-ios-sdk-12

var ex = Assert.Throws<Exception>(() => new Quadrado(-4));
Assert.That(ex.Message, Is.EqualTo("Mensagem"));

.NET Core Test Explorer

"dotnet-test-explorer.testProjectPath": "**/*Tests.@(csproj|vbproj|fsproj)"

localhost\SQLEXPRESS

CREATE DATABASE NOME;
DROP TABLE NOME;

CREATE TABLE CARRO (
PLACA VARCHAR(10) NOT NULL,
ANOFABRICAO INT NOT NULL,
MODELO VARCHAR(100),
VALORPEGADIO FLOAT NOT NULL,
TEMPODEUSO INT NOT NULL,
QTDADEPASSAGEIROS INT NULL
);


SELECT * FROM CARRO;

CREATE TABLE CAMINHAO (
PLACA VARCHAR(10) NOT NULL,
ANOFABRICACAO INT NOT NULL,
MODELO VARCHAR(100) NULL,
VALORPEGADIO FLOAT NOT NULL,
TEMPODEUSO INT NOT NULL,
PESOTOTAL FLOAT NOT NULL,
VALORCARGA MONEY NOT NULL
);

SELECT * FROM CAMINHAO;

CREATE TABLE PAGAMENTO (
MES INT NOT NULL,
SALARIO DECIMAL NOT NULL
);


Criar tabela e colunas:

	CREATE TABLE Produtos
	(
		NOME NVARCHAR(50) NULL,
		VALOR FLOAT NULL,
		VALIDADE DATETIME NULL
	);


Adcionar nova coluna:

	ALTER TABLE Produtos ADD
		QUANTIDADE int NULL

Alterando nome de uma coluna:

	EXEC sp_rename 'Produtos.VALOR', 'PRECO', 'COLUMN';

Alterando possibilidade de inserir nulo:

	ALTER TABLE Produtos ALTER COLUMN
		VALIDADE DATETIME NOT NULL;

	ALTER TABLE Produtos ALTER COLUMN
		PRECO INT NULL;


Alterando o Tipo de uma coluna:

	ALTER TABLE Produtos ALTER COLUMN 
		PRECO DECIMAL (5, 2);

	ALTER TABLE Produtos ALTER COLUMN 
		NOME VARCHAR(50);

Excluindo uma coluna:

	ALTER TABLE Produtos DROP COLUMN VALIDADE;

Documentações:

https://docs.microsoft.com/pt-br/dotnet/framework/data/adonet/sql-server-data-type-mappings
https://docs.microsoft.com/pt-br/sql/relational-databases/tables/create-tables-database-engine?view=sql-server-ver16

INSERT INTO Produtos
(Nome, Valor, Quantidade)
VALUES
(‘Televisão’, 1500, 100)

INSERT INTO Produtos
VALUES (‘Televisão’, 1500, 100)

INSERT INTO Produtos
VALUES (‘Televisão’, 1500, null)

SELECT
Nome,
Valor,
Quantidade
FROM Produtos

SELECT * FROM Produtos

UPDATE Produtos SET Nome = ‘SmartTV’ WHERE Nome =
‘Televisão’

DELETE FROM Produtos
WHERE Nome = ‘SmartTV’

AS = alias


USE GESTAOHOSPITALAR
CREATE TABLE PAGAMENTO (
ID INT IDENTITY(1,1) NOT NULL,
MES INT NOT NULL,
SALARIO DECIMAL NOT NULL,
CONSTRAINT PK_PAGAMENTO PRIMARY KEY (ID)
);
-- IDENTITY (N1,N2) N1 = VALOR 1 LINHA / N2 = INCREMENTO

ALTER TABLE ADD CONSTRAINT PK_PAGAMENTO PRIMARY KEY (ID)
ALTER TABLE VENDA ADD CONSTRAINT FK_PRODUTO FOREIGN KEY (PRODUTOID) REFERENCES PRODUTO (ID);


CREATE DATABASE CONTROLEESTOQUE;

USE CONTROLEESTOQUE
CREATE TABLE PRODUTO (
ID INT IDENTITY(1,1) NOT NULL,
NOME VARCHAR(50) NOT NULL,
PRECO FLOAT NOT NULL,
DESCRICAO VARCHAR(100),
QTDADEESTOQUE INT NOT NULL,
CONSTRAINT PK_PRODUTO PRIMARY KEY (ID));

USE CONTROLEESTOQUE
CREATE TABLE VENDA(
ID INT IDENTITY(1,1) NOT NULL,
PRODUTOID INT NOT NULL,
TOTAL FLOAT NOT NULL,
CONSTRAINT PK_VENDA PRIMARY KEY (ID),
CONSTRAINT FK_PRODUTO FOREIGN KEY (PRODUTOID) REFERENCES PRODUTO (ID));

USE CONTROLEESTOQUE 
CREATE TABLE PRODUTOSVENDA(
ID INT IDENTITY(1,1) NOT NULL,
VENDAID INT NOT NULL,
PRODUTOID INT NOT NULL,
CONSTRAINT PK_PRODUTOSVENDA PRIMARY KEY (ID),
CONSTRAINT FK_VENDA FOREIGN KEY (VENDAID) REFERENCES VENDA (ID),
CONSTRAINT FK_PRODUTO FOREIGN KEY (PRODUTOID) REFERENCES PRODUTO (ID)    
);


