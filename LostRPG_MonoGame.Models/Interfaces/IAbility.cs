using LostRPG_MonoGame.Models.Structure.Abilities;

namespace LostRPG_MonoGame.Models.Interfaces
{
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
