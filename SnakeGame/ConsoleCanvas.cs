
using System;

namespace SnakeGame
{
    class ConsoleCanvas : ICanvas
    {
        public ConsoleCanvas()
        {
            Console.CursorVisible = false;
        }

        private IPoint ToPhysicalPoint(IPoint point)
        {
            return new Point(point.X + 2, point.Y + 2);
        }
        private bool IsInVisibleArea(IPoint point)
        {
            return point.X >= 1 && point.Y >= 1 && point.X < Console.WindowWidth && point.Y < Console.WindowHeight;
        }
        public void DrawHead(IPoint point)
        {
            var physicalPoint = ToPhysicalPoint(point);
            if (!IsInVisibleArea(physicalPoint))
            {
                return;
            }
            Console.SetCursorPosition(physicalPoint.X, physicalPoint.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.ResetColor();
        }

        public void DrawBody(IPoint point)
        {
            var physicalPoint = ToPhysicalPoint(point);
            if (!IsInVisibleArea(physicalPoint))
            {
                return;
            }
            Console.SetCursorPosition(physicalPoint.X, physicalPoint.Y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("#");
            Console.ResetColor();
        }

        public void EraseSegment(IPoint point)
        {
            var physicalPoint = ToPhysicalPoint(point);
            if (!IsInVisibleArea(physicalPoint))
            {
                return;
            }
            Console.SetCursorPosition(physicalPoint.X, physicalPoint.Y);
            Console.ResetColor();
            Console.Write(" ");
        }

        /// <inheritdoc />
        public void DrawEat(IPoint point)
        {
            var physicalPoint = ToPhysicalPoint(point);
            if (!IsInVisibleArea(physicalPoint))
            {
                return;
            }
            Console.SetCursorPosition(physicalPoint.X, physicalPoint.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ResetColor();
        }


        /// <inheritdoc />
        public int Width => Console.WindowWidth - 4;

        /// <inheritdoc />
        public int Height =>Console.WindowHeight- 4;

        public void DrawBoundary()
        {
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i,1);
                Console.Write("*");
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write("*");
            }

            for (int i = 1; i < Console.WindowHeight-1; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("*");
                Console.SetCursorPosition(Console.WindowWidth-1, i);
                Console.Write("*");
            }
        }
    }
}
