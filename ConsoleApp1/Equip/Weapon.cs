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
      * (1 + (float)attacker.Stats.Strength / 25 - (float)enemy.Stats.Endurance / 75 - (float)enemy.Armour.ArmourValue / 100)
      * BlockingMultiplier(enemy)
    );
    int damageRounded = (int)Math.Round(damage);
    
    return damageRounded;
  }
  private void DamageSubject(Character subject, int damage)
  {
    subject.Health -= damage;
  }

  private float BlockingMultiplier(Character subject) => subject.ActionManager.Blocking ? 0.5f : 1f;
}