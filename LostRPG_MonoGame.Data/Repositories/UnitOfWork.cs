using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LostRPG_MonoGame.Data.Interfaces;
using LostRPG_MonoGame.Models.Interfaces;
using LostRPG_MonoGame.Models.Structure;
using LostRPG_MonoGame.Models.Structure.Units;
using LostRPG_MonoGame.Models.Structure.Units.Character;
using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;

namespace LostRPG_MonoGame.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LostRPGContext context;

        public UnitOfWork()
        {
            this.context = new LostRPGContext();
        }

        private IRepository<GameObject> gameObjects { get; set; }

        private IRepository<Unit> units { get; set; }

        private IRepository<EnemyNPCUnit> enemyNPCUnits { get; set; }

        private IRepository<Boar1> boars { get; set; }

        private IRepository<GiantCrab1> giantcrabs { get; set; }

        private IRepository<FriendlyNPCUnit> friendlyNPCUnits { get; set; }

        private IRepository<OldMage> oldMages { get; set; }

        public IRepository<Unit> Units
        {
            get { return this.units ?? (this.units = new Repository<Unit>(this.context)); }
        }
             

        public IRepository<GameObject> GameObjects
        {
            get { return this.gameObjects ?? (this.gameObjects = new Repository<GameObject>(this.context)); }
        }

        public IRepository<EnemyNPCUnit> EnemyNPCUnits
        {
            get { return this.enemyNPCUnits ?? (this.enemyNPCUnits = new Repository<EnemyNPCUnit>(this.context)); }
        }

        public IRepository<Boar1> Boars
        {
            get { return this.boars ?? (this.boars = new Repository<Boar1>(this.context)); }
        }

        public IRepository<GiantCrab1> Giantcrabs
        {
            get { return this.giantcrabs ?? (this.giantcrabs = new Repository<GiantCrab1>(context)); }
        }

        public IRepository<FriendlyNPCUnit> FriendlyNPCUnits
        {
            get
            {
                return this.friendlyNPCUnits ?? (this.friendlyNPCUnits = new Repository<FriendlyNPCUnit>(this.context));
            }
        }

        public IRepository<OldMage> OldMages
        {
            get { return this.oldMages ?? (this.oldMages = new Repository<OldMage>(this.context)); }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public IGameStateInformation GetGameStateInformation()
        {
            //Connect to the database and get information about the last region, how many enemies are left, the health of the player, the exact location, etc.

            return null;
        }

        

        public void RecordTheLastGameState(IGameStateInformation information)
        {
            //Connects to the database and records the current state of the game: position of the player, region, health, enemies, etc.
        }
    }
}
