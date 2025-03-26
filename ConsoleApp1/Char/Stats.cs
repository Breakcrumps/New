using Static;

namespace Char;

public record Stats
{
  public required int Health
  {
    get;
    set => field = RangeTool.LimitFrom1(value);
  }
  public required float Agility { get; set; } = 1;
}