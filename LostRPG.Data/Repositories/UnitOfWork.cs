// ReSharper disable ConvertToAutoProperty
namespace LostRPG.Data.Repositories
{
    using LostRPG.Data.Interfaces;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.Character;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LostRPGDbContext context;
        
        private readonly IRepository<GameStateInfo> gameStateSafes;
        private readonly IRepository<RegionState> regionStates;

        private readonly IRepository<CharacterUnit> players;
        private readonly IRepository<FriendlyNPCUnit> friendlyNPCs;
        private readonly IRepository<EnemyNPCUnit> enemeyNPCs;
        private readonly IRepository<Item> items;

        public UnitOfWork()
        {
            this.context = new LostRPGDbContext();
            //////TODO?
            ////this.context.Configuration.LazyLoadingEnabled = false;

            this.gameStateSafes = new Repository<GameStateInfo>(this.context);
            this.regionStates = new Repository<RegionState>(this.context);
            ////
            this.players = new Repository<CharacterUnit>(this.context);
            this.friendlyNPCs = new Repository<FriendlyNPCUnit>(this.context);
            this.enemeyNPCs = new Repository<EnemyNPCUnit>(this.context);
            this.items = new Repository<Item>(this.context);
        }

        public IRepository<GameStateInfo> GameStateSafes => this.gameStateSafes;

        public IRepository<RegionState> RegionStates => this.regionStates;
        
        ////

        public IRepository<CharacterUnit> Players => this.players;

        public IRepository<FriendlyNPCUnit> FrienlyNPCs => this.friendlyNPCs;

        public IRepository<EnemyNPCUnit> Enemies => this.enemeyNPCs;

        public IRepository<Item> Items => this.items;
        
        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
