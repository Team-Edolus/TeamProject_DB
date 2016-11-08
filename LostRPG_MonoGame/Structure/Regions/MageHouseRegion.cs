namespace LostRPG_MonoGame.Structure
{
    using LostRPG_MonoGame.Graphics;

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
            // To MageLayerRegion Gateway
            this.RegionGateways.Add(new Gateway(528, 589, 48, 3,
                () => this.RegionEntities.InitialiseNewRegion(MageLayerRegion.GetInstance), 1040, 192,
                (x, y) => this.RegionEntities.Player.Relocate(x, y)));
        }

        protected override void SetObstacles()
        {
        }

        protected override void SetBoostItems()
        {
        }
    }
}
