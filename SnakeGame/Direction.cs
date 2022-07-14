namespace SnakeGame
{
    public class Direction
    {
        private readonly int dx;
        private readonly int dy;

        public static Direction Up = new Direction(0, 1);
        public static Direction Down = new Direction(0, -1);
        public static Direction Left = new Direction(1, 0);
        public static Direction Right = new Direction(-1, 0);

        public Direction(int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
        }
        
        public Point Next(Point point)
        {
            return new Point(point.X + dx, point.Y + dy);
        }
    }
}
