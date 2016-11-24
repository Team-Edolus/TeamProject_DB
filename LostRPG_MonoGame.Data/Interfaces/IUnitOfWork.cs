using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LostRPG_MonoGame.Models.Interfaces;
using LostRPG_MonoGame.Models.Structure;
using LostRPG_MonoGame.Models.Structure.Units;
using LostRPG_MonoGame.Models.Structure.Units.Character;

namespace LostRPG_MonoGame.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IGameStateInformation GetGameStateInformation();

        IRepository<GameObject> GameObjects { get; }

        IRepository<Unit> Units { get; }


        void RecordTheLastGameState(IGameStateInformation information);

        void Save();
    }
}
