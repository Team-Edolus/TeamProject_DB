namespace LostRPG_MonoGame.Data
{
 
    using System.Data.Entity;
    using LostRPG_MonoGame.Data.Migrations;
    using LostRPG_MonoGame.Models.Structure;
  

    public class LostRPGContext : DbContext
    {

        public LostRPGContext()
            : base("name=LostRPGContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LostRPGContext, Configuration>());
        }

        public virtual IDbSet<GameObject> GameObjects { get; set; }

    }

}