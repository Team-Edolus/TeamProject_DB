// ReSharper disable MemberCanBeMadeStatic.Local
namespace LostRPG.Client.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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

            return this.LoadGameState(gameStateInfo);
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
            var gameStateInfo = this.unitOfWork.GameStateSafes.FindEager(gss => gss.SafeName == safeName);

            if (gameStateInfo == null)
            {
                //TODO: Report non-existing safe.
                return null;
            }

            if (gameStateInfo.Player == null)
            {
                throw new ArgumentNullException(nameof(gameStateInfo), "Could not load the player.");
            }

            if (gameStateInfo.RegionStates == null)
            {
                throw new ArgumentNullException(nameof(gameStateInfo), "Could not load the regions' info.");
            }

            if (gameStateInfo.RegionStates.Any(regionState => regionState == null))
            {
                throw new ArgumentNullException(nameof(gameStateInfo), "Could not load a specific region.");
            }

            ////if (gameStateInfo.RegionStates.Any(rs => rs.Enemies.Count == 0))
            ////{
            ////    throw new Exception();
            ////}

            //string asd = string.Empty;
            //foreach (var enemy in gameStateInfo.RegionStates.FirstOrDefault().Enemies)
            //{
            //    asd += enemy.GetType().Name + Environment.NewLine;
            //}

            //using (TextWriter dsa = new StreamWriter("..//..//asdasdasda.txt"))
            //{
            //    dsa.Write(asd);
            //}

            return gameStateInfo;
        }

        private bool LoadGameState(IGameStateInfo gameStateInfo)
        {
            //LoadPlayer

            //this.parentEngine.RegionEntities.Player = gameStateInfo.Player;
            this.parentEngine.RegionEntities.Player.X = gameStateInfo.Player.X;
            this.parentEngine.RegionEntities.Player.Y = gameStateInfo.Player.Y;

            //LoadRegions

            //var regionTypes = typeof(IRegionInterface)
            //    .Assembly
            //    .GetTypes()
            //    .Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(Region<>).GetGenericTypeDefinition())
            //    .ToArray();
            ////var regionTypes = typeof(Region<>).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Region<>))).ToArray();

            //if (regionTypes.Length == 0)
            //{
            //    throw new Exception();
            //}

            ////using (TextWriter dsa = new StreamWriter("..//..//asdasdasda.txt"))
            ////{

            ////    foreach (var regionType1 in regionTypes)
            ////    {
            ////        dsa.WriteLine(regionType1.Name);
            ////    }
            ////}


            //foreach (var regionType in regionTypes)
            //{
            //    //var prop = regionType.GetField("Instance");
            //    var prop = regionType.GetProperty("GetInstance", BindingFlags.Public | BindingFlags.Static);

            //    if (prop == null)
            //    {
            //        throw new ArgumentNullException();
            //    }

            //    var regionInstance = prop.GetValue(null);// as IRegionInterface;

            //    if (regionInstance == null)
            //    {
            //        throw new ArgumentNullException();
            //    }

            //    //regionInstance.ReloadRegion(
            //    //    gameStateInfo.RegionStates.FirstOrDefault(rs => rs.RegionName == regionType.Name));
            //}

            StartRegion.GetInstance.ReloadRegion(
                gameStateInfo.RegionStates.FirstOrDefault(rs => rs.RegionName == typeof(StartRegion).Name));
            ValleyRegion.GetInstance.ReloadRegion(
                gameStateInfo.RegionStates.FirstOrDefault(rs => rs.RegionName == typeof(ValleyRegion).Name));
            MageLayerRegion.GetInstance.ReloadRegion(
                gameStateInfo.RegionStates.FirstOrDefault(rs => rs.RegionName == typeof(MageLayerRegion).Name));
            MageHouseRegion.GetInstance.ReloadRegion(
                gameStateInfo.RegionStates.FirstOrDefault(rs => rs.RegionName == typeof(MageHouseRegion).Name));

            //var currentRegionInstance = regionTypes
            //    .First(
            //        rt => rt.GetProperty("RegionName").GetValue(null).ToString() == gameStateInfo.CurrentRegion).GetProperty("GetInstance").GetValue(null) as IRegionInterface;



            switch (gameStateInfo.CurrentRegion)
            {
                case "StartRegion":
                    this.parentEngine.RegionEntities.InitialiseNewRegion(StartRegion.GetInstance);
                    break;
                case "ValleyRegion":
                    this.parentEngine.RegionEntities.InitialiseNewRegion(ValleyRegion.GetInstance);
                    break;
                case "MageLayerRegion":
                    this.parentEngine.RegionEntities.InitialiseNewRegion(MageLayerRegion.GetInstance);
                    break;
                case "MageHouseRegion":
                    this.parentEngine.RegionEntities.InitialiseNewRegion(MageHouseRegion.GetInstance);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            //var currentRegionInstance = regionTypes
            //    .First(
            //        rt => rt.Name == gameStateInfo.CurrentRegion).GetProperty("GetInstance").GetValue(null) as IRegionInterface;

            //this.parentEngine.RegionEntities.InitialiseNewRegion(currentRegionInstance);

            return true;
            throw new System.NotImplementedException();
        }
    }
}
