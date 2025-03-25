using Char;

namespace Static;

public class DebugReporter
{
  public static void ReportBattleStart(List<Character> combatants)
  {
    WriteLine($"Begin battle commence debug:");

    foreach (Character character in combatants)
    {
      WriteLine($"\n\t{character.Name} of {character.Team.Name} entered the battle at {character.Health}HP!");
    }

    WriteLine($"\n\tAt that, the battle commences!");
  }
}