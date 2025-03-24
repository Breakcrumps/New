namespace Classes;

public class TurnManager
{
  public List<Character> ActiveCharacters
  {
    get;
    set => field = [.. value.OrderByDescending(node => node.Stats.Agility)];
  } = [];

  public async Task StartPhase()
  {
    await ExecuteTurns();
  }
  private async Task ExecuteTurns()
  {
    foreach (Character character in ActiveCharacters)
    {
      await character.ActionManager.ExecuteTurn();
    }
  }
}
