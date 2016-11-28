namespace LostRPG.Models.Structure.Units.FriendlyUnits
{
    using LostRPG.Models.GameState;
    using LostRPG.Models.Graphics;

    public abstract class FriendlyNPCUnit : Unit
    {
        ////TODO:
        ////Make a questgiver.
        private const int DefCurrentHP = 1;
        private const int DefMaxHP = 1;
        private const int DefAttPoints = 0;
        private const int DefDefPoints = 0;
        private const int DefMoveSpeed = 0;

        protected FriendlyNPCUnit()
        {
        }

        protected FriendlyNPCUnit(int x, int y, int sizeX, int sizeY, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, DefCurrentHP, DefMaxHP, DefAttPoints, DefDefPoints, DefMoveSpeed, spriteType)
        {
        }

        public virtual string DummyProperty { get; set; }

        public virtual RegionState RegionState { get; set; }
    }
}
