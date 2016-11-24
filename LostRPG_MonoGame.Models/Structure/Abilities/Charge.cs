 using LostRPG_MonoGame.Models.Interfaces;

namespace LostRPG_MonoGame.Models.Structure.Abilities
{
    public class Charge : MeleeAbility
    {
        private const int ChargeVisualX = 0;
        private const int ChargeVisualY = 0;
        private const int ChargeVisualSizeX = 0;
        private const int ChargeVisualSizeY = 0;
        private const int ChargePower = 0;
        private const AbilityEffectEnum ChargeAbilityEffect = AbilityEffectEnum.DisplacingAbility;

        public Charge(int x, int y, int sizeX, int sizeY, IUnit caster) 
            : base(x, y, sizeX, sizeY, ChargeVisualX, ChargeVisualY, ChargeVisualSizeX, ChargeVisualSizeY,
                  ChargePower, ChargeAbilityEffect, caster)
        {
        }

        public Charge() : this(0, 0, 0, 0, null)
        {
        }
    }
}
