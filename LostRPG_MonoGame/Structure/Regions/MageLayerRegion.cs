namespace LostRPG_MonoGame.Structure
{
    using LostRPG_MonoGame.Graphics;

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
            //// To ValleyRegion Gateway
            this.RegionGateways.Add(new Gateway(0, 496, 3, 112,
                () => this.RegionEntities.InitialiseNewRegion(ValleyRegion.GetInstance), 1248, 512,
                (x, y) => this.RegionEntities.Player.Relocate(x, y)));
            //// To MageHouseRegion Gateway
            this.RegionGateways.Add(new Gateway(1056, 176, 32, 3,
                () => this.RegionEntities.InitialiseNewRegion(MageHouseRegion.GetInstance), 544, 544,
                (x, y) => this.RegionEntities.Player.Relocate(x, y)));
        }

        protected override void SetObstacles()
        {
        }

        protected override void SetBoostItems()
        {
            ////this.RegionItems.Add(new Shield(1100, 280));
        }
    }
}
