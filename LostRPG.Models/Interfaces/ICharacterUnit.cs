namespace LostRPG.Models.Interfaces
{
    using LostRPG.Models.Dynamics;

    public interface ICharacterUnit : IUnit, IRenderable
    {
        void SetActiveAbility(string s);
        
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
