namespace LostRPG_MonoGame.Models.Structure.Abilities
{
    using LostRPG_MonoGame.Models.Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MaleeAbility")]

    public abstract class MeleeAbility : Ability
    {
        protected MeleeAbility(int x, int y, int sizeX, int sizeY, int visualX, int visualY, 
            int visualSizeX, int visualSizeY, int power, AbilityEffectEnum abilityEffect, IUnit caster) 
            : base(x, y, sizeX, sizeY, visualX, visualY, visualSizeX, visualSizeY, power, abilityEffect, caster)
        {
        }

        public MeleeAbility() : this(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null)
        {

        }
    }
}
