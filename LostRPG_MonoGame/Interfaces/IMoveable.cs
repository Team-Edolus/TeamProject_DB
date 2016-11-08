namespace LostRPG_MonoGame.Interfaces
{
    using LostRPG_MonoGame.GameEngine;

    public interface IMoveable
    {
        Direction Direction { get; set; }

        int MovementSpeed { get; }

        void Move();
    }
}
