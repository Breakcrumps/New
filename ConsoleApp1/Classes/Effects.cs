using Static;

namespace Classes;

public class DamageEffect
{
  public required float Duration { get; init => field = (value >= 0) ? value : 0; }
  public required float Phase { get; init => field = (value > 0) ? value : Duration; }
  public required int Damage { get; init; }

  public async Task DealDamage(Character subject)
  {
    int times = (int)(Duration / Phase);

    for (float i = 0; i < times; i++)
    {
      subject.Health -= Damage;

      Reporter.ReportDamageEffect(Damage, subject);

      await Task.Delay((int)(Phase * 1000));
    }

    Reporter.ReportRecovery(subject);
  }
}