namespace Dota
{
    public interface IMovable
    {
        void Draw();
        void ClearPath();
        void Move(int x, int y);
    }
}
