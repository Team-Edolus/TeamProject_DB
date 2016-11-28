namespace LostRPG.Client.GameEngine
{
    using System;
    using LostRPG.Client.Interfaces;
    using QuakeConsole;

    /// <summary>
    /// Deals with all the logic regarding the console.
    /// Stores all the console commands' definitions.
    /// </summary>
    public class ConsoleHandler
    {
        private readonly ConsoleComponent console;

        private readonly IGameLoader gameLoader;

        //private readonly Engine engine;

        private ManualInterpreter interpreter;

        public ConsoleHandler(ConsoleComponent console, IGameLoader gameLoader)
        {
            this.console = console;
            this.gameLoader = gameLoader;
            //this.engine = engine;
            this.ConfigureConsole();
        }

        /// <summary>
        /// Used to access the console settings.
        /// </summary>
        private void ConfigureConsole()
        {
            this.interpreter = new ManualInterpreter();
            this.console.Interpreter = this.interpreter;
            this.RegisterSaveCommand();
        }

        private void RegisterSaveCommand()
        {
            this.interpreter.RegisterCommand("save", this.SaveCommand);
        }

        private string SaveCommand(string[] input)
        {
            if (input.Length < 1)
            {
                return "Please provide a name for the safe.";
            }

            if (string.IsNullOrWhiteSpace(input[0]))
            {
                return "Please provide a name for the safe.";
            }
            
            var name = string.Join("_", input);
            var date = DateTime.Now.ToString("dd.MMM.yy HH:mm:ss");
            var safeName = name + "<>" + date;
            this.gameLoader.SaveGame(safeName);
            return $"{safeName} - Successfully saved!";
        }
    }
}
