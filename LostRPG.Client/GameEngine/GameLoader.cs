// ReSharper disable MemberCanBeMadeStatic.Local
namespace LostRPG.Client.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
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

        public bool SaveGame(string safeName)
        {
            var time = DateTime.Now;

            var currentRegion = this.parentEngine.RegionEntities.GetCurrentRegionName();
            var player = this.parentEngine.RegionEntities.Player;
            var regionStateList = this.GetRegionStates();
            
            var gameState = new GameStateInfo(
                safeName,
                time, 
                currentRegion, 
                player as CharacterUnit, 
                regionStateList);

            return this.SaveGameState(gameState);
        }
        
        public bool LoadGame(string safeName)
        {
            var gameStateInfo = this.GetGameInfo(safeName);
            
            if (gameStateInfo == null)
            {
                //TODO....
            }

            //TODO...?
            return this.LoadGameState(gameStateInfo);
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
        
        private bool SaveGameState(GameStateInfo gameStateInfo)
        {
            try
            {
                this.unitOfWork.GameStateSafes.Add(gameStateInfo);
                this.unitOfWork.Commit();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private IGameStateInfo GetGameInfo(string safeName)
        {
            var gameState = this.unitOfWork.GameStateSafes.Find(gss => gss.SafeName == safeName).FirstOrDefault();

            if (gameState == null)
            {
                //TODO:....
                throw new Exception();
            }

            CharacterUnit player = null;
            //var player = this.unitOfWork.GameStateSafes.Find(gss => gss.SafeName == safeName).FirstOrDefault()?.Player;
            try
            {
                player = this.unitOfWork.Players.Find(p => p.GameStateInfo.SafeName == safeName).FirstOrDefault();
                //var player = this.unitOfWork.Players.Find(p => p.GameStateInfo.SafeName == safeName).FirstOrDefault();
            }
            catch (TargetInvocationException tie)
            {
                Debug.WriteLine(tie.InnerException.Message);
                throw;
            }

            if (player == null)
            {
                throw new Exception();
            }

            return new GameStateInfo("asd", DateTime.Today, "dsa", player, null);
            throw new NotImplementedException();
        }

        private bool LoadGameState(IGameStateInfo gameStateInfo)
        {
            if (gameStateInfo == null)
            {
                throw new Exception();
            }

            if (gameStateInfo.Player == null)
            {
                throw new Exception();
            }
            //LoadPlayer
            //this.parentEngine.RegionEntities.Player = gameStateInfo.Player;
            this.parentEngine.RegionEntities.Player.X = gameStateInfo.Player.X;
            this.parentEngine.RegionEntities.Player.Y = gameStateInfo.Player.Y;
            //LoadRegions

            return true;
            throw new System.NotImplementedException();
        }
    }
}
