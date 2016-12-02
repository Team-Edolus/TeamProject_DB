namespace LostRPG_MonoGame.Models.Interfaces
{
    using System;
    using LostRPG_MonoGame.Models.Structure.Abilities;
    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY, TimeSpan totalTime);
    }
}
