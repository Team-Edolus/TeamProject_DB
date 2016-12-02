using System.ComponentModel.DataAnnotations.Schema;

namespace LostRPG_MonoGame.Models.Structure
{
    using LostRPG_MonoGame.Models.Interfaces;

    //parent!!!
    [Table("GameObjects")]
    public abstract class GameObject : IGameObject
    {
        protected GameObject(int x, int y, int sizeX, int sizeY)
        {
            this.X = x;
            this.Y = y;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        public GameObject(): this(0,0,0,0)
        {
            
        }

        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int SizeX { get; }

        public int SizeY { get; }
    }
}
