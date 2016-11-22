namespace LostRPG_MonoGame.Interfaces
{
    using System;
    using LostRPG_MonoGame.Structure;
    using LostRPG_MonoGame.Structure.Abilities;

    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY, TimeSpan totalTime);
    }
}
