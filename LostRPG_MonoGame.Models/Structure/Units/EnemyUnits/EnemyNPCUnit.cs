using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LostRPG_MonoGame.Models.Graphics;

namespace LostRPG_MonoGame.Models.Structure.Units.EnemyUnits
{
    [Table("EnemyNPCUnit")]
    public abstract class EnemyNPCUnit : Unit
    {
        protected EnemyNPCUnit(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
            this.Boars = new List<Boar1>();
            this.Crabs = new List<GiantCrab1>();
        }

        public int Id { get; set; }

        //not sure about this, added for more visibility in the table
        public string Type { get; set; }

        //tryed to make it IColection<Region> but didnt accepted Region<T>!
        public string IColRegions { get; set; } 
     
        //nav props
        public virtual ICollection<Boar1> Boars { get; set; }

        public virtual ICollection<GiantCrab1> Crabs { get; set; }
    }
}
