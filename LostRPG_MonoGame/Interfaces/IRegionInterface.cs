namespace LostRPG_MonoGame.Interfaces
{
    using System.Collections.Generic;
    using LostRPG.Models.Interfaces;
    using LostRPG.Models.Structure;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public interface IRegionInterface : IRenderable
    {
        List<FriendlyNPCUnit> RegionFriendlyNPCs { get; }

        List<EnemyNPCUnit> RegionEnemies { get; }

        List<Obstacle> RegionObstacles { get; }

        List<Gateway> RegionGateways { get; }

        List<Item> RegionItems { get; }
    }
}
