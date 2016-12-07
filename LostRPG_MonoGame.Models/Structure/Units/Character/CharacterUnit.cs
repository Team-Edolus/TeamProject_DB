namespace LostRPG_MonoGame.Models.Structure.Units.Character
{
    using System;
    using LostRPG_MonoGame.Models.GameEngine;
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Interfaces;
    using LostRPG_MonoGame.Models.Structure.Abilities;
    using System.ComponentModel.DataAnnotations.Schema;
    
   [Table("CharacterUnits")]
    public abstract class CharacterUnit : Unit, ICharacterUnit, IAbilityUseable
    {
        protected CharacterUnit(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
            this.ActiveAbility = ActiveAbilityEnum.FirstAbility;
        }

        protected ActiveAbilityEnum ActiveAbility { get; private set; }
        public string Type { get; set; }

        public void SetActiveAbility(string s)
        {
            switch (s)
            {
                case "1":
                    this.ActiveAbility = ActiveAbilityEnum.FirstAbility;
                    break;
                case "2":
                    this.ActiveAbility = ActiveAbilityEnum.SecondAbility;
                    break;
                case "3":
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException("No such ability!");
            }
        }

        //// TODO: Move this method out of this class!
        public DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY)
        {
            var centerX = this.X + this.SizeX/2;
            var centerY = this.Y + this.SizeY/2;
            var relativeX = mouseX - centerX;
            var relativeY = centerY - mouseY;
            var diagSum = relativeX + relativeY;
            if (relativeX > relativeY && diagSum > 0)
            {
                return DirectionEnum.East;
            }
            else if (relativeX > relativeY && diagSum < 0)
            {
                return DirectionEnum.South;
            }
            else if (relativeX < relativeY && diagSum > 0)
            {
                return DirectionEnum.North;
            }
            else if (relativeX < relativeY && diagSum < 0)
            {
                return DirectionEnum.West;
            }
            else
            {
                return (relativeX > 0) ? DirectionEnum.East : DirectionEnum.West;
            }
        }
    }
}
