using Char;
using States;

namespace Static;

public static class Reporter
{
  public static void ReportAttack(float damage, Character subject)
  {
    WriteLine($"\n{subject.Name} was hit for {damage}HP, {subject.Health}HP left");
  }
  public static void ReportTermination(Character subject)
  {
    WriteLine($"\n{subject.Name} was terminated.");
  }
  public static void ReportDamageEffect(float damage, Character subject)
  {
    WriteLine($"\n{subject.Name} lost {damage}HP to a negative effect. {subject.Health}HP left.");
  }
  public static void ReportRecovery(Character subject)
  {
    WriteLine($"\n{subject.Name} recovered from negatve effect!");
  }
  public static void ReportResults(Team winner)
  {
    WriteLine($"\n{winner.Name} won!");
  }
}