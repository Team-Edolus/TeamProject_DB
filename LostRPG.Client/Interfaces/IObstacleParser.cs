namespace LostRPG.Client.Interfaces
{
    using System.Collections.Generic;
    using LostRPG.Client.Regions;
    using LostRPG.Models.Structure;

    public interface IObstacleParser
    {
        IEnumerable<Obstacle> GetObstacles<T>() where T : Region<T>, new();
    }
}
