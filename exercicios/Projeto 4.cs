using System;
using System.Collections;

namespace MiguelBusarelloLauterjungProjeto4
{
    class Program
    {
        const string msgGameTitle = "# JOGO DA VELHA #";
        const string msgWhoStarts = "Qual jogador irá começar (O ou X)? ";
        const string msgPlayPosition = "{0}, informe onde você deseja jogar (linha,coluna):";
        const string msgPlayTime = "Horário da jogada: {0}";
        const string msgEndGame = "Final de jogo!";
        const string msgDraw = "Empate";
        const string msgWinner = "Vencedor: ";
        const string msgWinningPlayer = "Jogador {0}";
        const string empty = " ";
        const string symbolExclamation = "!";
        const string symbolO = "O";
        const string symbolX = "X";
        const string playerO = "Jogador O";
        const string playerX = "Jogador X";
        const string boardVertical = "     |     |     ";
        const string boardHorizontal = "_____|_____|_____";
        const string boardInput = "  {0}  |  {1}  |  {2}  ";
        const string inputErrorNumberChar = "Número de caractéres inválido. Esperado 3 caractéres.";
        const string inputErrorSeparator = "Formato inválido. Use vírgula (,) como separador";
        const string inputErrorNonNumeric = "Caractéres não númericos identificados.";
        const string inputErrorOutOfBounds = "Número inválido. Use os números 0, 1 ou 2";
        const string inputErrorSlotTaken = "Posição já preenchida. Escolha outra jogada.";

        static void PrintBoard(string[,] boardMatrix)
        {
            Console.Clear();
            Console.WriteLine(boardVertical);
            Console.WriteLine(String.Format(boardInput, boardMatrix[0, 0], boardMatrix[0, 1], boardMatrix[0, 2]));
            Console.WriteLine(boardHorizontal);
            Console.WriteLine(boardVertical);
            Console.WriteLine(String.Format(boardInput, boardMatrix[1, 0], boardMatrix[1, 1], boardMatrix[1, 2]));
            Console.WriteLine(boardHorizontal);
            Console.WriteLine(boardVertical);
            Console.WriteLine(String.Format(boardInput, boardMatrix[2, 0], boardMatrix[2, 1], boardMatrix[2, 2]));
            Console.WriteLine(boardVertical);
        }

        static string DefineStartSymbol()
        {
            string symbol = empty;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msgGameTitle);
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.WriteLine(msgWhoStarts);
                symbol = Console.ReadLine().ToUpper();
                Console.WriteLine(symbol);
            }
            while ((symbol != symbolO) && (symbol != symbolX));

            return (symbol);
        }
        static Queue CreateQueue(string symbol)
        {
            string[] playerArray = { playerX, playerO, playerX, playerO, playerX, playerO, playerX, playerO, playerX };
            Queue playOrder = new Queue(playerArray);

            if (symbol == symbolO)
            {
                playOrder.Dequeue();
                playOrder.Enqueue(playerO);
            }

            return (playOrder);
        }

        static int[] PlayerInput(Queue playQueue, string[,] board)
        {
            int[] parsedPlayerInput = new int[2];

            while (true)
            {
                string consoleInput = empty;
                Console.WriteLine(String.Format(msgPlayPosition, playQueue.Peek()));
                consoleInput = Console.ReadLine();

                if (consoleInput.Length != 3) // erro
                {
                    Console.WriteLine(inputErrorNumberChar);
                    continue;
                }
                if (consoleInput[1] != ',')
                {
                    Console.WriteLine(inputErrorSeparator);
                    continue;
                }
                if (!Char.IsDigit(consoleInput[0]) || !Char.IsDigit(consoleInput[2]))
                {
                    Console.WriteLine(inputErrorNonNumeric);
                    continue;
                }

                string[] playerInputArray = consoleInput.Split(",");
                parsedPlayerInput[0] = Convert.ToInt32(playerInputArray[0]);
                parsedPlayerInput[1] = Convert.ToInt32(playerInputArray[1]);

                if (parsedPlayerInput[0] > 2 || parsedPlayerInput[1] > 2 || parsedPlayerInput[0] < 0 || parsedPlayerInput[1] < 0)
                {
                    Console.WriteLine(inputErrorOutOfBounds);
                    continue;
                }
                if (board[parsedPlayerInput[0], parsedPlayerInput[1]] != empty)
                {
                    Console.WriteLine(inputErrorSlotTaken);
                    continue;
                }

                playQueue.Dequeue();
                return (parsedPlayerInput);
            }
        }

        static string ChangeSymbol(string symbol)
        {
            if (symbol == symbolO)
            {
                return (symbolX);
            }
            else
            {
                return (symbolO);
            }
        }

        static void PrintTime()
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine(String.Format(msgPlayTime, currentTime.ToLongTimeString()));
        }

        static string CheckWin(string[,] board)
        {
            string winner = empty;
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i]) // col
                {
                    winner = board[0, i];
                    break;
                }
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) // line
                {
                    winner = board[i, 0];
                    break;
                }
            }

            if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) // diag 1
            || (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])) // diag 2
            {
                winner = board[1, 1];
            }

            return (winner);
        }

        static bool CheckGameOver(string winner, Queue queue)
        {
            bool gameOver = false;

            if (winner != empty)
            {
                gameOver = true;
            }

            if (queue.Count == 0)
            {
                gameOver = true;
            }
            return (gameOver);
        }

        static void PrintEndGame(string winner)
        {
            Console.WriteLine(msgEndGame);
            if (winner != empty)
            {
                Console.Write(msgWinner);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Format(msgWinningPlayer, winner));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(symbolExclamation);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(msgDraw);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(symbolExclamation);
            }
        }
        
        static void PlayGame()
        {
            bool gameOver = false;
            string winner = empty;
            string[,] boardMatrix = { { empty, empty, empty }, { empty, empty, empty }, { empty, empty, empty } };

            string symbol = DefineStartSymbol();
            Queue playOrder = CreateQueue(symbol);
            PrintBoard(boardMatrix);

            while (gameOver == false)
            {
                int[] playerInput = PlayerInput(playOrder, boardMatrix);
                boardMatrix[playerInput[0], playerInput[1]] = symbol;

                PrintBoard(boardMatrix);
                PrintTime();

                symbol = ChangeSymbol(symbol);
                winner = CheckWin(boardMatrix);
                gameOver = CheckGameOver(winner, playOrder);
            }
            PrintEndGame(winner);
        }

        static void Main(string[] args)
        {
            PlayGame();
        }
    }
}