using Char;

namespace Managers;

public struct NPCTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character character)
  {
    await Task.Delay(1000);
  }
}