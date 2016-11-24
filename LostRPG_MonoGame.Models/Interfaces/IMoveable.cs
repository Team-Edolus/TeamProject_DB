using LostRPG_MonoGame.Models.GameEngine;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IMoveable
    {
        Direction Direction { get; set; }

        int MovementSpeed { get; }

        void Move();
    }
}
