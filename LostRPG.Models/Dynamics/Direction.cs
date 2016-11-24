namespace LostRPG.Models.Dynamics
{
    public struct Direction // TODO: Replace with enum.
    {
        public Direction(int dirX, int dirY) : this()
        {
            this.DirX = dirX;
            this.DirY = dirY;
        }

        public int DirX { get; set; }

        public int DirY { get; set; }
    }
}
