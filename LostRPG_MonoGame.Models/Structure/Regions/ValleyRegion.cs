namespace LostRPG_MonoGame.Models.Structure.Regions
{
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
    public class ValleyRegion : Region<ValleyRegion>
    {
        public ValleyRegion() : base()
        {
            this.SpriteType = SpriteType.ValleyRegionBG;
        }

        protected override void SetFriendlyNPCs()
        {
        }

        protected override void SetEnemies()
        {
            this.RegionEnemies.Add(new Boar1(250, 200));
        }

        protected override void SetGateways()
        {
            //// Gateway to StartRegion
            this.RegionGateways.Add(new Gateway(352, 717, 80, 3, 
                () => this.RegionEntities.InitialiseNewRegion(StartRegion.GetInstance), 552, 8,
                (x, y) => this.RegionEntities.ParentEngine.RelocatePlayer(x, y)));
            //// Gateway to MageLayerRegion
            this.RegionGateways.Add(new Gateway(1277, 496, 3, 48,
                () => this.RegionEntities.InitialiseNewRegion(MageLayerRegion.GetInstance), 20, 560,
                (x, y) => this.RegionEntities.ParentEngine.RelocatePlayer(x, y)));
        }

        protected override void SetObstacles()
        {
            var obstacles = this.ObstacleParser.GetObstacles<ValleyRegion>();
            this.RegionObstacles.AddRange(obstacles);

            ////this.RegionObstacles.Add(new Obstacle(0, 656, 320, 64));
            ////this.RegionObstacles.Add(new Obstacle(320, 688, 32, 32));
            ////this.RegionObstacles.Add(new Obstacle(758, 192, 372, 479));
            ////this.RegionObstacles.Add(new Obstacle(256, 528, 32, 112));
            ////this.RegionObstacles.Add(new Obstacle(288, 176, 32, 336));
            ////this.RegionObstacles.Add(new Obstacle(464, 672, 816, 32));
            ////this.RegionObstacles.Add(new Obstacle(1136, 544, 144, 128));
            ////this.RegionObstacles.Add(new Obstacle(0, 0, 320, 72));
        }

        protected override void SetBoostItems()
        {           
        }
    }
}
