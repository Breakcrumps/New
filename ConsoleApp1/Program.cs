using Classes;

Character player = new()
{
  Name = "John",
  Health = 100
};

Character enemy = new()
{
  Name = "Urod",
  Health = 100
};

Weapon fireWeapon = new() 
{
  Name = "Phoenix' Ash",
  Damage = 70
};

player.Weapon = fireWeapon;

player.Attack(enemy);

player.Attack(enemy);

Write("\n");