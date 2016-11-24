namespace LostRPG.Models.Interfaces
{
    using System;
    using LostRPG.Models.Structure.Abilities;

    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY, TimeSpan totalTime);
    }
}
