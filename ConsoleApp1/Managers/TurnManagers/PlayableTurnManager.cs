using Char;

namespace Managers;

public struct PlayableTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character character, List<Character> activeCharacters)
  {
    foreach (Character activeCharacter in activeCharacters)
    {
      WriteLine($"{activeCharacter.Health}");
    }

    await Task.Delay(1_000);
  }
}
