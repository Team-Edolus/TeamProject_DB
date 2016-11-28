// ReSharper disable VirtualMemberCallInConstructor
namespace LostRPG.Models.GameState
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG.Models.Interfaces;
    using LostRPG.Models.Structure.Units.Character;

    public class GameStateInfo : IGameStateInfo
    {
        public GameStateInfo(string safeName, string currentRegion, CharacterUnit player, ICollection<RegionState> regionStates)
        {
            this.SafeName = safeName;
            this.CurrentRegion = currentRegion;
            this.Player = player;
            this.RegionStates = regionStates;
        }

        protected GameStateInfo()
        {
        }

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SafeId { get; set; }

        [Key, Column(Order = 2)]
        public string SafeName { get; set; }

        [Required]
        public string CurrentRegion { get; set; }

        public CharacterUnit Player { get; set; }
        
        public virtual ICollection<RegionState> RegionStates { get; set; }
    }
}
