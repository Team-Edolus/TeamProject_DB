namespace LostRPG.Models.Structure.Units.Character
{
    using LostRPG.Models.Graphics;

    public class Wizard : CharacterUnit // TODO
    {
        public Wizard(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }
    }
}
