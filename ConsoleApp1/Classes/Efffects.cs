using System.ComponentModel.DataAnnotations;

namespace Classes;

public class DamageEffect()
{
  public required float Duration { get; init; }
  public required float Phase { get; init; }
  public required float Damage { get; init; }

  public async Task DealDamage(Character character)
  {
    int times = (int)(Duration / Phase);

    for (float i = 0; i < times; i++)
    {
      character.Health -= Damage;
      await Task.Delay((int)(Phase * 1000));
    }
  }
}