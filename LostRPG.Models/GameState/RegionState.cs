// ReSharper disable VirtualMemberCallInConstructor
namespace LostRPG.Models.GameState
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using LostRPG.Models.Interfaces;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public class RegionState : IRegionState   
    {
        public RegionState(string regionName, ICollection<FriendlyNPCUnit> friendlyNPCs, 
            ICollection<EnemyNPCUnit> enemies, ICollection<Item> items)
        {
            this.RegionName = regionName;
            this.FriendlyNPCs = friendlyNPCs;
            this.Enemies = enemies;
            this.Items = items;
        }

        protected RegionState()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string RegionName { get; set; }

        public virtual ICollection<FriendlyNPCUnit> FriendlyNPCs { get; set; }

        public virtual ICollection<EnemyNPCUnit> Enemies { get; set; }
        
        public virtual ICollection<Item> Items { get; set; }

        public virtual GameStateInfo GameStateInfo { get; set; }
    }
}
