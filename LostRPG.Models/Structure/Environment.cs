namespace LostRPG.Models.Structure
{
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public abstract class Environment : GameObject
    {
        protected Environment(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }
    }
}
