namespace LostRPG_MonoGame.Models.Interfaces
{
    using LostRPG_MonoGame.Models.GameEngine;
    public interface IMoveable
    {
        Direction Direction { get; set; }

        int MovementSpeed { get; }

        void Move();
    }
}
