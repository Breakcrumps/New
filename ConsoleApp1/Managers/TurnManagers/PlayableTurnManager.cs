using Char;
using Static;

namespace Managers;

public readonly struct PlayableTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character caller, List<Character> activeCharacters)
  {
    bool done = false;

    while (!done)
    {
      Reporter.ReportActiveCharacters(caller, activeCharacters);
    
      Reporter.PresentTurnOptions();

      string directive = await GetNextDirective();

      if (directive == "Attack")
      {
        done = await Attack(caller, activeCharacters);
      }
    }
  }
  private async Task<string> GetNextDirective()
  {
    string? input = await Task.Run(() => Console.ReadLine()!.Trim());

    while (!Reporter.PlayerTurnOptions.Any(kvp => kvp.Value.Contains(input)))
    {
      Reporter.Clear();
      Reporter.Report("Come again?");
      Reporter.PresentTurnOptions();
      input = await Task.Run(() => Console.ReadLine()!.Trim());
    }

    string directive = Reporter.PlayerTurnOptions.FirstOrDefault(kvp => kvp.Value.Contains(input)).Key;

    return directive!;
  }

  private async Task<bool> Attack(Character caller, List<Character> activeCharacters)
  {
    Reporter.Clear();
    Reporter.Report("Whom to attack?");
    Reporter.ReportActiveCharacters(caller, activeCharacters);
    Reporter.Report("\tPlease enter the enemy's number or 0 to return.");

    string input = await Task.Run(() => Console.ReadLine()!.Trim());
    int enemyNumber;

    while (
      !int.TryParse(input, out enemyNumber)
      || (enemyNumber - 1) >= activeCharacters.Count
      || (enemyNumber - 1) < -1
    )
    {
      Reporter.Report("Come again?");
      input = await Task.Run(() => Console.ReadLine()!.Trim());
    }

    enemyNumber--;

    if (enemyNumber == -1)
      return false;

    Character target = activeCharacters[enemyNumber];

    if (target == caller)
    {
      Reporter.Report("Can't hit yourself!");
      return false;
    }
    if (target.Team == caller.Team)
    {
      Reporter.Report("Please don't try to hit your friends.");
      return false;
    }

    await caller.Attack(target);
    return true;
  }
}
