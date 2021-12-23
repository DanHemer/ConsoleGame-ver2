using System;
using System.Diagnostics;

namespace ConsoleGame
{
    class Program
    {


        static string[,] GameFieldInit()
        {
            int Length = 12;
            int Width = 22;
            string walls = "█";
            string[,] GameInit = new string[Length, Width];
            for (int i = 0; i < GameInit.GetLength(0); i++)
            {
                GameInit[i, 0] = walls;
                GameInit[i, GameInit.GetLength(1) - 1] = walls;
            }
            for (int k = 0; k < GameInit.GetLength(1); k++)
            {
                GameInit[0, k] = walls;
                GameInit[GameInit.GetLength(0) - 1, k] = walls;
            }

            for (int i = 0; i < GameInit.GetLength(0); i++)
            {
                for (int k = 0; k < GameInit.GetLength(1); k++)
                {
                    if (GameInit[i, k] == null)
                    {
                        GameInit[i, k] = " ";
                    }
                }
            }

            return GameInit;
        }
        static void GameMap(ref string[,] Game)
        {
            //Карта
            Game[1, 1] = Game[1, 3] = Game[1, 7] = Game[1, 16] = Game[2, 5] = Game[2, 7] = Game[2, 8] = Game[2, 9] = "█";
            Game[2, 11] = Game[2, 12] = Game[2, 13] = Game[2, 14] = Game[2, 16] = Game[2, 18] = Game[3, 2] = Game[3, 3] = "█";
            Game[3, 4] = Game[3, 5] = Game[3, 14] = Game[3, 18] = Game[3, 19] = Game[3, 20] = Game[4, 4] = Game[4, 5] = "█";
            Game[4, 5] = Game[4, 7] = Game[4, 8] = Game[4, 10] = Game[4, 11] = Game[4, 13] = Game[4, 14] = "█";
            Game[4, 15] = Game[4, 16] = Game[4, 17] = Game[4, 17] = Game[5, 2] = Game[5, 5] = Game[5, 9] = Game[5, 12] = "█";
            Game[5, 17] = Game[5, 19] = Game[5, 20] = Game[6, 3] = Game[6, 5] = Game[6, 7] = Game[6, 10] = Game[6, 14] = "█";
            Game[6, 19] = Game[7, 1] = Game[7, 3] = Game[7, 5] = Game[7, 6] = Game[7, 7] = Game[7, 8] = Game[7, 9] = "█";
            Game[7, 10] = Game[7, 12] = Game[7, 13] = Game[7, 14] = Game[7, 16] = Game[8, 2] = Game[8, 3] = Game[8, 9] = "█";
            Game[8, 12] = Game[8, 17] = Game[8, 18] = Game[8, 19] = Game[9, 4] = Game[9, 5] = Game[9, 7] = Game[9, 9] = "█";
            Game[9, 11] = Game[9, 13] = Game[9, 14] = Game[9, 15] = Game[9, 16] = Game[9, 17] = Game[10, 2] = Game[10, 7] = "█";
            Game[10, 7] = Game[10, 19] = Game[9, 10] = "█";

        }

        static void DrawGameField(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    Console.Write(array[i, k]);
                }
                Console.WriteLine();
            }
        }

        static void PlayerGoesLeft(ref string[,] Game, ref bool GirlCarried, ref int Lposition, ref int Wposition, ref string Player, int ExitPosL, int ExitPosW)
        {
            if (Game[Lposition, Wposition - 1] == "!")
            {
                Wposition = Wposition - 1;
                Game[Lposition, Wposition + 1] = " ";
                OpenExit(ref Game, ExitPosL, ExitPosW);
            }

            if (Game[Lposition, Wposition - 1] == "♀")
            {
                Wposition = Wposition - 1;
                Game[Lposition, Wposition + 1] = " ";
                GirlStatus(ref GirlCarried);
            }

            if (Game[Lposition, Wposition - 1] == " " || Game[Lposition, Wposition - 1] == "→")
            {
                Wposition = Wposition - 1;
                Game[Lposition, Wposition + 1] = " ";
            }
        }

        static void PlayerGoesUp(ref string[,] Game, ref bool GirlCarried, ref int Lposition, ref int Wposition, ref string Player, int ExitPosL, int ExitPosW)
        {
            if (Game[Lposition - 1, Wposition] == "!")
            {
                Lposition = Lposition - 1;
                Game[Lposition + 1, Wposition] = " ";
                OpenExit(ref Game, ExitPosL, ExitPosW);
            }

            if (Game[Lposition - 1, Wposition] == "♀")
            {
                Lposition = Lposition - 1;
                Game[Lposition + 1, Wposition] = " ";
                GirlStatus(ref GirlCarried);
            }

            if (Game[Lposition - 1, Wposition] == " " || Game[Lposition - 1, Wposition] == "→")
            {
                Lposition = Lposition - 1;
                Game[Lposition + 1, Wposition] = " ";
            }

        }

        static void PlayerGoesRight(ref string[,] Game, ref bool GirlCarried, ref int Lposition, ref int Wposition, ref string Player, int ExitPosL, int ExitPosW)
        {

            if (Game[Lposition, Wposition + 1] == "!")
            {
                Wposition = Wposition + 1;
                Game[Lposition, Wposition - 1] = " ";
                OpenExit(ref Game, ExitPosL, ExitPosW);
            }

            if (Game[Lposition, Wposition + 1] == "♀")
            {
                Wposition = Wposition + 1;
                Game[Lposition, Wposition - 1] = " ";
                GirlStatus(ref GirlCarried);
            }

            if (Game[Lposition, Wposition + 1] == " " || Game[Lposition, Wposition + 1] == "→")
            {
                Wposition = Wposition + 1;
                Game[Lposition, Wposition - 1] = " ";
            }

        }

        static void PlayerGoesDown(ref string[,] Game, ref bool GirlCarried, ref int Lposition, ref int Wposition, ref string Player, int ExitPosL, int ExitPosW)
        {
            if (Game[Lposition + 1, Wposition] == "!")
            {
                Lposition = Lposition + 1;
                Game[Lposition - 1, Wposition] = " ";
                OpenExit(ref Game, ExitPosL, ExitPosW);
            }

            if (Game[Lposition + 1, Wposition] == "♀")
            {
                Lposition = Lposition + 1;
                Game[Lposition - 1, Wposition] = " ";
                GirlStatus(ref GirlCarried);
            }

            if (Game[Lposition + 1, Wposition] == " " || Game[Lposition + 1, Wposition] == "→")
            {
                Lposition = Lposition + 1;
                Game[Lposition - 1, Wposition] = " ";
            }

        }

        static void PlayerControl(ref string[,] Game, ref bool GirlCarried, ref int Lposition, ref int Wposition, ref string Player, int ExitPosL, int ExitPosW)
        {

            ConsoleKey consolekey = Console.ReadKey().Key;


            switch (consolekey)
            {

                case ConsoleKey.LeftArrow:
                    {
                        PlayerGoesLeft(ref Game, ref GirlCarried, ref Lposition, ref Wposition, ref Player, ExitPosL, ExitPosW);

                    }
                    Game[Lposition, Wposition] = Player;
                    break;

                case ConsoleKey.UpArrow:
                    {
                        PlayerGoesUp(ref Game, ref GirlCarried, ref Lposition, ref Wposition, ref Player, ExitPosL, ExitPosW);

                    }
                    Game[Lposition, Wposition] = Player;
                    break;

                case ConsoleKey.RightArrow:
                    {
                        PlayerGoesRight(ref Game, ref GirlCarried, ref Lposition, ref Wposition, ref Player, ExitPosL, ExitPosW);

                    }
                    Game[Lposition, Wposition] = Player;
                    break;
                case ConsoleKey.DownArrow:
                    {
                        PlayerGoesDown(ref Game, ref GirlCarried, ref Lposition, ref Wposition, ref Player, ExitPosL, ExitPosW);
                    }
                    Game[Lposition, Wposition] = Player;
                    break;

            }


        }

        static void GirlStatus(ref bool GirlCarried)
        {
            GirlCarried = true;
        }

        static void OpenExit(ref string[,] Game, int ExitPosL, int ExitPosW)
        {
            Game[ExitPosL, ExitPosW] = "→";
        }

        static bool GameOn(bool won, bool lost)
        {
            if (won)
            {
                return false;
            }
            if (lost)
            {
                return false;
            }
            return true;
        }
        static bool PlayerDead()
        {
            return false;
        }
        static bool PlayerWon(int Lposition, int Wposition, int ExitPosL, int ExitPosW)
        {
            if (Wposition == ExitPosW)
            {
                return true;
            }
            return false;
        }

        static bool StepsCount(int NumberOfSteps, ref int CurrentNumber)
        {
            CurrentNumber += 1;
            if (CurrentNumber == NumberOfSteps)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string[,] Game = GameFieldInit();
            GameMap(ref Game);

            int Lposition = 2;
            int Wposition = 20;
            String Player = "♂";
            Game[Lposition, Wposition] = Player;

            int KeyLposition = 8;
            int KeyWposition = 10;
            String Key = "!";
            Game[KeyLposition, KeyWposition] = Key;

            int GirlLposition = 10;
            int GirlWposition = 1;
            String Girl = "♀";
            Game[GirlLposition, GirlWposition] = Girl;
            bool GirlCarried = false;

            int ExitPosL = 2;
            int ExitPosW = 21;

            bool won = false;
            bool lost = false;
            int NumberOfSteps = 175;
            int CurrentStepsNumber = 0;

            Stopwatch SpeedrunTime = new Stopwatch();
            SpeedrunTime.Start();

            while (GameOn(won, lost))
            {
                // PlayerPosition
                DrawGameField(Game);
                PlayerControl(ref Game, ref GirlCarried, ref Lposition, ref Wposition, ref Player, ExitPosL, ExitPosW);
                won = PlayerWon(Lposition, Wposition, ExitPosL, ExitPosW);
                lost = StepsCount(NumberOfSteps, ref CurrentStepsNumber);
            }

            SpeedrunTime.Stop();

            if (won == true && GirlCarried == false) Console.WriteLine($"Вы победили но не спасли девушку! Ваше время: {SpeedrunTime.Elapsed} Количесвто шагов: {CurrentStepsNumber}");
            if (won == true && GirlCarried == true) Console.WriteLine($"Вы победили и спасли девушку! Ваше время: {SpeedrunTime.Elapsed} Количесвто шагов: {CurrentStepsNumber}");
            if (lost == true && won != true) Console.WriteLine($"Вы проиграли! Вы исчерпали количество доступных шагов ({NumberOfSteps}) Ваше время: {SpeedrunTime.Elapsed}");
            Console.WriteLine();
            Console.WriteLine("Еще раз? Y/N");
            if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
            {
                Main(args);
            }




        }
    }
}

//Тест 1 - 7/10
//


//  case ConsoleKey.Escape:
//      break;
//  case ConsoleKey.Spacebar:
//      break;
