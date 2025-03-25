using Char;
using Static;

namespace Managers;

public readonly struct PlayableTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character caller, List<Character> activeCharacters)
  {
    DebugReporter.ReportPlayerTurnStart();
    
    Reporter.ReportActiveCharacters(caller, activeCharacters);
    
    Reporter.PresentTurnOptions();

    string directive = await GetNextDirective();

    if (directive == "Attack")
    {
      await Attack(caller, activeCharacters);
    }
  }
  private async Task<string> GetNextDirective()
  {
    string? input = await Task.Run(() => ReadLine()!.Trim());

    while (!Reporter.PlayerTurnOptions.Any(kvp => kvp.Value.Contains(input)))
    {
      Reporter.Report("Come again?");
      input = await Task.Run(() => ReadLine()!.Trim());
    }

    string directive = Reporter.PlayerTurnOptions.FirstOrDefault(kvp => kvp.Value.Contains(input)).Key;

    return directive!;
  }

  private async Task Attack(Character caller, List<Character> activeCharacters)
  {
    Reporter.Report("Whom to attack?");
    Reporter.Report("\tPlease enter the enemy's number or 0 to return.");

    string input = await Task.Run(() => ReadLine()!.Trim());
    int enemyNumber;

    while (
      !int.TryParse(input, out enemyNumber)
      || (enemyNumber - 1) >= activeCharacters.Count
      || (enemyNumber - 1) < -1
    )
    {
      Reporter.Report("Come again?");
      input = await Task.Run(() => ReadLine()!.Trim());
    }

    caller.Attack(activeCharacters[enemyNumber - 1]);
  }
}
