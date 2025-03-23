namespace Classes;

public class Character
{
  public required string Name { get; set; } = "";
  public required float Health { get; set => field = (value >= 0) ? value : 0; }

  public Weapon Weapon { get; set; } = new() { Name = "Bare hands", Damage = 3 };
  public Armour Armour { get; set; } = new() { Name = "Ragged cloth", ArmourValue = 2 };
  
  public void Attack(Character enemy) => Weapon.Attack(enemy);
}