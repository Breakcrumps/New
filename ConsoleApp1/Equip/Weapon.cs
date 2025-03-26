using Static;
using States;
using Char;

namespace Equip;

public class Weapon
{
  public required int Damage { get; init; }
  public required string Name { get; init; } = "";

  public List<DamageEffect> Effects { get; init; } = [];

  public async Task Attack(Character attacker, Character subject)
  {
    int damage = ComputeDamage(subject);
    DamageSubject(subject, damage);

    await Reporter.ReportAttack(damage, attacker, subject);
    
    ApplyDamageEffects(subject);
  }
  
  // Fucked up shit, to be deleted / rewritten.
  private void ApplyDamageEffects(Character enemy)
  {
    // foreach (DamageEffect effect in Effects)
    // {
    //   Task.Run(() => effect.DealDamage(enemy));
    // }
  }

  private int ComputeDamage(Character enemy)
  {
    float armourMultiplicator = 1 - (enemy.Armour.ArmourValue / 100);
    float blockingMultiplicator = enemy.ActionManager.Shielding ? .5f : 1;
    
    float damage =  armourMultiplicator * blockingMultiplicator * Damage;
    int damageRounded = (int)Math.Round(damage);
    
    return damageRounded;
  }
  private void DamageSubject(Character subject, int damage)
  {
    subject.Health -= damage;
  }
}