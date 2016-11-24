using Microsoft.Xna.Framework;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IGraphicsEngine
    {
        void RedrawAll(GameTime gameTime);

        void AddBox(ITextureBox textureBox);

        ITextureBox RemoveBoxByParent(IRenderable boxParent);
    }
}
