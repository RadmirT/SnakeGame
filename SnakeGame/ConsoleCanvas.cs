using System;

namespace SnakeGame
{
    internal class ConsoleCanvas : ICanvas
    {
        public ConsoleCanvas()
        {
            Console.CursorVisible = false;
        }
        public void DrawBody(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("#");
            Console.ResetColor();
        }

        public void DrawBorder()
        {
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("*");
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write("*");
            }

            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("*");
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write("*");
            }
        }

        public void DrawEat(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ResetColor();
        }

        public void DrawHead(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ResetColor();
        }
    }
}
