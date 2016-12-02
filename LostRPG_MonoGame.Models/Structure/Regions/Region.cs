namespace LostRPG_MonoGame.Models.Structure.Regions
{
    using System;
    using System.Collections.Generic;
    using LostRPG_MonoGame.Models.GameEngine;
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Interfaces;
    using LostRPG_MonoGame.Models.Structure.BoostItems;
    using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
    using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;
    public abstract class Region<T> : GameObject, IRegionInterface
        where T : Region<T>, new()
    {
        private const int DefaultX = 0;
        private const int DefaultY = 0;
        private const int DefaultSizeX = 1280;
        private const int DefaultSizeY = 720;

        private static readonly T Instance = new T();
        ////
        private bool isInitialised;

        private RegionEntities regionEntities;

        protected Region() : base(DefaultX, DefaultY, DefaultSizeX, DefaultSizeY)
        {
            this.RegionFriendlyNPCs = new List<FriendlyNPCUnit>();
            this.RegionEnemies = new List<EnemyNPCUnit>();
            this.RegionObstacles = new List<Obstacle>();
            this.RegionGateways = new List<Gateway>();
            this.RegionItems = new List<Item>();

            this.ObstacleParser = new ObstacleParser();
            this.isInitialised = false;
        }

        protected IObstacleParser ObstacleParser { get; }
        
        public static T GetInstance
        {
            get
            {
                if (Instance.isInitialised)
                {
                    return Instance;
                }

                Instance.Initialise();
                Instance.isInitialised = true;
                return Instance;
            }
        }

        public SpriteType SpriteType { get; protected set; }

        public List<FriendlyNPCUnit> RegionFriendlyNPCs { get; }

        public List<EnemyNPCUnit> RegionEnemies { get; }

        public List<Obstacle> RegionObstacles { get; }

        public List<Gateway> RegionGateways { get; }

        public List<Item> RegionItems { get; }

        protected RegionEntities RegionEntities
        {
            get
            {
                return this.regionEntities;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.regionEntities = value;
            }
        }

        protected abstract void SetFriendlyNPCs();

        protected abstract void SetEnemies();

        protected abstract void SetGateways();

        protected abstract void SetObstacles();

        protected abstract void SetBoostItems();

        protected void Initialise()
        {
            this.RegionEntities = RegionEntities.GetInstance();
            this.SetFriendlyNPCs();
            this.SetEnemies();
            this.SetGateways();
            this.SetObstacles();
            this.SetBoostItems();
        }
    }
}
