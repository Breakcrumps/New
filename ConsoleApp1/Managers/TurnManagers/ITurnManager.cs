using Char;

namespace Managers;

public interface ITurnManager
{
  public Task ExecuteTurn(Character character);
}