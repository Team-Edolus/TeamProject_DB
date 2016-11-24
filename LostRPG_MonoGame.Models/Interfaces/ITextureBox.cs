using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface ITextureBox
    {
        Texture2D Texture { get; }

        Vector2 Position { get; }

        IRenderable ParentObject { get; }

        void UpdatePosition();
    }
}
