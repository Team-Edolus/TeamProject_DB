namespace LostRPG.Models.Interfaces
{
    using LostRPG.Models.Dynamics;

    public interface IMoveable
    {
        Direction Direction { get; set; }

        int MovementSpeed { get; }

        void Move();
    }
}
