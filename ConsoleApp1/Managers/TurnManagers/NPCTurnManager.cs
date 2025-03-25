using Char;

namespace Managers;

public struct NPCTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character character, List<Character> activeCharacters)
  {
    Character nextTarget = activeCharacters.MinBy(c => c.Health)!;
    await Task.Run(() => character.Attack(nextTarget));
  }
}