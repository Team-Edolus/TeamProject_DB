namespace LostRPG.Client
{
    using System;
    using LostRPG.Data;

#if WINDOWS || LINUX

    public static class MainClass
    {
        [STAThread]
        public static void Main()
        {
            var context = new LostRPGDbContext();
            ////
            context.Database.Initialize(true);
            
            using (var game = new LostRPGMain())
                game.Run();
        }
    }
#endif
}
