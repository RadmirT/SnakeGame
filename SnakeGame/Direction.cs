namespace SnakeGame
{
    public class Direction
    {
        public static readonly Direction Up = new Direction(0, -1);
        public static readonly Direction Down = new Direction(0, 1);
        public static readonly Direction Left = new Direction(-1, 0);
        public static readonly Direction Right = new Direction(1, 0);
        
        private readonly int _dx;
        private readonly int _dy;

        private Direction(int dx, int dy)
        {
            _dx = dx;
            _dy = dy;
        }

        internal  Point Next(Point point)
        {
            return new Point(point.X + _dx, point.Y + _dy);
        }
        internal  Point Prev(Point point)
        {
            return new Point(point.X - _dx, point.Y - _dy);
        }
    }
}