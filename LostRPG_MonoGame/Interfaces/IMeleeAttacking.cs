namespace LostRPG_MonoGame.Interfaces
{
    using System;
    using LostRPG_MonoGame.Structure;

    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY, TimeSpan totalTime);
    }
}
