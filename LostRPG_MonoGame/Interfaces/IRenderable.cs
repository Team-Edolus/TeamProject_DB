namespace LostRPG_MonoGame.Interfaces
{
    using LostRPG_MonoGame.Graphics;

    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; }
    }
}
