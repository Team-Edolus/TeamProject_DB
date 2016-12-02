namespace LostRPG_MonoGame.Models.Interfaces
{
    using System;
    public interface IUserInputInterface
    {
        event EventHandler OnRightPressed;

        event EventHandler OnLeftPressed;

        event EventHandler OnUpPressed;

        event EventHandler OnDownPressed;

        event EventHandler OnNumericKeyPressed;

        event EventHandler OnLeftMouseClick;

        void CheckForInput();
    }
}
