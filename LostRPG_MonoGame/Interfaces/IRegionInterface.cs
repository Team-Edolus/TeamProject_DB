namespace LostRPG_MonoGame.Interfaces
{
    using System.Collections.Generic;
    using LostRPG_MonoGame.Structure;
    using LostRPG_MonoGame.Structure.BoostItems;
    using LostRPG_MonoGame.Structure.Units.EnemyUnits;
    using LostRPG_MonoGame.Structure.Units.FriendlyUnits;

    public interface IRegionInterface : IRenderable
    {
        List<FriendlyNPCUnit> RegionFriendlyNPCs { get; }

        List<EnemyNPCUnit> RegionEnemies { get; }

        List<Obstacle> RegionObstacles { get; }

        List<Gateway> RegionGateways { get; }

        List<Item> RegionItems { get; }
    }
}
