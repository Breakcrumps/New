namespace Classes;

public class ActionManager
{
  private readonly ITurnManager _turnManager = new NPCTurnManager();

  public async Task ExecuteTurn()
  {
    await _turnManager.ExecuteTurn();
  }

  public ActionManager() { }
  public ActionManager(ITurnManager turnManager)
  {
    _turnManager = turnManager;
  }
}

public interface ITurnManager
{
  public Task ExecuteTurn();
}

public struct NPCTurnManager(Character _character) : ITurnManager
{
  public async Task ExecuteTurn()
  {
    await Task.Delay(1000);
  }
}

public struct PlayableTurnManager(Character _character) : ITurnManager
{
  public async Task ExecuteTurn()
  {
    await Task.Delay(1000);
  }
}
