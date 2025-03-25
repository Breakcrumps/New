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

      string directive = GetNextDirective();

      if (directive == "Attack")
      {
        done = await Attack(caller, activeCharacters);
      }
    }
  }
  private string GetNextDirective()
  {
    string? input = Reporter.Read();

    while (!InputIsDirective(input))
    {
      Reporter.Clear();
      Reporter.ComeAgain();
      Reporter.PresentTurnOptions();
      input = Reporter.Read();
    }

    string directive = GetDirective(input);

    return directive!;
  }

  private async Task<bool> Attack(Character caller, List<Character> activeCharacters)
  {
    Reporter.PresentAttackOptions(caller, activeCharacters);

    string input = Reporter.Read();
    int enemyIndex;

    while (!ValidAttackInput(input, out enemyIndex, activeCharacters))
    {
      Reporter.ComeAgain();
      input = Reporter.Read();
    }

    if (enemyIndex == -1)
      return false;

    Character target = activeCharacters[enemyIndex];

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

  private bool InputIsDirective(string input) => Reporter.PlayerTurnOptions.Any(kvp => kvp.Value.Contains(input));
  private string GetDirective(string input) => Reporter.PlayerTurnOptions.FirstOrDefault(kvp => kvp.Value.Contains(input)).Key;
  private bool ValidAttackInput(string input, out int enemyNumber, List<Character> activeCharacters)
  {
    bool result =  (
      int.TryParse(input, out int index)
      && (index - 1) < activeCharacters.Count
      && (index - 1) >= -1
    );

    enemyNumber = index - 1;

    return result;
  }
}
