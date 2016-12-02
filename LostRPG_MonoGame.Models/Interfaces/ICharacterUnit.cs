namespace LostRPG_MonoGame.Models.Interfaces
{
    using LostRPG_MonoGame.Models.GameEngine;
    public interface ICharacterUnit : IUnit, IRenderable
    {
        void SetActiveAbility(string s);
        
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
