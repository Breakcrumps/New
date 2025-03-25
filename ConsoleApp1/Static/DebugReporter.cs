using Char;

namespace Static;

public static class DebugReporter
{
  public static void ReportBattleStart(List<Character> combatants)
  {
    Reporter.Report($"Begin battle commence debug:");

    foreach (Character character in combatants)
    {
      Reporter.Report($"\t{character.Name} of {character.Team.Name} entered the battle at {character.Health}HP!");
    }

    Reporter.Report($"\tAt that, the battle commences!");
  }
  public static void ReportPlayerTurnStart()
  {
    Reporter.Report("Starting player-controlled turn.");
  }
}