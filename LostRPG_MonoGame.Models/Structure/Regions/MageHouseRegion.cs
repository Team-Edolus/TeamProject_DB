namespace LostRPG_MonoGame.Models.Structure.Regions
{
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;
    public class MageHouseRegion : Region<MageHouseRegion>
    {
        public MageHouseRegion() : base()
        {
            this.SpriteType = SpriteType.MageHouseRegionBG;
        }

        protected override void SetFriendlyNPCs()
        {
            this.RegionFriendlyNPCs.Add(new OldMage());
        }

        protected override void SetEnemies()
        {
        }

        protected override void SetGateways()
        {
            //// Gateway to MageLayerRegion
            this.RegionGateways.Add(new Gateway(528, 589, 48, 3,
                () => this.RegionEntities.InitialiseNewRegion(MageLayerRegion.GetInstance), 1040, 192,
                (x, y) => this.RegionEntities.ParentEngine.RelocatePlayer(x, y)));
        }

        protected override void SetObstacles()
        {
            var obstacles = this.ObstacleParser.GetObstacles<MageHouseRegion>();
            this.RegionObstacles.AddRange(obstacles);
        }

        protected override void SetBoostItems()
        {
        }
    }
}
