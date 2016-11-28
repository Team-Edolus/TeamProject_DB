namespace LostRPG.Models.Structure.Units
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG.Models.Dynamics;
    using LostRPG.Models.Graphics;
    using LostRPG.Models.Interfaces;
    using LostRPG.Models.Structure.Abilities;

    public abstract class Unit : GameObject, IUnit
    {
        protected const int GlobalCooldownInMS = 300;

        private int currentHP;

        protected Unit()
        {
        }

        protected Unit(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp,
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType)
            : base(x, y, sizeX, sizeY)
        {
            this.currentHP = currentHp;
            this.MaxHP = maxHp;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.MovementSpeed = movementSpeed;
            this.SpriteType = spriteType;
            this.IsAlive = true;
        }

        [NotMapped]
        public int MaxHP { get; }

        [NotMapped]
        public int AttackPoints { get; set; }

        [NotMapped]
        public int DefensePoints { get; set; }

        public bool IsAlive { get; set; }

        [NotMapped]
        public Direction Direction { get; set; }

        public int MovementSpeed { get; set; }

        [NotMapped]
        public SpriteType SpriteType { get; }

        public int CurrentHP
        {
            get
            {
                return this.currentHP;
            }

            set
            {
                if (value <= 0)
                {
                    this.currentHP = 0;
                    this.IsAlive = false;
                }
                else
                {
                    this.currentHP = value;
                }
            }
        }

        public void Move()
        {
            this.X += this.MovementSpeed*this.Direction.DirX;
            this.Y += this.MovementSpeed*this.Direction.DirY;
        }

        public virtual ReactionTypeEnum ReactToAbility(AbilityEffectEnum abilityEffect)
        {
            switch (abilityEffect)
            {
                case AbilityEffectEnum.DamagingAbility:
                    return ReactionTypeEnum.TakeDamage;
                case AbilityEffectEnum.HealingAbility:
                    return ReactionTypeEnum.TakeHeal;
                case AbilityEffectEnum.BuffingAbility:
                    return ReactionTypeEnum.TakeBuff;
                case AbilityEffectEnum.DebuffingAbility:
                    return ReactionTypeEnum.TakeDebuff;
                case AbilityEffectEnum.DisplacingAbility:
                    throw new NotImplementedException("Displacing Ability");
                default:
                    throw new ArgumentOutOfRangeException(nameof(abilityEffect), abilityEffect, null);
            }
        }
    }
}
