namespace LostRPG_MonoGame.Models.Structure
{
    public class DisposableGameObject : GameObject
    {
        public DisposableGameObject(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }

        public DisposableGameObject() : this(0, 0, 0, 0)
        {

        }
    }
}
