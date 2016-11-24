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

namespace LostRPG_MonoGame.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LostRPGContext context = new LostRPGContext();

        private IRepository<GameObject> gameObjects { get; set; }

        private IRepository<Unit> units { get; set; }



        public IRepository<Unit> Units
        {
            get { return this.units ?? (this.units = new Repository<Unit>(this.context)); }
        }

        public IRepository<GameObject> GameObjects
        {
            get { return this.gameObjects ?? (this.gameObjects = new Repository<GameObject>(this.context)); }
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
