namespace LostRPG_MonoGame.Models.Interfaces
{
    using LostRPG_MonoGame.Models.Structure.Abilities;
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
