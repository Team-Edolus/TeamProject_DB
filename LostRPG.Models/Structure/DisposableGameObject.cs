namespace LostRPG.Models.Structure
{
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class DisposableGameObject : GameObject
    {
        public DisposableGameObject(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }
    }
}
