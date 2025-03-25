﻿using Char;
using Managers;
using States;

Character<PlayableTurnManager> player = new(new Stats() { Health = 100, Agility = 5 })
{
  Name = "Hero",
  Team = Team.GoodGuys,
  Weapon = new() { Name = "", Damage = 50 }
};
Character enemy = new(new Stats() { Health = 50, Agility = 1 })
{
  Name = "Arse",
  Team = Team.BadGuys
};

BattleManager battleManager = new();

await battleManager.CommenceBattle(player, enemy);