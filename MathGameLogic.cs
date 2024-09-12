using System;
using System.Net.Http.Headers;


namespace Codereviews.Console.MathGame
{
    public class MathGameLogic
    {
        public List<string> GameHistory { get; set; } = new List<string>();
        public void ShowMenu()
        {
            System.Console.WriteLine("WELCOME TO MATH GAME");
            System.Console.WriteLine("ENTER YOUR NAME : ");
            string? myName = System.Console.ReadLine();

            System.Console.WriteLine("SELECT YOUR OPERATION :");
            System.Console.WriteLine("1 = 'Addition (+)'");
            System.Console.WriteLine("2 = 'Subtraction (-)'");
            System.Console.WriteLine("3 = 'Multiplication (x)'");
            System.Console.WriteLine("4 = 'Division (/)'");
            string? myOperation = System.Console.ReadLine();

            ShowSelectedOperation(Convert.ToInt32(myOperation));
        }

        public void ShowSelectedOperation(int paramSelectOperator)
        {
            switch (paramSelectOperator)
            {
                case 1:
                    System.Console.WriteLine("SELECTED OPERATOR: Addition");
                    break;
                case 2:
                    System.Console.WriteLine("SELECTED OPERATOR: Subtraction");
                    break;
                case 3:
                    System.Console.WriteLine("SELECTED OPERATOR: Multiplication");
                    break;
                case 4:
                    System.Console.WriteLine("SELECTED OPERATOR: Division");
                    break;
                default:
                    System.Console.WriteLine("SELECTED DEFAULT OPERATOR: Addition");
                    break;
            }

            GenerateRandNumbers(paramSelectOperator);

        }
        public void GenerateRandNumbers(int paramOperator)
        {
            Random ran1 = new Random();
            Random ran2 = new Random();

            int num1 = 0;
            int num2 = 0;
            int answer = 0;

            string equation;

            switch (paramOperator)
            {
                case 1:
                    num1 = ran1.Next(1,10);
                    num2 = ran2.Next(1,10);
                    answer = num1 + num2;
                    equation = num1.ToString() + "+" + num2.ToString();
                    break;
                case 2:
                    num1 = ran1.Next(11, 20);
                    num2 = ran2.Next(1, 10);
                    answer = num1 - num2;
                    equation = num1.ToString() + "-" + num2.ToString();
                    break;
                case 3:     
                    answer = num1 * num2;
                    equation = num1.ToString() + "*" + num2.ToString();
                    break;
                case 4:
                    answer = num1 / num2;
                    equation = num1.ToString() + "/" + num2.ToString();
                    break;
                default:
                    answer = num1 + num2;
                    equation = num1.ToString() + "+" + num2.ToString();
                    break;
            }

            System.Console.WriteLine(equation);
            CheckAnswer(answer, equation, paramOperator);
        }

        public void CheckAnswer(int paramAnswer, string paramEquation, int paramOperator)
        {
            System.Console.WriteLine("YOUR ANSWER: ");
            var myAnswer = System.Console.ReadLine();

            if (myAnswer != "")
            {
                if (Convert.ToInt32(myAnswer) != paramAnswer)
                {
                    System.Console.WriteLine("INCORRECT ANSWER!");
                    int countCorrect = GameHistory.Count();
                    System.Console.WriteLine("YOU GOT " + countCorrect + " CORRECT ANSWERS.");
                }
                else
                {
                    System.Console.WriteLine("CORRECT!");
                    GameHistory.Add(paramEquation);
                    GenerateRandNumbers(paramOperator);
                }
            }
            else
            {
                System.Console.WriteLine("BLANKS NOT ALLOWED");
                GenerateRandNumbers(paramOperator);
            }

        }


    }
}