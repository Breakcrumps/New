using Char;
using Static;
using States;

namespace Managers;

public static class BattleManager
{
  public static List<Character> ActiveCharacters
  {
    get;
    set => field = [.. value.OrderByDescending(node => node.Stats.Agility)];
  } = [];

  public static async Task CommenceBattle(params List<Character> combatants)
  {
    Reporter.Clear();

    ActiveCharacters = combatants;

    await Reporter.ReportBattleStart();

    await ExecuteBattle();

    EndBattle();
  }
  
  private static async Task ExecuteBattle()
  {
    bool done = false;

    while (!done)
    {
      done = await ExecutePhase();
    }
  }
  private static async Task<bool> ExecutePhase()
  {
    foreach (var character in ActiveCharacters)
    {
      await character.ActionManager.ExecuteTurn(ActiveCharacters);
      
      RemoveDead();

      if (IsBattleOver())
        return true;
    }

    return false;
  }
  private static void EndBattle()
  {
    Reporter.ReportResults(DetermineWinner());

    ActiveCharacters = [];
  }

  private static void RemoveDead()
  {
    ReportTerminations();
    ActiveCharacters.RemoveAll(c => c.Health == 0);
  }
  private static void ReportTerminations()
  {
    foreach (var character in ActiveCharacters)
    {
      if (character.Health == 0)
      {
        Reporter.ReportTermination(character);
      }
    }
  }

  private static bool IsBattleOver() => CountGoodGuys() == 0 || CountBadGuys() == 0;
  
  private static int CountGoodGuys() => ActiveCharacters.Count(c => c.Team == Team.GoodGuys());
  private static int CountBadGuys() => ActiveCharacters.Count(c => c.Team == Team.BadGuys());
  private static Team DetermineWinner() => CountGoodGuys() > 0 ? Team.GoodGuys() : Team.BadGuys();
}
