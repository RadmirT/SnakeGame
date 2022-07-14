namespace SnakeGame
{
    public interface ICanvas
    {
        void DrawHead(int x, int y);
        void DrawBody(int x, int y);
        void DrawBorder();
        void DrawEat(int x, int y);
    }
}
