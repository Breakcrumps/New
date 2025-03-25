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
    Reporter.Clear();

    ActiveCharacters = combatants;

    await Reporter.ReportBattleStart();

    await ExecuteBattle();

    EndBattle();
  }
  
  private async Task ExecuteBattle()
  {
    bool done = false;

    while (!done)
    {
      done = await ExecutePhase();
    }
  }
  private async Task<bool> ExecutePhase()
  {
    foreach (var character in ActiveCharacters)
    {
      await character.ActionManager.ExecuteTurn(ActiveCharacters);
      
      RemoveDead();

      if (BattleIsOver)
        return true;
    }

    return false;
  }
  private void EndBattle()
  {
    Reporter.ReportResults(Winner);

    ActiveCharacters = [];
  }

  private void RemoveDead()
  {
    foreach (var character in ActiveCharacters)
    {
      if (character.Health == 0)
      {
        Reporter.ReportTermination(character);
      }
    }
  }
  private bool BattleIsOver => GoodGuysCount == 0 || BadGuysCount == 0;
  
  private int GoodGuysCount => ActiveCharacters.Count(c => c.Team == Team.GoodGuys);
  private int BadGuysCount => ActiveCharacters.Count(c => c.Team == Team.BadGuys);
  private Team Winner => GoodGuysCount > 0 ? Team.GoodGuys : Team.BadGuys;
}
