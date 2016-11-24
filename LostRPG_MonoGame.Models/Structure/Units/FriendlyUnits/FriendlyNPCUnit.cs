using LostRPG_MonoGame.Models.Graphics;

namespace LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits
{
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
    }
}
