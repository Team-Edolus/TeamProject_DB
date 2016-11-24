namespace LostRPG_MonoGame.Structure.Abilities
{
    using System;
    using LostRPG_MonoGame.GameEngine;
    using LostRPG_MonoGame.Interfaces;

    /// <summary>
    /// Spells, Arrows, etc..
    /// </summary>
    public abstract class Projectile : GameObject, IMoveable   // Make an interface?   // TODO: 
    {
        protected Projectile(int sizeX, int sizeY, int x, int y) : base(sizeX, sizeY, x, y)
        {
        }

        public Direction Direction { get; set; }

        public int MovementSpeed { get; }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
