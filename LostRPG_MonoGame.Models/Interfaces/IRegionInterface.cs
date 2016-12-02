namespace LostRPG_MonoGame.Models.Interfaces
{
    using System.Collections.Generic;
    using LostRPG_MonoGame.Models.Structure;
    using LostRPG_MonoGame.Models.Structure.BoostItems;
    using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
    using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;
    public interface IRegionInterface : IRenderable
    {
        List<FriendlyNPCUnit> RegionFriendlyNPCs { get; }

        List<EnemyNPCUnit> RegionEnemies { get; }

        List<Obstacle> RegionObstacles { get; }

        List<Gateway> RegionGateways { get; }

        List<Item> RegionItems { get; }
    }
}
