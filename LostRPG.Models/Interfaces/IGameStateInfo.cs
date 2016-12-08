namespace LostRPG.Models.Interfaces
{
    using System.Collections.Generic;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Structure.Units.Character;

    public interface IGameStateInfo
    {
        string SafeName { get; }

        string CurrentRegion { get; }

        CharacterUnit Player { get; }

        ICollection<RegionState> RegionStates { get; }
    }
}
