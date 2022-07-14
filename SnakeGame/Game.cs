using System;

namespace SnakeGame
{
    internal class Game
    {
        private readonly int width = 30;
        private readonly int height = 40;
        private readonly ICanvas canvas;
        private Random random = new Random();
        Snake snake;
        Point eat;
        public Game(ICanvas canvas)
        {
            this.snake = new Snake(this.width / 2, this.height / 2, Direction.Left);
            PlaceEat();
            this.canvas = canvas;
        }

        private void PlaceEat()
        {
            var x = this.random.Next(width);
            var y = this.random.Next(height);
            eat = new Point(x, y);
        }

        public void Draw()
        {
            canvas.DrawBorder();
            this.snake.Draw(canvas);
            canvas.DrawEat(eat.X, eat.Y);
        }
    }
}
