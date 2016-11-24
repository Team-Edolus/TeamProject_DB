using Microsoft.Xna.Framework.Graphics;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface ITextureHandler
    {
        Texture2D GetSpriteTexture(IRenderable renderableObject);
    }
}
