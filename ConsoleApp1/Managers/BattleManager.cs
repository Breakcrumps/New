using Char;
using Static;
using States;

namespace Managers;

public class BattleManager
{
  public List<Character> ActiveCharacters
  {
    get;
    set => field = [.. value.OrderByDescending(node => node.Stats.Agility)];
  } = [];

  public async Task CommenceBattle(params List<Character> combatants)
  {
    ActiveCharacters = combatants;

    DebugReporter.ReportBattleStart(ActiveCharacters);

    await ExecuteBattle();

    EndBattle();
  }
  
  private async Task ExecuteBattle()
  {
    bool done = false;

    while (!done)
      done = await ExecutePhase();
  }
  private async Task<bool> ExecutePhase()
  {
    foreach (var character in ActiveCharacters)
    {
      await character.ActionManager.ExecuteTurn(ActiveCharacters);
      
      RemoveDead();

      if (BattleIsOver)
      {
        Reporter.Report($"\nThe battle is over!");
        Reporter.Report($"\n\tThe number of enemies is {BadGuysCount},\n\tAnd the number of heroes is {GoodGuysCount}");
        return true;
      }
    }

    return false;
  }
  public void EndBattle()
  {
    Team winner = (
      GoodGuysCount > 0
      ? Team.GoodGuys
      : Team.BadGuys
    );

    Reporter.ReportResults(winner);

    ActiveCharacters = [];
  }

  private void RemoveDead()
  {
    ActiveCharacters.RemoveAll(c => c.Health == 0);
  }
  private bool BattleIsOver => GoodGuysCount == 0 || BadGuysCount == 0;
  
  private int GoodGuysCount => ActiveCharacters.Count(c => c.Team == Team.GoodGuys);
  private int BadGuysCount => ActiveCharacters.Count(c => c.Team == Team.BadGuys);
}
