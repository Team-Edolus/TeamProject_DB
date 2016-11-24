namespace LostRPG.Models.Interfaces
{
    using LostRPG.Models.Graphics;

    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; }
    }
}
