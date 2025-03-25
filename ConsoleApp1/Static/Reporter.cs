using Char;
using States;

namespace Static;

public static class Reporter
{
  public static Dictionary<string, string[]> PlayerTurnOptions => new()
  {
    ["Attack"] = ["Attack", "1"],
    ["Shield"] = ["Shield", "2"],
    ["Wait"] = ["Wait", "None", "3"]
  };

  public static void ReportAttack(float damage, Character subject)
  {
    Report($"{subject.Name} was hit for {damage}HP, {subject.Health}HP left");
  }
  public static void ReportTermination(Character subject)
  {
    Report($"{subject.Name} was terminated.");
  }
  public static void ReportDamageEffect(float damage, Character subject)
  {
    Report($"{subject.Name} lost {damage}HP to a negative effect. {subject.Health}HP left.");
  }
  public static void ReportRecovery(Character subject)
  {
    Report($"{subject.Name} recovered from negatve effect!");
  }
  public static void ReportResults(Team winner)
  {
    Report($"{winner.Name} won!");
  }
  public static void ReportActiveCharacters(Character caller, List<Character> activeCharacters)
  {
    for (int i = 0; i < activeCharacters.Count; i++)
    {
      Character activeCharacter = activeCharacters[i];
      Report($"{i + 1}. {activeCharacter.Name}\t{activeCharacter.Health}HP\t{activeCharacter.Team.Name}{(activeCharacter == caller ? "\t<-- [YOU]" : "")}");
    }
  }
  public static void PresentTurnOptions()
  {
    Report($"What will you do?");
    Report($"1 or Attack: Attack an enemy.");
    Report($"2 or Shield: Shield against incoming attacks for a turn.");
    Report($"3 or None or Wait: Do nothing for the turn.");
  }

  public static void Report(string message)
  {
    WriteLine($"\n{message}");
  }
}