using Char;
using Managers;
using States;

Character<PlayableTurnManager> player = new(new Stats() { Health = 100, Agility = 5 })
{
  Name = "Ky COCK",
  Team = Team.GoodGuys,
  Weapon = new() { Name = "", Damage = 5 }
};
Character<PlayableTurnManager> bestFriend = new(new Stats() { Health = 100, Agility = 6 })
{
  Name = "Oleg Poganec",
  Team = Team.GoodGuys,
  Weapon = new() { Name = "", Damage = 3 }
};
Character podsos = new(new Stats() { Health = 100, Agility = 3 })
{
  Name = "RAM ROM",
  Team = Team.GoodGuys,
  Weapon = new() { Name = "", Damage = 6 }
};
Character enemy = new(new Stats() { Health = 50, Agility = 1 })
{
  Name = "ASSka",
  Team = Team.BadGuys
};

BattleManager battleManager = new();

await battleManager.CommenceBattle(player, bestFriend, podsos, enemy);