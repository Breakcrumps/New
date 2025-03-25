using Char;

namespace Managers;

public readonly struct NPCTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character character, List<Character> activeCharacters)
  {
    Character nextTarget = (
      activeCharacters
        .Where(c => c.Name != character.Name)
        .MinBy(c => c.Health)!
    );
    await character.Attack(nextTarget);
  }
}