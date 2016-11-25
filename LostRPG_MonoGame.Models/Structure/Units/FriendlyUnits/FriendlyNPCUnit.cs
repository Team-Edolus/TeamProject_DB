using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using LostRPG_MonoGame.Models.Graphics;
using LostRPG_MonoGame.Models.Structure.Regions;

namespace LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits
{
    [Table("FriendlyNPCUnit")]
    public class FriendlyNPCUnit : Unit
    {
        ////TODO:
        ////Make a questgiver.
        private const int DefCurrentHP = 1;
        private const int DefMaxHP = 1;
        private const int DefAttPoints = 0;
        private const int DefDefPoints = 0;
        private const int DefMoveSpeed = 0;
        
        public FriendlyNPCUnit(int x, int y, int sizeX, int sizeY, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, DefCurrentHP, DefMaxHP, DefAttPoints, DefDefPoints, DefMoveSpeed, spriteType)
        {
        }


        public FriendlyNPCUnit() : this(0, 0, 0, 0, 0)
        {
            this.OldMages = new List<OldMage>();
        }

        public int Id { get; set; }
   
        public string IColRegions { get; set; }

        public string UnitType { get; set; }

        // nav property
        public virtual ICollection<OldMage> OldMages { get; set; }
    }
}
