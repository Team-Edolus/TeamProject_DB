namespace LostRPG_MonoGame.Interfaces
{
    using LostRPG_MonoGame.GameEngine;

    public interface ICharacterUnit : IUnit, IRenderable
    {
        void SetActiveAbility(string s);
        
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
