namespace LostRPG.Models.Structure.Abilities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG.Models.Dynamics;
    using LostRPG.Models.Interfaces;

    /// <summary>
    /// TODO: Add descendants and remove the 'NotMapped' attribute.
    /// Spells, Arrows, etc..
    /// </summary>
    [NotMapped]
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
