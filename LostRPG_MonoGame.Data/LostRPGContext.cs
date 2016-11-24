using System.Runtime.Remoting.Contexts;
using LostRPG_MonoGame.Data.Migrations;
using LostRPG_MonoGame.Models.Structure;
using LostRPG_MonoGame.Models.Structure.Units;
using LostRPG_MonoGame.Models.Structure.Units.Character;

namespace LostRPG_MonoGame.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LostRPGContext : DbContext
    {
        // Your context has been configured to use a 'LostRPGContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LostRPG_MonoGame.Data.LostRPGContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LostRPGContext' 
        // connection string in the application configuration file.
        public LostRPGContext()
            : base("name=LostRPGContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LostRPGContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<GameObject> GameObjects { get; set; }

        public virtual IDbSet<Unit> Units { get; set; }



    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}