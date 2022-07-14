using SnakeGame;
using System;

namespace SnackGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var canvas = new ConsoleCanvas();
            var game = new Game(canvas);
            game.Draw();
            Console.ReadKey();
        }
    }
}
