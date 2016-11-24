using LostRPG_MonoGame.Models.Structure.Abilities;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface ISpellCastable
    {
        Spell CastSpell(int x, int y); // TODO: Implement according to game logic.
    }
}
