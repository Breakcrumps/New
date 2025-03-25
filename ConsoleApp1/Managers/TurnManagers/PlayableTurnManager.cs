using Char;
using Static;

namespace Managers;

public readonly struct PlayableTurnManager : ITurnManager
{
  public async Task ExecuteTurn(Character character, List<Character> activeCharacters)
  {
    DebugReporter.ReportPlayerTurnStart();
    
    Reporter.ReportActiveCharacters(character, activeCharacters);

    await Task.Run(ReadLine);
  }
}
