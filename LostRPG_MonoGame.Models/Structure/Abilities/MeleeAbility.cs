using LostRPG_MonoGame.Models.Interfaces;

namespace LostRPG_MonoGame.Models.Structure.Abilities
{
    public abstract class MeleeAbility : Ability
    {
        protected MeleeAbility(int x, int y, int sizeX, int sizeY, int visualX, int visualY, 
            int visualSizeX, int visualSizeY, int power, AbilityEffectEnum abilityEffect, IUnit caster) 
            : base(x, y, sizeX, sizeY, visualX, visualY, visualSizeX, visualSizeY, power, abilityEffect, caster)
        {
        }
    }
}
