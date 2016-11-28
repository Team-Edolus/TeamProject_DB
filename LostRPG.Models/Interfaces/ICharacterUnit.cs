namespace LostRPG.Models.Interfaces
{
    using LostRPG.Models.Dynamics;

    public interface ICharacterUnit : IUnit
    {
        int Level { get; set; }

        int ExperiencePoints { get; set; }

        void SetActiveAbility(string s);
        
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
