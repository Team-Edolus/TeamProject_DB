namespace LostRPG_MonoGame.Models.Interfaces
{
    using LostRPG_MonoGame.Models.Structure.Abilities;
    public interface ISpellCastable
    {
        Spell CastSpell(int x, int y); // TODO: Implement according to game logic.
    }
}
