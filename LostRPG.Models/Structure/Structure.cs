namespace LostRPG.Models.Structure
{
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG.Models.Graphics;
    using LostRPG.Models.Interfaces;

    [NotMapped]
    public class Structure : Environment, IRenderable // TODO
    {
        public Structure(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }

        public SpriteType SpriteType { get; }
    }
}
