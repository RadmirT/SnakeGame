namespace SnakeGame
{
    interface ICanvas
    {
        void DrawHead(IPoint point);
        void DrawBody(IPoint point);
        void EraseSegment(IPoint tail);
        void DrawEat(IPoint point);

        void DrawBoundary();
        int Width { get; }
        int Height { get; }
    }
}
