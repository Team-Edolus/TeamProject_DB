namespace LostRPG.Models.Structure
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG.Models.Interfaces;
    
    public abstract class GameObject : IGameObject
    {
        protected GameObject()
        {
        }

        protected GameObject(int x, int y, int sizeX, int sizeY)
        {
            this.X = x;
            this.Y = y;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        [Key]
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        
        [NotMapped]
        public int SizeX { get; protected set; }

        [NotMapped]
        public int SizeY { get; protected set; }
    }
}
