using Char;

namespace Managers;

public class ActionManager
{
  private readonly ITurnManager _turnManager = new NPCTurnManager();
  private readonly Character _character;

  public async Task ExecuteTurn()
  {
    await _turnManager.ExecuteTurn(_character);
  }

  public ActionManager(Character character)
  {
    _character = character;
  }
  public ActionManager(Character character, ITurnManager turnManager)
  {
    _character = character;
    _turnManager = turnManager;
  }
}