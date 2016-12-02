// ReSharper disable RedundantExtendsListEntry
namespace LostRPG_MonoGame.Models.Interfaces
{
    using LostRPG_MonoGame.Models.Structure.Abilities;
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
