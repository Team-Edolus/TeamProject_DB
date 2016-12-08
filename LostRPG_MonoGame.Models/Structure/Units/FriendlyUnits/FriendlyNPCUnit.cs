namespace LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits
{

    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG_MonoGame.Models.Graphics;

    [Table("FriendlyNPCUnits")]
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
       
        }
 
        public string IColRegions { get; set; }

        public string UnitType { get; set; }

    }
}
