namespace LostRPG_MonoGame.Data
{

    using System.Data.Entity;
    using LostRPG_MonoGame.Data.Migrations;
    using LostRPG_MonoGame.Models.Structure;
    using System.Data.Entity.Infrastructure;
    using Models.Structure.Units.Character;

    public class LostRPGContext : DbContext
    {

        public LostRPGContext()
            : base("name=LostRPGContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LostRPGContext, Configuration>());
        
        }

        public virtual IDbSet<GameObject> GameObjects { get; set; }
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Wizard>().ToTable("Wizards");
           modelBuilder.Entity<Warrior>().ToTable("Warriors");
            modelBuilder.Entity<Ranger>().ToTable("Rangers");
            modelBuilder.Entity<CharacterUnit>().ToTable("CharacterUnits");

            base.OnModelCreating(modelBuilder);
       }
    }

}