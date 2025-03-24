using Static;

namespace Classes;

public class Weapon
{
  public required int Damage { get; init; }
  public required string Name { get; init; } = "";

  public List<DamageEffect> Effects { get; init; } = [];

  public void Attack(Character enemy)
  {
    float damage = (1 - enemy.Armour.ArmourValue / 100) * Damage;
    int roundedDamage = (int)Math.Round(damage);
    enemy.Health -= roundedDamage;

    Reporter.ReportAttack(damage, enemy);

    if (enemy.Health <= 0)
      Reporter.ReportTermination(enemy);
    
    ApplyDamageEffects(enemy);
  }
  
  private void ApplyDamageEffects(Character enemy)
  {
    foreach (DamageEffect effect in Effects)
    {
      Task.Run(() => effect.DealDamage(enemy));
    }
  }
}