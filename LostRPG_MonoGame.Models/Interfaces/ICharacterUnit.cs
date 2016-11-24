using LostRPG_MonoGame.Models.GameEngine;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface ICharacterUnit : IUnit, IRenderable
    {
        void SetActiveAbility(string s);
        
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
