namespace LostRPG.Client.Interfaces
{
    using LostRPG.Models.Interfaces;

    public interface IGameLoader
    {
        void SaveGame(string safeName);

        void LoadGame(IGameStateInfo information);
    }
}
