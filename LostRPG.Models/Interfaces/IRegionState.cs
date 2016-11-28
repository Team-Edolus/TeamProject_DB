namespace LostRPG.Models.Interfaces
{
    using System.Collections.Generic;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public interface IRegionState
    {
        ICollection<FriendlyNPCUnit> FriendlyNPCs { get; set; }

        ICollection<EnemyNPCUnit> Enemies { get; set; }
        
        ICollection<Item> Items { get; set; }
    }
}
