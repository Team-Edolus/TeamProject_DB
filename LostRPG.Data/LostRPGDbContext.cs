namespace LostRPG.Data
{
    using System.Data.Entity;

    public class LostRPGDbContext : DbContext
    {
        public LostRPGDbContext()
            : base("name=LostRPGDbContext")
        {
        }
    }
}
