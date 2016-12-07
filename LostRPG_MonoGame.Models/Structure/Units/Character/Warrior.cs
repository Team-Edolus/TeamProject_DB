namespace LostRPG_MonoGame.Models.Structure.Units.Character
{
    using System;
    using LostRPG_MonoGame.Models.GameEngine;
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Interfaces;
    using LostRPG_MonoGame.Models.Structure.Abilities;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Warriors")]
    public class Warrior : CharacterUnit, IMeleeAttacking
    {
        private const int WarriorSizeX = 16;
        private const int WarriorSizeY = 24;
        private const int WarriorCurrHP = 250;
        private const int WarriorMaxHP = 300;
        private const int WarriorAttPoints = 25;
        private const int WarriorDefPoints = 25;
        private const int WarriorSpeed = 2;
        private const SpriteType WarriorSprite = SpriteType.Char1;

        private TimeSpan timeOfLastAbilityUsage;

        public Warrior(int x, int y)
            : base(x, y, WarriorSizeX, WarriorSizeY, WarriorCurrHP, WarriorMaxHP,
                WarriorAttPoints, WarriorDefPoints, WarriorSpeed, WarriorSprite)
        {
            this.timeOfLastAbilityUsage = TimeSpan.Zero;
        }

        public Warrior() : this(0, 0)
        {

        }

        public MeleeAbility MeleeAttack(int mouseX, int mouseY, TimeSpan totalElapsedTime)
        {
            var timeDelta = totalElapsedTime.Subtract(this.timeOfLastAbilityUsage);
            if (timeDelta.Milliseconds < Warrior.GlobalCooldownInMS)
            {
                return null;
            }

            this.timeOfLastAbilityUsage = totalElapsedTime;
            switch (this.ActiveAbility)
            {
                case ActiveAbilityEnum.FirstAbility:
                    return this.UseBasicAttack(mouseX, mouseY);
                case ActiveAbilityEnum.SecondAbility:
                    return this.UseCharge();
                default:
                    throw new ArgumentException("No such warrior ability.");
            }
        }

        private BasicAttack UseBasicAttack(int mouseX, int mouseY)
        {
            var direction = this.DetermineAbilityDirection(mouseX, mouseY);
            int abilityX;
            int abilityY;
            int abilitySizeX;
            int abilitySizeY;
            int abilityVisualX;
            int abilityVisualY;
            switch (direction)
            {
                case DirectionEnum.East:
                    abilityX = this.X + this.SizeX;
                    abilityY = this.Y - this.SizeY/4;
                    abilitySizeX = this.SizeX;
                    abilitySizeY = this.SizeY + this.SizeY/2;
                    abilityVisualX = this.X + this.SizeX;
                    abilityVisualY = this.Y + 7;
                    break;
                case DirectionEnum.West:
                    abilityX = this.X - this.SizeX;
                    abilityY = this.Y - this.SizeY/4;
                    abilitySizeX = this.SizeX;
                    abilitySizeY = this.SizeY + this.SizeY/2;
                    abilityVisualX = this.X - this.SizeX + 10;
                    abilityVisualY = this.Y + 7;
                    break;
                case DirectionEnum.North:
                    abilityX = this.X - this.SizeX;
                    abilityY = this.Y - this.SizeX;
                    abilitySizeX = this.SizeX*3;
                    abilitySizeY = this.SizeX;
                    abilityVisualX = this.X + 5;
                    abilityVisualY = this.Y - this.SizeX;
                    break;
                case DirectionEnum.South:
                    abilityX = this.X - this.SizeX;
                    abilityY = this.Y + this.SizeY;
                    abilitySizeX = this.SizeX*3;
                    abilitySizeY = this.SizeX;
                    abilityVisualX = this.X + 5;
                    abilityVisualY = this.Y + this.SizeY;
                    break;
                default:
                    throw new ArgumentException("Unexisting direction");
            }

            return new BasicAttack(abilityX, abilityY, abilitySizeX, abilitySizeY, abilityVisualX, abilityVisualY, this);
        }

        private Charge UseCharge() // TODO: Implement proper range!
        {
            const int newAbilitySizeX = 112;
            const int newAbilitySizeY = 112;
            var newAbilityX = this.X - 48;
            var newAbilityY = this.Y - 48;
            return new Charge(newAbilityX, newAbilityY, newAbilitySizeX, newAbilitySizeY, this);
        }
    }
}
