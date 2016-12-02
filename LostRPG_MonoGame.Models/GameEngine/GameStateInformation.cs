namespace LostRPG_MonoGame.Models.GameEngine
{
    using System.Collections.Generic;
    using LostRPG_MonoGame.Models.Interfaces;
    using LostRPG_MonoGame.Models.Structure;
    using LostRPG_MonoGame.Models.Structure.Abilities;
    using LostRPG_MonoGame.Models.Structure.BoostItems;
    using LostRPG_MonoGame.Models.Structure.Units.Character;
    using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
    using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;
    public class GameStateInformation : IGameStateInformation
    {
        public GameStateInformation()
        {
            this.Abilities = new List<Ability>();
            this.Enemies = new List<EnemyNPCUnit>();
            this.FriendlyNPCs = new List<FriendlyNPCUnit>();
            this.Gateways = new List<Gateway>();
            this.Items = new List<Item>();
            this.Obstacles = new List<Obstacle>();
        }

        public string NameOfTheLastRegion { get; set; }
        public CharacterUnit Player { get; set; }
        public ICollection<FriendlyNPCUnit> FriendlyNPCs { get; set; }
        public ICollection<EnemyNPCUnit> Enemies { get; set; }
        public ICollection<Ability> Abilities { get; set; }
        public ICollection<Obstacle> Obstacles { get; set; }
        public ICollection<Gateway> Gateways { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
