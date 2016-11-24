namespace LostRPG.Models.Interfaces
{
    using LostRPG.Models.Structure.Abilities;

    public interface IAbility
    {
        int VisualX { get; }

        int VisualY { get; }

        int VisualSizeX { get; }

        int VisualSizeY { get; }

        int Power { get; }

        IUnit Caster { get; }

        AbilityEffectEnum AbilityEffect { get; }
    }
}
