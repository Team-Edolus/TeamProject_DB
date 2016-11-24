namespace LostRPG.Models.Structure
{
    ////TODO: Add enum "ObstacleTypes"; Add non-required property ObstacleType
    /// <summary> 
    /// Clifs, Trees, Rivers, etc.
    /// </summary>
    public class Obstacle : Environment
    {
        public Obstacle(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }
    }
}
