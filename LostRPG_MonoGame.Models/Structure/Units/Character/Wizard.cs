using LostRPG_MonoGame.Models.Graphics;

namespace LostRPG_MonoGame.Models.Structure.Units.Character
{
    public class Wizard : CharacterUnit // TODO
    {
        public Wizard(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }

        public Wizard() : this(0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        {

        }
    }
}
