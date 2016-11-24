namespace LostRPG.Models.Interfaces
{
    using LostRPG.Models.Dynamics;

    public interface IAbilityUseable
    {
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
