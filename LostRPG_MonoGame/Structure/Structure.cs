namespace LostRPG_MonoGame.Structure
{
    using LostRPG_MonoGame.Graphics;
    using LostRPG_MonoGame.Interfaces;

    public class Structure : Environment, IRenderable // TODO
    {
        public Structure(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }

        public SpriteType SpriteType { get; }
    }
}
