namespace LostRPG_MonoGame.Structure.Units.Character
{
    using LostRPG_MonoGame.Graphics;

    public class Ranger : CharacterUnit // TODO
    {
        public Ranger(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }
    }
}
