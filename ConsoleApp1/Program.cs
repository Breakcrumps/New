using Classes;

Character player = new() { Name = "John", Health = 100 };

Character enemy = new() { Name = "Urod", Health = 100 };

Weapon fireWeapon = new() {
  Name = "Phoenix' Ash",
  Damage = 70,
  Effects = [new() { Damage = 1, Duration = 10, Phase = 1 }]
};

player.Weapon = fireWeapon;

player.Attack(enemy);

Weapon poisonWeapon = new() {
  Name = "Poised raze",
  Damage = 10,
  Effects = [new() { Damage = 3, Duration = 20, Phase = 5 }]
};

enemy.Weapon = poisonWeapon;

enemy.Attack(player);

while (true)
{
  
}