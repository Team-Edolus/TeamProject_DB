namespace LostRPG.Client.GameEngine
{
    using System;
    using System.Collections.Generic;
    using LostRPG.Client.Interfaces;
    using LostRPG.Client.Regions;
    using LostRPG.Models.Interfaces;
    using LostRPG.Models.Structure;
    using LostRPG.Models.Structure.Abilities;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.Character;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public sealed class RegionEntities
    {
        ////Load Order: Background -> (Items) -> Enemies -> Player
        
        private static RegionEntities _instance;

        private readonly IPaintInterface painter;

        private IRegionInterface currentRegion;

        private RegionEntities(Engine engine ,IPaintInterface painter)
        {
            this.painter = painter;
            this.ParentEngine = engine;
        }

        public Engine ParentEngine { get; }

        public ICharacterUnit Player { get; private set; }

        public List<FriendlyNPCUnit> FriendlyNPCs { get; private set; }

        public List<EnemyNPCUnit> Enemies { get; private set; }

        public List<Ability> Abilities { get; private set; }

        public List<Obstacle> Obstacles { get; private set; }

        public List<Gateway> Gateways { get; private set; }

        public List<Item> Items { get; private set; }

        public static void InstantiateClass(Engine engine, IPaintInterface painter)
        {
            _instance = new RegionEntities(engine, painter);
            _instance.SetupFirstRegion();
        }

        public static RegionEntities GetInstance()
        {
            if (_instance == null)
            {
                throw new Exception("Problem with Singleton(Region Entities)!");
            }

            return _instance;
        }

        public string GetCurrentRegionName()
        {
            return this.currentRegion.GetType().Name;
        }

        public void InitialiseNewRegion(IRegionInterface newRegion)
        {
            this.RemoveOldGraphicObjects();

            this.currentRegion = newRegion;
            this.LoadRegionEntities();

            this.AddNewGraphicObjects();
        }

        private void AddNewGraphicObjects()
        {
            this.painter.SetBackground(this.currentRegion);
            foreach (var friendlyNpcUnit in this.FriendlyNPCs)
            {
                this.painter.AddObject(friendlyNpcUnit);
            }

            foreach (var enemy in this.Enemies)
            {
                this.painter.AddObject(enemy);
            }

            this.painter.AddObject(this.Player);

            foreach (var item in this.Items)
            {
                this.painter.AddObject(item);
            }
        }

        private void RemoveOldGraphicObjects()
        {
            this.painter.RemoveObject(this.Player);

            foreach (var friendlyNpcUnit in this.FriendlyNPCs)
            {
                this.painter.RemoveObject(friendlyNpcUnit);
            }

            foreach (var enemy in this.Enemies)
            {
                this.painter.RemoveObject(enemy);
            }

            foreach (var item in this.Items)
            {
                this.painter.RemoveObject(item);
            }

            foreach (var ability in this.Abilities)
            {
                if (ability is IRenderable)
                {
                    this.painter.RemoveObject(ability as IRenderable);
                }
            }

            this.painter.RemoveObject(this.currentRegion); // (background)
        }

        private void LoadRegionEntities()
        {
            this.FriendlyNPCs = this.currentRegion.RegionFriendlyNPCs;
            this.Enemies = this.currentRegion.RegionEnemies;
            this.Obstacles = this.currentRegion.RegionObstacles;
            this.Gateways = this.currentRegion.RegionGateways;
            this.Items = this.currentRegion.RegionItems;
            this.Abilities = new List<Ability>();
        }

        private void SetupFirstRegion()
        {
            ////this.currentRegion = MageLayerRegion.GetInstance;
            this.currentRegion = StartRegion.GetInstance;
            this.Player = new Warrior(1000, 350);
            this.LoadRegionEntities();
            this.AddNewGraphicObjects();
        }
    }
}