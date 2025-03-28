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
    float damage =  (
      Damage
      * ArmourMultiplicator(enemy)
      * BlockingMultiplicator(enemy)
      * EnduranceMultiplier(enemy)
    );
    int damageRounded = (int)Math.Round(damage);
    
    return damageRounded;
  }
  private void DamageSubject(Character subject, int damage)
  {
    subject.Health -= damage;
  }

  private float ArmourMultiplicator(Character subject) => 1 - (subject.Armour.ArmourValue / 100);
  private float BlockingMultiplicator(Character subject) => subject.ActionManager.Shielding ? .5f : 1;
  private float EnduranceMultiplier(Character subject) => 1f;
}