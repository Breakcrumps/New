using Static;
using Char;

namespace Equip;

public class Weapon
{
  public required int Damage { get; init; }
  public required string Name { get; init; } = "NoName";

  public async Task Attack(Character attacker, Character subject)
  {
    int damage = ComputeDamage(attacker, subject);
    DamageSubject(subject, damage);

    await Reporter.ReportAttack(damage, attacker, subject);
  }

  private int ComputeDamage(Character attacker, Character enemy)
  {
    float damage = (
      Damage
      * StrengthMultiplier(attacker)
      * ArmourMultiplier(enemy)
      * BlockingMultiplier(enemy)
      * EnduranceMultiplier(enemy)
    );
    int damageRounded = (int)Math.Round(damage);
    
    return damageRounded;
  }
  private void DamageSubject(Character subject, int damage)
  {
    subject.Health -= damage;
  }

  private float StrengthMultiplier(Character attacker) => 1 + ((float)attacker.ComputePower() / 100);
  private float ArmourMultiplier(Character subject) => 1 - ((float)subject.Armour.ArmourValue / 100);
  private float BlockingMultiplier(Character subject) => subject.ActionManager.Shielding ? .5f : 1;
  private float EnduranceMultiplier(Character subject) => 1 - ((float)subject.ComputeDefence() / 100);
}