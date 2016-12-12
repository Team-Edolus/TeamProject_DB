namespace LostRPG_MonoGame.Models.Structure.Abilities
{
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BasicAttack")]

    public class BasicAttack : MeleeAbility, IRenderable
    {
        public const int BasicAttackMaxLifespanInMS = 500;
        protected const int BasicAttackVisualSizeX = 6; 
        protected const int BasicAttackVisualSizeY = 16;
        protected const int BasicAttackPower = 60;
        protected const AbilityEffectEnum BasicAttackAbilityEffect = AbilityEffectEnum.DamagingAbility;
        protected const SpriteType BasicAttackSpriteType = SpriteType.Sword;

        public BasicAttack(int x, int y, int sizeX, int sizeY, int visualX, int visualY, IUnit caster) 
            : base(x, y, sizeX, sizeY, visualX, visualY, BasicAttackVisualSizeX, BasicAttackVisualSizeY, BasicAttackPower, BasicAttackAbilityEffect, caster)
        {
            this.MaxLifespanInMS = BasicAttackMaxLifespanInMS;
            this.CurrentLifespanInMS = 0;
            this.HasTimedOut = false;
            this.SpriteType = BasicAttackSpriteType;
        }

        public BasicAttack() : this(0, 0, 0, 0, 0, 0, null)
        {
        }

        public SpriteType SpriteType { get; set; }
    }
}
