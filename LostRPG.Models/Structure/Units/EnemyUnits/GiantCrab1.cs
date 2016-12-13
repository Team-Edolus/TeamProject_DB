namespace LostRPG.Models.Structure.Units.EnemyUnits
{
    using LostRPG.Models.Graphics;

    public class GiantCrab1 : EnemyNPCUnit
    {
        private const int GiantCrab1SizeX = 22;
        private const int GiantCrab1SizeY = 16;
        private const int GiantCrab1CurrHP = 250;
        private const int GiantCrab1MaxHP = 250;
        private const int GiantCrab1AttPoins = 15;
        private const int GiantCrab1DefPoints = 5;
        private const int GiantCrab1MovSpeed = 1;
        private const SpriteType GiantCrab1Sprite = SpriteType.GiantCrab1;

        public GiantCrab1(int x, int y) 
            : base(x, y, GiantCrab1SizeX, GiantCrab1SizeY, GiantCrab1CurrHP, GiantCrab1MaxHP, 
                  GiantCrab1AttPoins, GiantCrab1DefPoints, GiantCrab1MovSpeed, GiantCrab1Sprite)
        {
        }

        protected GiantCrab1()
        {
            this.SizeX = GiantCrab1SizeX;
            this.SizeY = GiantCrab1SizeY;
            this.CurrentHP = GiantCrab1CurrHP;
            this.MaxHP = GiantCrab1MaxHP;
            this.AttackPoints = GiantCrab1AttPoins;
            this.DefensePoints = GiantCrab1DefPoints;
            this.MovementSpeed = GiantCrab1MovSpeed;
            this.IsAlive = true;
            this.SpriteType = GiantCrab1Sprite;
        }
    }
}
