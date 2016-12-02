namespace LostRPG_MonoGame.Models.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface IGraphicsEngine
    {
        void RedrawAll(GameTime gameTime);

        void AddBox(ITextureBox textureBox);

        ITextureBox RemoveBoxByParent(IRenderable boxParent);
    }
}
