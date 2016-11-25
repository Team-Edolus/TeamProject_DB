using System.Runtime.Remoting.Contexts;
using LostRPG_MonoGame.Data.Migrations;
using LostRPG_MonoGame.Models.Structure;
using LostRPG_MonoGame.Models.Structure.Units;
using LostRPG_MonoGame.Models.Structure.Units.Character;
using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;

namespace LostRPG_MonoGame.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LostRPGContext : DbContext
    {
       
        public LostRPGContext()
            : base("name=LostRPGContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LostRPGContext, Configuration>());
        }

        public virtual IDbSet<GameObject> GameObjects { get; set; }

        public virtual IDbSet<Unit> Units { get; set; }

        public virtual IDbSet<EnemyNPCUnit> EnemyNPCUnits { get; set; }
        public virtual IDbSet<Boar1> Boars { get; set; }

        public virtual IDbSet<GiantCrab1> GiantCrabs { get; set; }

        public virtual IDbSet<FriendlyNPCUnit> FriendlyNPCUnits { get; set; }

        public virtual IDbSet<OldMage> OldMages { get; set; }



    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}