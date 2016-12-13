namespace LostRPG.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using LostRPG.Data.Interfaces;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Interfaces;

    public class GameStateRepo : Repository<GameStateInfo>, IGameSateRepo
    {
        public GameStateRepo(LostRPGDbContext context) : base(context)
        {
        }

        public IGameStateInfo FindEager(Expression<Func<IGameStateInfo, bool>> expr)
        {
            ////return this.Context.GameStateInfos.Include(gsi => gsi.Player).FirstOrDefault(expr);
            return this.Context.GameStateInfos.Include(gsi => gsi.Player).Include(gsi => gsi.RegionStates).FirstOrDefault(expr);
        }
    }
}
