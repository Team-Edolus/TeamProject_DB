using LostRPG_MonoGame.Models.Graphics;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; }
    }
}
