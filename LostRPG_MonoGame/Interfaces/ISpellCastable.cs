namespace LostRPG_MonoGame.Interfaces
{
    using LostRPG_MonoGame.Structure;
    using LostRPG_MonoGame.Structure.Abilities;

    public interface ISpellCastable
    {
        Spell CastSpell(int x, int y); // TODO: Implement according to game logic.
    }
}
