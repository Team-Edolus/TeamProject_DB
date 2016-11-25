namespace LostRPG_MonoGame.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestSeedData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameObject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        VisualX = c.Int(),
                        VisualY = c.Int(),
                        VisualSizeX = c.Int(),
                        VisualSizeY = c.Int(),
                        Power = c.Int(),
                        AbilityEffect = c.Int(),
                        MaxLifespanInMS = c.Int(),
                        CurrentLifespanInMS = c.Int(),
                        HasTimedOut = c.Boolean(),
                        SpriteType = c.Int(),
                        HasBeenUsed = c.Boolean(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AttackPoints = c.Int(nullable: false),
                        DefensePoints = c.Int(nullable: false),
                        IsAlive = c.Boolean(nullable: false),
                        MovementSpeed = c.Int(nullable: false),
                        CurrentHP = c.Int(nullable: false),
                        Type = c.String(),
                        IColRegions = c.String(),
                        IColRegions1 = c.String(),
                        UnitType = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameObject", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Boar1",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnemyUnit_Id = c.Int(),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unit", t => t.Id)
                .ForeignKey("dbo.Unit", t => t.EnemyUnit_Id)
                .Index(t => t.Id)
                .Index(t => t.EnemyUnit_Id);
            
            CreateTable(
                "dbo.GiantCrab1",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnemyUnit_Id = c.Int(),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unit", t => t.Id)
                .ForeignKey("dbo.Unit", t => t.EnemyUnit_Id)
                .Index(t => t.Id)
                .Index(t => t.EnemyUnit_Id);
            
            CreateTable(
                "dbo.OldMage",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FriendlyUnit_Id = c.Int(),
                        Name = c.String(),
                        Region = c.String(),
                        QuestTaken = c.Boolean(nullable: false),
                        QuestCompleete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unit", t => t.Id)
                .ForeignKey("dbo.Unit", t => t.FriendlyUnit_Id)
                .Index(t => t.Id)
                .Index(t => t.FriendlyUnit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OldMage", "FriendlyUnit_Id", "dbo.Unit");
            DropForeignKey("dbo.OldMage", "Id", "dbo.Unit");
            DropForeignKey("dbo.GiantCrab1", "EnemyUnit_Id", "dbo.Unit");
            DropForeignKey("dbo.GiantCrab1", "Id", "dbo.Unit");
            DropForeignKey("dbo.Boar1", "EnemyUnit_Id", "dbo.Unit");
            DropForeignKey("dbo.Boar1", "Id", "dbo.Unit");
            DropForeignKey("dbo.Unit", "Id", "dbo.GameObject");
            DropIndex("dbo.OldMage", new[] { "FriendlyUnit_Id" });
            DropIndex("dbo.OldMage", new[] { "Id" });
            DropIndex("dbo.GiantCrab1", new[] { "EnemyUnit_Id" });
            DropIndex("dbo.GiantCrab1", new[] { "Id" });
            DropIndex("dbo.Boar1", new[] { "EnemyUnit_Id" });
            DropIndex("dbo.Boar1", new[] { "Id" });
            DropIndex("dbo.Unit", new[] { "Id" });
            DropTable("dbo.OldMage");
            DropTable("dbo.GiantCrab1");
            DropTable("dbo.Boar1");
            DropTable("dbo.Unit");
            DropTable("dbo.GameObject");
        }
    }
}
