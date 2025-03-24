using Char;
using States;

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
    if (character.Team.Equals(Team.BadGuys))
      _turnManager = new NPCTurnManager();
    else
      _turnManager = new PlayableTurnManager();
  }
}