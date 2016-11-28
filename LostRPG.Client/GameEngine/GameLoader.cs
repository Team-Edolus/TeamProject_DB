// ReSharper disable MemberCanBeMadeStatic.Local
namespace LostRPG.Client.GameEngine
{
    using System.Collections.Generic;
    using System.Linq;
    using LostRPG.Client.Interfaces;
    using LostRPG.Client.Regions;
    using LostRPG.Data.Interfaces;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Interfaces;
    using LostRPG.Models.Structure.Units.Character;

    public class GameLoader : IGameLoader
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Engine parentEngine;

        public GameLoader(IUnitOfWork unitOfWork, Engine engine)
        {
            this.unitOfWork = unitOfWork;
            this.parentEngine = engine;
        }

        public void SaveGame(string safeName)
        {
            var currentRegion = this.parentEngine.RegionEntities.GetCurrentRegionName();
            var player = this.parentEngine.RegionEntities.Player;
            var regionStateList = this.GetRegionStates();
            
            var gameState = new GameStateInfo(safeName, 
                currentRegion, 
                player as CharacterUnit, 
                regionStateList);
            this.SaveGameState(gameState);
        }
        
        public void LoadGame(IGameStateInfo information)
        {
            throw new System.NotImplementedException();
        }

        private ICollection<RegionState> GetRegionStates()
        {
            var regionList = new List<IRegionInterface>
            {
                StartRegion.GetInstance,
                ValleyRegion.GetInstance,
                MageLayerRegion.GetInstance,
                MageHouseRegion.GetInstance
            };

            return regionList
                .Select(region => new RegionState(
                    region.GetType().Name, 
                    region.RegionFriendlyNPCs.ToList(), 
                    region.RegionEnemies.ToList(), 
                    region.RegionItems.ToList()))
                ////.Cast<IRegionState>()
                .ToList();
        }
        
        private void SaveGameState(GameStateInfo gameStateInfo)
        {
            this.unitOfWork.GameStateSafes.Add(gameStateInfo);
            this.unitOfWork.Commit();
        }

        private IGameStateInfo LoadGameStateInformation()
        {

            throw new System.NotImplementedException();
        }
    }
}
