namespace LostRPG_MonoGame.Models.Interfaces
{
    using LostRPG_MonoGame.Models.Graphics;

    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; }
    }
}
