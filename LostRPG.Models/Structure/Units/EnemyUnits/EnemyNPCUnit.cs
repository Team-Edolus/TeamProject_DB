namespace LostRPG.Models.Structure.Units.EnemyUnits
{
    using LostRPG.Models.GameState;
    using LostRPG.Models.Graphics;

    public abstract class EnemyNPCUnit : Unit
    {
        protected EnemyNPCUnit()
        {
        }

        protected EnemyNPCUnit(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }

        public virtual string DummyProperty { get; set; }

        public virtual RegionState RegionState { get; set; }
    }
}
