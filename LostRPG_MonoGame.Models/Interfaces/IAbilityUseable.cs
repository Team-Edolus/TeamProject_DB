namespace LostRPG_MonoGame.Models.Interfaces
{
    using LostRPG_MonoGame.Models.GameEngine;
    public interface IAbilityUseable
    {
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
