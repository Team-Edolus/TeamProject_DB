namespace LostRPG.Models.Structure
{
    using System.ComponentModel.DataAnnotations.Schema;

    ////TODO: Add enum "ObstacleTypes"; Add non-required property ObstacleType
    /// <summary> 
    /// Clifs, Trees, Rivers, etc.
    /// </summary>

    [NotMapped]
    public class Obstacle : Environment
    {
        public Obstacle(int x, int y, int sizeX, int sizeY) 
            : base(x, y, sizeX, sizeY)
        {
        }
    }
}
