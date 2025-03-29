using Char;

namespace Managers;

public class ActionManager
{
  private readonly Character _character;
  public ITurnManager TurnManager { get; set; }
  public bool Shielding { get; set; }

  public async Task ExecuteTurn(List<Character> ActiveCharacters) => await TurnManager.ExecuteTurn(_character, ActiveCharacters);

  public ActionManager(Character character)
  {
    _character = character;
    TurnManager = new NPCTurnManager();
  }
  public ActionManager(Character character, ITurnManager turnManager)
  {
    _character = character;
    TurnManager = turnManager;
  }
}