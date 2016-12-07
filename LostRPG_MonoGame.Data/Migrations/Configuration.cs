namespace LostRPG_MonoGame.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
    using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;

    internal sealed class Configuration : DbMigrationsConfiguration<LostRPGContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LostRPGContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LostRPG_MonoGame.Data.LostRPGContext context)
        {
           context.GameObjects.AddOrUpdate(b => b.Id,
                        new Boar1(300, 300) { RegionName = "ValleyRegion", IsAlive = true },
                        new Boar1(400, 400) { RegionName = "MageLayerRegion", IsAlive = true },
                        new GiantCrab1(250, 250) { RegionName = "StartRegion", IsAlive = true },
                        new GiantCrab1(300, 300) { RegionName = "StartRegion", IsAlive = true },
                        new GiantCrab1(350, 350) { RegionName = "StartRegion", IsAlive = true },
                        new GiantCrab1(400, 450) { RegionName = "StartRegion", IsAlive = true },
                        new OldMage() { Name = "Gandalf", Region = "MageHouseRegion", QuestTaken = false, QuestCompleete = false }
                        );
           context.SaveChanges();
        }
    }
}
