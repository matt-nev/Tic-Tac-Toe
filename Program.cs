using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
            int winStatus = 0;
            int currentPlayer = -1;
            char[] boardSquare = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                Console.Clear();
                currentPlayer = GetNextPlayer(currentPlayer);
                GameDisplay(currentPlayer);
                GameBoard(boardSquare);
                GameFunction(boardSquare, currentPlayer);
                winStatus = CheckWin(boardSquare);

            }
            while (winStatus == 0);

            Console.Clear();
            GameDisplay(currentPlayer);
            GameBoard(boardSquare);

            if (winStatus == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPlayer {currentPlayer} wins!");
                Console.ResetColor();
            }

            if (winStatus == 2)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nThe game is a draw");
                Console.ResetColor();
            }

        }
        private static int CheckWin(char[] boardSquare)
        {
            if(IsGameDraw(boardSquare))
            {
                return 2;
            }
           
            if(IsGameWin(boardSquare))
            {
                return 1;
            }
            return 0;
        }

        private static bool IsGameDraw(char[] boardSquare)
        {
            return boardSquare[0] != '1' &&
                   boardSquare[1] != '2' &&
                   boardSquare[2] != '3' &&
                   boardSquare[3] != '4' &&
                   boardSquare[4] != '5' &&
                   boardSquare[5] != '6' &&
                   boardSquare[6] != '7' &&
                   boardSquare[7] != '8' &&
                   boardSquare[8] != '9';
        }

        private static bool IsGameWin(char[] boardSquare)
        {
            if (AreIconsTheSame(boardSquare, 0, 1 ,2))
            {
                return true;
            }
            if (AreIconsTheSame(boardSquare, 3, 4, 5))
            {
                return true;
            }
            if (AreIconsTheSame(boardSquare, 6, 7, 8))
            {
                return true;
            }
            if (AreIconsTheSame(boardSquare, 0, 3, 6))
            {
                return true;
            }
            if (AreIconsTheSame(boardSquare, 1, 4, 7))
            {
                return true;
            }
            if (AreIconsTheSame(boardSquare, 2, 5, 8))
            {
                return true;
            }
            if (AreIconsTheSame(boardSquare, 0, 4, 8))
            {
                return true;
            }
            if (AreIconsTheSame(boardSquare, 2, 4, 6))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool AreIconsTheSame(char[] testPlayerIcon, int pos1, int pos2, int pos3)
        {
            return testPlayerIcon[pos1] == testPlayerIcon[pos2] && testPlayerIcon[pos2] == testPlayerIcon[pos3];
        }
        private static void GameFunction(char[] boardSquare, int currentPlayer)
        {
            bool badMove = true;
            do
            {
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                    userInput == ("1") ||
                    userInput == ("2") ||
                    userInput == ("3") ||
                    userInput == ("4") ||
                    userInput == ("5") ||
                    userInput == ("6") ||
                    userInput == ("7") ||
                    userInput == ("8") ||
                    userInput == ("9"))

                {
                    int.TryParse(userInput, out var gameBoardSquare);
                    char currentSquare = boardSquare[gameBoardSquare - 1];

                    // X or O
                    if (currentSquare == 'X' || currentSquare == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Square is already taken, please select another one!\n\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        boardSquare[gameBoardSquare - 1] = GetPlayerIcon(currentPlayer);

                        badMove = false;
                    }
                }        
            }
            while (badMove);
        }

        private static char GetPlayerIcon(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }

        static void GameDisplay(int PlayerNumber)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player 1 is X\nPLayer 2 is O\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player {PlayerNumber}'s turn, please enter 1 through 9 to select your square.\n");
            Console.ResetColor();
        }

        static void GameBoard(char[] boardSquare)
        {
            Console.WriteLine($" {boardSquare[0]} | {boardSquare[1]} | {boardSquare[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {boardSquare[3]} | {boardSquare[4]} | {boardSquare[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {boardSquare[6]} | {boardSquare[7]} | {boardSquare[8]} \n");
        }

        static int GetNextPlayer(int player)
        {
            if(player == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}



