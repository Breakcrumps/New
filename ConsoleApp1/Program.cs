using Char;
using Equip;
using Managers;
using States;

Character<PlayableTurnManager> player = new(new Stats(10, 12, 1_000, 10, 5))
{
  Name = "Ass",
  Team = Team.GoodGuys,
  BaseHealth = 10,
  BaseDefence = 10
};
Character friend = new(new Stats(10, 12, 1, 10, 5))
{
  Name = "Friend",
  Team = Team.GoodGuys,
  BaseHealth = 10,
  BaseDefence = 10
};
Character enemy = new(new Stats(10, 12, 100, 10, 5))
{
  Name = "Arse",
  Team = Team.BadGuys,
  BaseHealth = 10,
  BaseDefence = 10,
  Weapon = Weapons.VenomousHunch()
};

BattleManager battleManager = new();

await battleManager.CommenceBattle(player, friend, enemy);