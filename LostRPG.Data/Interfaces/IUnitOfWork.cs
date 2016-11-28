namespace LostRPG.Data.Interfaces
{
    using LostRPG.Models.GameState;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.Character;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    public interface IUnitOfWork
    {
        IRepository<GameStateInfo>  GameStateSafes { get; }

        IRepository<RegionState> RegionStates { get; }

        IRepository<CharacterUnit> Players { get; }

        IRepository<FriendlyNPCUnit> FrienlyNPCs { get; }

        IRepository<EnemyNPCUnit> Enemies { get; }

        IRepository<Item> Items { get; }

        void Commit();
    }
}
