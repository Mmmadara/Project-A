namespace Interfaces
{
    public interface IMovable
    {
        int Speed { get; set; }

        void Move();

        void FixedMove();
    }
}