using System;
using System.Threading;

namespace SnakeGame
{
    internal class Game
    {
        private readonly int width;
        private readonly int height;
        private readonly ICanvas canvas;
        private bool isGameOver = false;
        private Random random = new Random();
        private Point eat;
        public Game(ICanvas canvas)
        {
            this.width = canvas.Width;
            this.height = canvas.Height;
            this.canvas = canvas;
            PlaceEat();
            this.Snake = new Snake(this.width / 2, this.height / 2, Direction.Left);
        }

    private void PlaceEat()
    {
        var x = this.random.Next(this.canvas.Width);
        var y = this.random.Next(this.canvas.Height);
        this.eat = new Point(x, y);
    }
        public void Draw()
        {
            canvas.DrawBoundary();
            this.Snake.Draw(canvas);
            canvas.DrawEat(this.eat);
        }

        public bool IsGameOver()
        {
            return isGameOver;
        }

        public void Tick()
        {
            if (this.Snake.Head.Equals(this.eat))
            {
                this.Snake.Eat();
                this.PlaceEat();
            }
            this.Snake.Move();
            if (!this.Snake.IsInsideOf(0, 0, width, this.height) || this.Snake.HasSelfIntersect())
            {
                this.isGameOver = true;
            }
        }
        public Snake Snake { get; }
    }
}
