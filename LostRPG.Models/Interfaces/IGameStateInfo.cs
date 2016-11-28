namespace LostRPG.Models.Interfaces
{
    using System.Collections.Generic;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Structure.Units.Character;

    public interface IGameStateInfo
    {
        string CurrentRegion { get; set; }

        CharacterUnit Player { get; set; }

        ICollection<RegionState> RegionStates { get; set; }
    }
}
