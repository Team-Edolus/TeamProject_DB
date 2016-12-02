namespace LostRPG_MonoGame.Models.Structure.Regions
{
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
    public class MageLayerRegion : Region<MageLayerRegion>
    {
        public MageLayerRegion() : base()
        {
            this.SpriteType = SpriteType.MageLayerRegionBG;
        }

        protected override void SetFriendlyNPCs()
        {
        }

        protected override void SetEnemies()
        {
            this.RegionEnemies.Add(new Boar1(200, 200));
        }

        protected override void SetGateways()
        {
            //// Gateway to ValleyRegion
            this.RegionGateways.Add(new Gateway(0, 496, 3, 112,
                () => this.RegionEntities.InitialiseNewRegion(ValleyRegion.GetInstance), 1248, 512,
                (x, y) => this.RegionEntities.ParentEngine.RelocatePlayer(x, y)));
            //// Gateway to MageHouseRegion
            this.RegionGateways.Add(new Gateway(1056, 182, 24, 24,
                () => this.RegionEntities.InitialiseNewRegion(MageHouseRegion.GetInstance), 544, 544,
                (x, y) => this.RegionEntities.ParentEngine.RelocatePlayer(x, y)));
        }

        protected override void SetObstacles()
        {
            var obstacles = this.ObstacleParser.GetObstacles<MageLayerRegion>();
            this.RegionObstacles.AddRange(obstacles);
        }

        protected override void SetBoostItems()
        {
            ////this.RegionItems.Add(new Shield(1100, 280));
        }
    }
}
