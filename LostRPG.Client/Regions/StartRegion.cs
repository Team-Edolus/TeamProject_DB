﻿namespace LostRPG.Client.Regions
{
    using LostRPG.Models.Graphics;
    using LostRPG.Models.Structure;
    using LostRPG.Models.Structure.Units.EnemyUnits;

    public class StartRegion : Region<StartRegion>
    {
        public StartRegion() : base()
        {
            this.SpriteType = SpriteType.StartRegionBG;
        }

        protected override void SetBoostItems()
        {
            ////this.RegionItems.Add(new Shield(200, 220));
        }

        protected override void SetFriendlyNPCs()
        {
        }

        protected override void SetEnemies()
        {
            this.RegionEnemies.Add(new GiantCrab1(100, 100));
            this.RegionEnemies.Add(new GiantCrab1(200, 200));
            this.RegionEnemies.Add(new GiantCrab1(300, 300));
            this.RegionEnemies.Add(new GiantCrab1(400, 400));
            this.RegionEnemies.Add(new GiantCrab1(500, 400));
        }

        protected override void SetGateways()
        {
            //// Gateway to ValleyRegion 
            this.RegionGateways.Add(new Gateway(544, 0, 32, 3,
                () => this.RegionEntities.InitialiseNewRegion(ValleyRegion.GetInstance), 384, 688,
                (x, y) => this.RegionEntities.ParentEngine.RelocatePlayer(x, y)));
        }

        protected override void SetObstacles()
        {
            var obstacles = this.ObstacleParser.GetObstacles<StartRegion>();
            this.RegionObstacles.AddRange(obstacles);

            ////this.RegionObstacles.Add(new Obstacle(0, 496, 1280, 224)); // The Sea
            ////this.RegionObstacles.Add(new Obstacle(768, 448, 16, 16));
            ////this.RegionObstacles.Add(new Obstacle(0, 336, 80, 160));
            ////this.RegionObstacles.Add(new Obstacle(0, 128, 112, 208));
            ////this.RegionObstacles.Add(new Obstacle(0, 0, 96, 128));
            ////this.RegionObstacles.Add(new Obstacle(112, 112, 32, 48));
            ////this.RegionObstacles.Add(new Obstacle(96, 0, 400, 64));
            ////this.RegionObstacles.Add(new Obstacle(496, 0, 48, 32));
            ////this.RegionObstacles.Add(new Obstacle(592, 0, 688, 48));
            ////this.RegionObstacles.Add(new Obstacle(752, 48, 256, 32));
            ////this.RegionObstacles.Add(new Obstacle(960, 112, 64, 80));
            ////this.RegionObstacles.Add(new Obstacle(1136, 48, 112, 32));
            ////this.RegionObstacles.Add(new Obstacle(1248, 80, 32, 32));
            ////this.RegionObstacles.Add(new Obstacle(1184, 144, 96, 256));
            ////this.RegionObstacles.Add(new Obstacle(1200, 128, 80, 16));
            ////this.RegionObstacles.Add(new Obstacle(1216, 112, 64, 16));
            ////this.RegionObstacles.Add(new Obstacle(1216, 400, 64, 96));
        }
    }
}
