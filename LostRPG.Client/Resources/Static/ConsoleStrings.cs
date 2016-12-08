namespace LostRPG.Client.Resources.Static
{
    public static class ConsoleStrings
    {
        public const string HelpCommand = "Commands:\r\n>> help - Displays this information." +
                                          "\r\n>> clear - Clears the console canvas." +
                                          "\r\n>> save [safe_name] - Creates a new safe with the specified name." +
                                          "\r\n>> load [safe_name] - Loads the specified safe record.";

        public const string SafeRecordDateFormat = "dd.MMM.yy HH:mm:ss";

        public const string SuccessfullSave = "Successfully saved! Record: {0}";

        public const string UnsuccessfullSave = "A problem with saving occured. Please try again.";

        public const string SafeNameNotProvided = "Please provide a name for the safe.";

        public const string SuccessfullLoad = "Successfully loaded from the database!";
    }
}
