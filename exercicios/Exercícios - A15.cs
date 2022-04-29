using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            // ex 1
            int rightAnswers = 0;
            int roundNumber = 1;
            Console.WriteLine("Quiz!");
            while(rightAnswers < 10)
            {
                int firstNumber = new Random().Next(1, 10);
                int secondNumber = new Random().Next(1, 10);
                int correctAnswer = firstNumber * secondNumber;

                Console.Write($"Question {roundNumber}: {firstNumber} x {secondNumber} = ");
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                roundNumber++;

                if(userAnswer == correctAnswer)
                {
                    Console.WriteLine("Thats right!");
                    rightAnswers++;
                }
                else
                {
                    Console.WriteLine($"The right answer was {correctAnswer}");
                }

                if(roundNumber == 10)
                {
                    if(rightAnswers == 10)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($" You got {rightAnswers} right answers. Try again!");
                        rightAnswers = 0;
                    }
                }     
            }

            // ex 2
            Console.WriteLine("Inform the number of studied weeks");
            int studiedWeeks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inform the number of days studied in a week");
            int studiedDays = Convert.ToInt32(Console.ReadLine());
            int totalDays = 0;
            Console.Clear();
            for(int i = 1; i <= studiedWeeks; i++)
            {
                Console.WriteLine($"Week: {i}");
                for(int j = 1; j <= studiedDays; j++)
                {
                    Console.CursorLeft = 1;
                    Console.WriteLine($"Day: {j}");
                    totalDays++;
                }
            }
            Console.WriteLine($"You studied: {totalDays} day(s)");
            
            // ex 3
            int answerEx3 = 0;
            int leftPos = 0;
            for(int i = 1; i <= 10; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    answerEx3 = i * j;
                    Console.CursorLeft = leftPos;
                    leftPos += 8;
                    Console.Write($"{i}x{j}={answerEx3}");
                }
                leftPos = 0;
                Console.WriteLine();
            }
        }
    }
}
