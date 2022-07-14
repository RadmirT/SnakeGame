using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public class Snake
    {
        private const int InitShakeLength = 4;
        private readonly Direction direction;
        private readonly List<Point> _segmnet = new List<Point>();
        private Point Head => _segmnet[0];
        private IEnumerable<Point> Body => _segmnet.Skip(1);

        public Snake(int headX, int headY, Direction direction)
        {
            var x = headX;
            var y = headY;
            this.direction = direction;
            var point = new Point(x, y);
            for (var i = 0; i < InitShakeLength; i++)
            {
                _segmnet.Add(point);
                point = this.direction.Next(point);
            }
        }

        public void Draw(ICanvas canvas)
        {
            canvas.DrawHead(Head.X, Head.Y);
            foreach (var point in Body)
            {
                canvas.DrawBody(point.X, point.Y);
            }
        }
    }
}
