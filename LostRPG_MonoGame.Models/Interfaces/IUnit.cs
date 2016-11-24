// ReSharper disable RedundantExtendsListEntry

using LostRPG_MonoGame.Models.Structure.Abilities;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IUnit : IGameObject, IMoveable, IRenderable
    {
        int CurrentHP { get; set; }

        int MaxHP { get; }

        int AttackPoints { get; set; }

        int DefensePoints { get; set; }

        bool IsAlive { get; set; }

        ReactionTypeEnum ReactToAbility(AbilityEffectEnum abilityEffect);
    }
}
