using System.Collections.Generic;
using LostRPG_MonoGame.Models.Structure;
using LostRPG_MonoGame.Models.Structure.Regions;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IObstacleParser
    {
        IEnumerable<Obstacle> GetObstacles<T>() where T : Region<T>, new();
    }
}
