namespace LostRPG.Models.Interfaces
{
    public interface ITimeoutable
    {
        int MaxLifespanInMS { get; }

        int CurrentLifespanInMS { get; }

        bool HasTimedOut { get; }
    }
}
