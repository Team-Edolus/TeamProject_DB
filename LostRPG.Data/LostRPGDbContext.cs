namespace LostRPG.Data
{
    using System.Data.Entity;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Structure;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.Character;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public class LostRPGDbContext : DbContext
    {
        public LostRPGDbContext()
            : base("name=LostRPGDbContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual IDbSet<GameStateInfo> GameStateInfos { get; set; }

        public virtual IDbSet<RegionState> RegionStates { get; set; }

        public virtual IDbSet<CharacterUnit> Players { get; set; }

        public virtual IDbSet<FriendlyNPCUnit> FriendlyNPCUnits { get; set; }

        public virtual IDbSet<EnemyNPCUnit> EnemyNPCUnits { get; set; }

        public virtual IDbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameObject>().ToTable("GameObjects");
            //modelBuilder.Entity<Unit>().ToTable("Units");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<CharacterUnit>().ToTable("CharacterUnits");
            modelBuilder.Entity<FriendlyNPCUnit>().ToTable("FriendlyNPCs");
            modelBuilder.Entity<EnemyNPCUnit>().ToTable("EnemyNPCs");

            modelBuilder.Entity<GameStateInfo>().ToTable("GameStateSafes");

            //modelBuilder.Entity<CharacterUnit>()
            //    .HasKey(cu => cu.Id);
            //modelBuilder.Entity<GameStateInfo>()
            //    .HasOptional(gsi => gsi.Player)
            //    .WithRequired(cu => cu.GameStateInfo);

            //////TEST
            ////modelBuilder.Entity<RegionState>()
            ////    .HasRequired(rs => rs.GameStateInfo)
            ////    .WithMany();
            //////ENDTEST

            //modelBuilder.Entity<GameStateInfo>()
            //    .HasRequired(stateinfo => stateinfo.Player)
            //    //.WithRequiredDependent(pl => pl.GameStateInfo);
            //    .WithRequiredPrincipal(pl => pl.GameStateInfo);

            modelBuilder.Entity<GameStateInfo>()
                .HasOptional(stateinfo => stateinfo.Player)
                //.WithRequiredDependent(pl => pl.GameStateInfo);
                .WithRequired(pl => pl.GameStateInfo);


            base.OnModelCreating(modelBuilder);
        }
    }
}
