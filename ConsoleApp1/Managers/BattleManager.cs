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
    await StartPhase();
  }
  
  private async Task StartPhase()
  {
    bool done = false;

    while (!done)
      done = await ExecuteTurns();

    EndBattle();
  }
  private async Task<bool> ExecuteTurns()
  {
    foreach (Character character in ActiveCharacters)
    {
      await character.ActionManager.ExecuteTurn(ActiveCharacters);
      
      RemoveDead();

      if (BattleIsOver())
        return true;
    }

    return false;
  }
  public void EndBattle()
  {
    Team winner = (
      CountGoodGuys() > 0
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
  private bool BattleIsOver()
  {
    return (
      CountGoodGuys() == 0
      || CountBadGuys() == 0
    );
  }
  
  private int CountGoodGuys()
  {
    return ActiveCharacters.Count(c => c.Team.Equals(Team.GoodGuys));
  }
  private int CountBadGuys()
  {
    return ActiveCharacters.Count(c => c.Team.Equals(Team.BadGuys));
  }
}
