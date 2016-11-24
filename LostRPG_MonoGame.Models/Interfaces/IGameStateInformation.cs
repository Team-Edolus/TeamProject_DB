﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LostRPG_MonoGame.Models.Structure;
using LostRPG_MonoGame.Models.Structure.Abilities;
using LostRPG_MonoGame.Models.Structure.BoostItems;
using LostRPG_MonoGame.Models.Structure.Units.Character;
using LostRPG_MonoGame.Models.Structure.Units.EnemyUnits;
using LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits;

namespace LostRPG_MonoGame.Models.Interfaces
{
    public interface IGameStateInformation
    {
        string NameOfTheLastRegion { get; set; }

        CharacterUnit Player { get; set; }

        ICollection<FriendlyNPCUnit> FriendlyNPCs { get; set; }

        ICollection<EnemyNPCUnit> Enemies { get; set; }

        ICollection<Ability> Abilities { get; set; }

        ICollection<Obstacle> Obstacles { get; set; }

        ICollection<Gateway> Gateways { get; set; }

        ICollection<Item> Items { get; set; }
    }
}
