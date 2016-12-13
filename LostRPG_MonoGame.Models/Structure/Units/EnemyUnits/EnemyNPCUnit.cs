namespace LostRPG_MonoGame.Models.Structure.Units.EnemyUnits
{
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG_MonoGame.Models.Graphics;

    [Table("EnemyNPCUnits")]
    public abstract class EnemyNPCUnit : Unit
    {
        protected EnemyNPCUnit(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
            
        }

        public string Type { get; set; }
 
        public string IColRegions { get; set; } 
       
    }
}
