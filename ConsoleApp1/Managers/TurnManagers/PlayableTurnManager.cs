using Char;
using Static;

namespace Managers;

public readonly struct PlayableTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character caller, List<Character> activeCharacters)
  {
    UpdateStates(caller);

    bool done = false;

    while (!done)
    {
      Reporter.Report("Characters on the battlefield:");
      
      Reporter.ReportActiveCharacters(caller, activeCharacters);
    
      Reporter.PresentTurnOptions();

      string directive = GetNextDirective();

      if (directive == "Attack")
      {
        done = await Attack(caller, activeCharacters);
      }
      if (directive == "Shield")
      {
        Reporter.Clear();
        caller.ActionManager.Blocking = true;
        done = true;
      }
      if (directive == "Wait")
      {
        Reporter.Clear();
        done = true;
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

    while (!RangeTool.ValidAttackInput(input, activeCharacters, out enemyIndex))
    {
      Reporter.ComeAgain();
      input = Reporter.Read();
    }

    if (enemyIndex == -1)
    {
      Reporter.Clear();
      return false;
    }

    Character target = activeCharacters[enemyIndex];

    if (target == caller)
    {
      Reporter.Clear();
      Reporter.Report("Can't hit yourself!");
      return false;
    }
    if (target.Team == caller.Team)
    {
      Reporter.Clear();
      Reporter.Report("Please don't try to hit your friends.");
      return false;
    }

    Reporter.Clear();
    await caller.Attack(target);
    return true;
  }

  private bool InputIsDirective(string input) => Reporter.PlayerTurnOptions.Any(kvp => kvp.Value.Contains(input));
  private string GetDirective(string input) => Reporter.PlayerTurnOptions.FirstOrDefault(kvp => kvp.Value.Contains(input)).Key;

  private void UpdateStates(Character caller)
  {
    caller.ActionManager.Blocking = false;
  }
}
