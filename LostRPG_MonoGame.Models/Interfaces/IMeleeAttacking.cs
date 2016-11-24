using System;
using LostRPG_MonoGame.Models.Structure.Abilities;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY, TimeSpan totalTime);
    }
}
