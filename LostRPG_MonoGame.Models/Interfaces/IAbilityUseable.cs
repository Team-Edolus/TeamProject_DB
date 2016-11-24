using LostRPG_MonoGame.Models.GameEngine;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IAbilityUseable
    {
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
