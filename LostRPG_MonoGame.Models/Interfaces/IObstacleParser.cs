namespace LostRPG_MonoGame.Models.Interfaces
{
    using System.Collections.Generic;
    using LostRPG_MonoGame.Models.Structure;
    using LostRPG_MonoGame.Models.Structure.Regions;
    public interface IObstacleParser
    {
        IEnumerable<Obstacle> GetObstacles<T>() where T : Region<T>, new();
    }
}
