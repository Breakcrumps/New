using Managers;

namespace Char;

public class PlayableCharacter : Character
{
  public PlayableCharacter(Stats stats) : base(stats)
  {
    ActionManager = new(this, new PlayableTurnManager());
  }
}