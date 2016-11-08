﻿namespace LostRPG_MonoGame.Structure
{
    using System;
    using LostRPG_MonoGame.GameEngine;
    using LostRPG_MonoGame.Graphics;
    using LostRPG_MonoGame.Interfaces;

    public abstract class Unit : GameObject, IUnit, IMoveable, IRenderable
    {
        protected const int GlobalCooldownInMS = 300;

        private int currentHP;

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

        public int MaxHP { get; }

        public int AttackPoints { get; set; }

        public int DefensePoints { get; set; }

        public bool IsAlive { get; set; }

        public Direction Direction { get; set; }

        public int MovementSpeed { get; set; }

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

        public void Relocate(int x, int y)
        {
            this.X = x;
            this.Y = y;
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