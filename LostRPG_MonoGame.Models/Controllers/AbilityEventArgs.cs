namespace LostRPG_MonoGame.Models.Controllers
{
    using System;
    public class AbilityEventArgs : EventArgs
    {
        public AbilityEventArgs(int mouseX, int mouseY)
        {
            this.MouseX = mouseX;
            this.MouseY = mouseY;
        }

        public int MouseX { get; set; }

        public int MouseY { get; set; }
    }
}
