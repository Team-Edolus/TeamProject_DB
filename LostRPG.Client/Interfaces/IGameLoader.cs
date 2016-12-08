namespace LostRPG.Client.Interfaces
{
    public interface IGameLoader
    {
        bool SaveGame(string safeName);

        bool LoadGame(string safeName);
    }
}
