namespace LostRPG_MonoGame.Models.Structure.Units.Character
{
    using LostRPG_MonoGame.Models.Graphics;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Wizards")]
    public class Wizard : CharacterUnit // TODO
    {
        public Wizard(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }

        public Wizard() : this(0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        {

        }
        public string WizardName { get; set; }
    }
}
