namespace LostRPG.Models.Structure
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Used to load new regions.
    /// Collision-free
    /// </summary>

    [NotMapped]
    public class Gateway : Environment
    {
        private readonly Action loadingAction;
        private readonly Action<int, int> playerPositionAction;
        private readonly int newPlayerX;
        private readonly int newPlayerY;

        public Gateway(int x, int y, int sizeX, int sizeY, Action loadingAction, 
            int nX, int nY, Action<int, int> playerPositionAction) 
            : base(x, y, sizeX, sizeY)
        {
            this.loadingAction = loadingAction;
            this.newPlayerX = nX;
            this.newPlayerY = nY;
            this.playerPositionAction = playerPositionAction;
        }

        public void TriggerAction()
        {
            this.playerPositionAction.Invoke(this.newPlayerX, this.newPlayerY);
            this.loadingAction.Invoke();
        }
    }
}
