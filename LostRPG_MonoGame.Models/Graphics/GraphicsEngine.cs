namespace LostRPG_MonoGame.Models.Graphics
{
    using System.Collections.Generic;
    using System.Linq;
    using LostRPG_MonoGame.Models.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public class GraphicsEngine : IGraphicsEngine
    {
        private readonly ISet<ITextureBox> textureBoxes;
        private readonly SpriteBatch spriteBatch;

        public GraphicsEngine(SpriteBatch spriteBatch)
        {
            this.textureBoxes = new HashSet<ITextureBox>();
            this.spriteBatch = spriteBatch;
        }

        public void AddBox(ITextureBox textureBox)
        {
            if (textureBox == null)
            {
                return;
            }

            this.textureBoxes.Add(textureBox);
        }

        public ITextureBox RemoveBoxByParent(IRenderable boxParent)
        {
            var oldBox = this.GetBoxByParent(boxParent);
            this.textureBoxes.Remove(oldBox);
            return oldBox;
        }

        public void RedrawAll(GameTime gameTime)
        {
            this.spriteBatch.GraphicsDevice.Clear(Color.White);
            this.spriteBatch.Begin();
            foreach (var textureBox in this.textureBoxes)
            {
                this.spriteBatch.Draw(textureBox.Texture, textureBox.Position);
            }

            this.spriteBatch.End();
        }

        private ITextureBox GetBoxByParent(IRenderable parent)
        {
            var resultBox = this.textureBoxes.First(tb => tb.ParentObject == parent);
            return resultBox;
        }
    }
}
