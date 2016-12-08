namespace LostRPG_MonoGame
{
    using System;
    using System.Linq;
    using LostRPG_MonoGame.Data;
    using LostRPG_MonoGame.Data.Interfaces;
    using LostRPG_MonoGame.Data.Repositories;
    using LostRPG_MonoGame.Models.Structure.Units.Character;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();

            //because of this the game didn't started
          //  unitOfWork.GameObjects.GetById(1);
            using (var game = new Game1(unitOfWork))
            {
                game.Run();
               
            }
        }
    }
#endif
}
