﻿namespace LostRPG.Client.Interfaces
{
    using LostRPG.Models.Interfaces;
    using Microsoft.Xna.Framework.Graphics;

    public interface ITextureHandler
    {
        Texture2D GetSpriteTexture(IRenderable renderableObject);
    }
}
