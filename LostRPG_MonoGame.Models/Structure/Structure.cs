namespace LostRPG_MonoGame.Models.Structure
{
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Interfaces;

    public class Structure : Environment, IRenderable // TODO
    {
        public Structure(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }

        public Structure() : this(0, 0, 0, 0)
        {

        }

        public SpriteType SpriteType { get; }
    }
}
