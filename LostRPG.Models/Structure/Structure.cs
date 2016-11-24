namespace LostRPG.Models.Structure
{
    using LostRPG.Models.Graphics;
    using LostRPG.Models.Interfaces;

    public class Structure : Environment, IRenderable // TODO
    {
        public Structure(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }

        public SpriteType SpriteType { get; }
    }
}
