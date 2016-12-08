namespace LostRPG.Models.Interfaces
{
    using System.Collections.Generic;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public interface IRegionState
    {
        ICollection<FriendlyNPCUnit> FriendlyNPCs { get; }

        ICollection<EnemyNPCUnit> Enemies { get; }
        
        ICollection<Item> Items { get; }
    }
}
