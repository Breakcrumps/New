using Static;
using States;
using Char;

namespace Equip;

public class Weapon
{
  public required int Damage { get; init; }
  public required string Name { get; init; } = "";

  public List<DamageEffect> Effects { get; init; } = [];

  public async Task Attack(Character enemy)
  {
    int damage = ComputeDamage(enemy);
    DamageEnemy(enemy, damage);

    await Reporter.ReportAttack(damage, enemy);
    
    ApplyDamageEffects(enemy);
  }
  
  private void ApplyDamageEffects(Character enemy)
  {
    foreach (DamageEffect effect in Effects)
    {
      Task.Run(() => effect.DealDamage(enemy));
    }
  }

  private int ComputeDamage(Character enemy)
  {
    float damage = (1 - enemy.Armour.ArmourValue / 100) * Damage;
    int damageRounded = (int)Math.Round(damage);
    return damageRounded;
  }
  private void DamageEnemy(Character enemy, int damage)
  {
    enemy.Health -= damage;
  }
}