namespace LostRPG.Models.Structure.Units.Character
{
    using LostRPG.Models.Graphics;

    public class Ranger : CharacterUnit // TODO
    {
        public Ranger(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }
    }
}
