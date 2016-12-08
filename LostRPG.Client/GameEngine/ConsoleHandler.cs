namespace LostRPG.Client.GameEngine
{
    using System;
    using LostRPG.Client.Interfaces;
    using LostRPG.Client.Resources.Static;
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
            this.RegisterCommands();
        }

        private void RegisterCommands()
        {
            this.interpreter.RegisterCommand("help", this.HelpCommand);
            this.interpreter.RegisterCommand("clear", str => this.console.Clear());
            this.interpreter.RegisterCommand("save", this.SaveCommand);
            this.interpreter.RegisterCommand("load", this.LoadCommand);
        }
        
        private string HelpCommand(string[] input)
        {
            return ConsoleStrings.HelpCommand;
        }

        private string SaveCommand(string[] input)
        {
            if (input.Length < 1)
            {
                return ConsoleStrings.SafeNameNotProvided;
            }

            if (string.IsNullOrWhiteSpace(input[0]))
            {
                return ConsoleStrings.SafeNameNotProvided;
            }
            
            var safeName = string.Join("_", input);
            var dateString = DateTime.Now.ToString(ConsoleStrings.SafeRecordDateFormat);
            var namePlusTime = safeName + "<>" + dateString;
            var outcome = this.gameLoader.SaveGame(safeName);
            if (!outcome)
            {
                return ConsoleStrings.UnsuccessfullSave;
            }

            return string.Format(ConsoleStrings.SuccessfullSave, namePlusTime);
        }

        private string LoadCommand(string[] input)
        {
            if (input.Length < 1)
            {
                return ConsoleStrings.SafeNameNotProvided;
            }

            if (string.IsNullOrWhiteSpace(input[0]))
            {
                return ConsoleStrings.SafeNameNotProvided;
            }
            
            //TODO?
            var safeName = input[0];

            this.gameLoader.LoadGame(safeName);

            //TODO.......
            return "Loaded " + safeName;
        }
    }
}
