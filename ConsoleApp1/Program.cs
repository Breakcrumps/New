using Char;

PlayableCharacter player = new(new Stats() { Health = 100, Agility = 5 })
{
  Name = "Hero"
};
Character enemy = new(new Stats() { Health = 50, Agility = 1 })
{
  Name = "Arse"
};

player.Attack(enemy);