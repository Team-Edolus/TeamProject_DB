namespace LostRPG_MonoGame.Models.Structure.BoostItems
{
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Interfaces;
    public abstract class Item : GameObject, IRenderable
    {
        protected Item(int x, int y, int sizeX, int sizeY, int healthBoost, 
            int damageBoost, int defenseBoost, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY)
        {
            this.SpriteType = spriteType;
            this.HealthPointsBoost = healthBoost;
            this.DamagePointsBoost = damageBoost;
            this.DefensePointsBoost = defenseBoost;
            this.HasBeenUsed = false;
        }

        public int HealthPointsBoost { get; }

        public int DamagePointsBoost { get; }

        public int DefensePointsBoost { get; }
        
        public SpriteType SpriteType { get; }

        public bool HasBeenUsed { get; set; }

        public void ApplyItemEffects(IUnit unit)
        {
            unit.AttackPoints += this.DamagePointsBoost;
            unit.CurrentHP += this.HealthPointsBoost;
            unit.DefensePoints += this.DefensePointsBoost;
        }
    }
}
