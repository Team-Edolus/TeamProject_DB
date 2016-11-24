namespace LostRPG_MonoGame.Interfaces
{
    using LostRPG_MonoGame.GameEngine;

    public interface IAbilityUseable
    {
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
