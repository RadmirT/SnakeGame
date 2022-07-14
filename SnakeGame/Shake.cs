using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Snake
    {
        private Direction _direction;
        private const int InitShakeLength = 4;
        private int _growthPotential = 0;
            
        private readonly LinkedList<Point> _segments = new LinkedList<Point>();
        public Point Head => _segments.First();
        private Point Tail { get; set; }
        private IEnumerable<Point> Body => _segments.Skip(1); 
        public Snake(int headX, int headY, Direction direction)
        {
            _direction = direction;
            Tail = null;
            var  point= new Point(headX, headY);
            for (var i = 0; i < InitShakeLength ; i++)
            {
                _segments.AddLast(point);
                point = direction.Prev(point);
            }
        }

        internal void Draw(ICanvas canvas)
        {
            canvas.DrawHead(this.Head);
            foreach (var bodySegment in Body)
            {
                canvas.DrawBody(bodySegment);
            }

            if (Tail != null)
            {
                canvas.EraseSegment(this.Tail);
            }
        }

        public void SetDirection(Direction direction)
        {
            this._direction = direction;
        }

        internal void Move()
        {
            var newHead = this._direction.Next(Head);
            this._segments.AddFirst(newHead);
            if (_growthPotential == 0)
            {
                this.Tail = this._segments.Last();
                this._segments.RemoveLast();
            }
            else
            {
                _growthPotential--;
            }
        }
        public void Eat()
        {
            _growthPotential++;
        }

        public bool IsInsideOf(int left, int top, int right, int bottom)
        {
            foreach (var segment in this._segments)
            {
                if (segment.X < left || segment.X > right || segment.Y < top || segment.Y > bottom)
                {
                    return false;
                }
            }
            return true;
        }
        public bool HasSelfIntersect()
        {
            var hashset = new HashSet<Point>();
            foreach (var segment in this._segments)
            {
                if (!hashset.Contains(segment))
                {
                    hashset.Add(segment);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
