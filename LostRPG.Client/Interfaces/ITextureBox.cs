﻿namespace LostRPG.Client.Interfaces
{
    using LostRPG.Models.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ITextureBox
    {
        Texture2D Texture { get; }

        Vector2 Position { get; }

        IRenderable ParentObject { get; }

        void UpdatePosition();
    }
}
