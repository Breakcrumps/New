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

  public static async Task ReportAttack(float damage, Character attacker, Character subject)
  {
    Report($"{subject.Name} was hit:\n--> For: {damage}HP\n--> By: {attacker.Name}\n--> Left: {subject.Health}HP");
    await Task.Delay(1_000);
  }
  public static async Task ReportBattleStart()
  {
    Report($"The battle begins!");
    await Task.Delay(1_000);
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
      Report($"\t{i + 1}. {activeCharacter.Name}\t{activeCharacter.Health}HP\t{activeCharacter.Team.Name}{(activeCharacter == caller ? "\t<-- [YOU]" : "")}");
    }
  }
  public static void PresentTurnOptions()
  {
    Report($"What will you do?");
    Report($"\t1 or Attack: Attack an enemy.");
    Report($"\t2 or Shield: Shield against incoming attacks for a turn.");
    Report($"\t3 or None or Wait: Do nothing for the turn.");
  }
  public static void ComeAgain()
  {
    Report("Come again?");
  }
  public static void PresentAttackOptions(Character caller, List<Character> activeCharacters)
  {
    Clear();
    Report("Whom to attack?");
    Report("\t0. Return to action choice.");
    ReportActiveCharacters(caller, activeCharacters);
    Report("(Please enter the enemy's number or 0 to return.)");
  }

  public static void Report(string message)
  {
    Console.WriteLine($"\n{message}");
  }
  public static void Clear()
  {
    Console.Clear();
  }
  public static string Read() => Console.ReadLine()!.Trim();
}