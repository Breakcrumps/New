namespace Classes;

public class Weapon()
{
  public required int Damage { get; init; }
  public required string Name { get; init; } = "";

  public List<DamageEffect> Effects { get; init; } = [];

  public void Attack(Character enemy)
  {
    float damage = (1 - enemy.Armour.ArmourValue) * Damage;
    enemy.Health -= damage;

    enemy.Effects.AddRange(Effects);

    ReportAttack(damage, enemy);

    if (enemy.Health <= 0)
      ReportTermination(enemy);
  }
  
  private void ReportAttack(float damage, Character enemy)
  {
    WriteLine($"\n{enemy.Name} was hit for {damage}HP, {enemy.Health}HP left");
  }
  private void ReportTermination(Character enemy)
  {
    WriteLine($"\n{enemy.Name} was terminated.");
  }
}