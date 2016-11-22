namespace LostRPG_MonoGame.Interfaces
{
    using System.Collections.Generic;
    using LostRPG_MonoGame.Structure;
    using LostRPG_MonoGame.Structure.Regions;

    public interface IObstacleParser
    {
        IEnumerable<Obstacle> GetObstacles<T>() where T : Region<T>, new();
    }
}
