using Char;

namespace Managers;

public struct PlayableTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character character)
  {
    await Task.Delay(1000);
  }
}
