using Char;

namespace Managers;

public class ActionManager
{
  private readonly ITurnManager _turnManager;
  private readonly Character _character;

  public async Task ExecuteTurn(List<Character> ActiveCharacters)
  {
    await _turnManager.ExecuteTurn(_character, ActiveCharacters);
  }

  public ActionManager(Character character)
  {
    _character = character;
    _turnManager = new NPCTurnManager();
  }
  public ActionManager(Character character, ITurnManager turnManager)
  {
    _character = character;
    _turnManager = turnManager;
  }
}