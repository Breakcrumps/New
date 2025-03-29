using Char;
using Equip;
using Managers;
using States;

Character<PlayableTurnManager> player = new(new Stats(10, 2, 2, 2, 2))
{
  Name = "Makoto Yuuki",
  Team = Team.GoodGuys(),
  Weapon = Weapons.PhoenixAsh()
};
Character<PlayableTurnManager> friend = new(new Stats(1, 3, 2, 1, 3))
{
  Name = "Yukari Takeba",
  Team = Team.GoodGuys()
};

Character enemyOne = new(new Stats(2, 2, 2, 2, 2))
{
  Name = "Roy",
  Team = Team.BadGuys()
};

await BattleManager.CommenceBattle(player, friend, enemyOne);