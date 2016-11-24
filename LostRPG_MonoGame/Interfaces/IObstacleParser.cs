namespace LostRPG_MonoGame.Interfaces
{
    using System.Collections.Generic;
    using LostRPG.Models.Structure;
    using LostRPG_MonoGame.Regions;

    public interface IObstacleParser
    {
        IEnumerable<Obstacle> GetObstacles<T>() where T : Region<T>, new();
    }
}
