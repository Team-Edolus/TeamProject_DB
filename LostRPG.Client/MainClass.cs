namespace LostRPG.Client
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using System.Diagnostics;
    using LostRPG.Data;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class MainClass
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var context = new LostRPGDbContext();

            context.Database.Initialize(true);
            
            using (var game = new LostRPGMain())
                game.Run();
        }
    }
#endif
}
