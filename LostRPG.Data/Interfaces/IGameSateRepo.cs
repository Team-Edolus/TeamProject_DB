namespace LostRPG.Data.Interfaces
{
    using System;
    using System.Linq.Expressions;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Interfaces;

    public interface IGameSateRepo : IRepository<GameStateInfo>
    {
        IGameStateInfo FindEager(Expression<Func<IGameStateInfo, bool>> where);
    }
}
