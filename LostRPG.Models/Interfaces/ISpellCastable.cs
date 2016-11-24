namespace LostRPG.Models.Interfaces
{
    using LostRPG.Models.Structure.Abilities;

    public interface ISpellCastable
    {
        Spell CastSpell(int x, int y); // TODO: Implement according to game logic.
    }
}
