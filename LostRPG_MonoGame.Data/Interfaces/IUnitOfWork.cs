namespace LostRPG_MonoGame.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LostRPG_MonoGame.Models.Interfaces;
    using LostRPG_MonoGame.Models.Structure;
    using LostRPG_MonoGame.Models.Structure.Units;
    using LostRPG_MonoGame.Models.Structure.Units.Character;
    using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
    using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;
    public interface IUnitOfWork
    {
        IGameStateInformation GetGameStateInformation();

        IRepository<GameObject> GameObjects { get; }

        IRepository<Unit> Units { get; }

        IRepository<EnemyNPCUnit> EnemyNPCUnits { get; }

        IRepository<Boar1> Boars { get; }
        IRepository<GiantCrab1> Giantcrabs { get; }

        IRepository<FriendlyNPCUnit> FriendlyNPCUnits { get; }

        IRepository<OldMage> OldMages { get; }
     
        void RecordTheLastGameState(IGameStateInformation information);

        void Save();
    }
}
