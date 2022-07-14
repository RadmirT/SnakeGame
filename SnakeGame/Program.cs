using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var canvas = new ConsoleCanvas();
            var area = new Game(canvas);
            bool exit = false;
            do
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            area.Snake.SetDirection(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            area.Snake.SetDirection(Direction.Down);
                            break;
                        case ConsoleKey.LeftArrow:
                            area.Snake.SetDirection(Direction.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            area.Snake.SetDirection(Direction.Right);
                            break;
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                    }
                }

                area.Tick();
                area.Draw();
                Thread.Sleep(150);
            }
            while (!exit && !area.IsGameOver());

            string message = "Game Over!!!!";
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ReadKey();
            Console.ResetColor();

        }
    }
}
