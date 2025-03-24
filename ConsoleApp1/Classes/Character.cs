namespace Classes;

public class Character(Stats Stats)
{
  public required string Name { get; set; } = "";
  public int Health
  {
    get;
    set {
      field =
        value <= 0
        ? 0
        : value >= Stats.Health
        ? Stats.Health
        : value;
    }
  } = Stats.Health;

  public required Stats Stats { get; set; }

  public Weapon Weapon { get; set; } = new() { Name = "Bare hands", Damage = 3 };
  public Armour Armour { get; set; } = new() { Name = "Ragged cloth", ArmourValue = 2 };
  
  public void Attack(Character enemy) => Weapon.Attack(enemy);
}