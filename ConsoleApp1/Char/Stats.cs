using Static;

namespace Char;

public record Stats()
{
  public int Strength { get; set => field = RangeTool.LimitFrom1To100(value); } = 1;
  public int Magic { get; set => field = RangeTool.LimitFrom1To100(value); } = 1;
  public int Endurance { get; set => field = RangeTool.LimitFrom1To100(value); } = 1;
  public int Agility { get; set => field = RangeTool.LimitFrom1To100(value); } = 1;
  public int Luck { get; set => field = RangeTool.LimitFrom1To100(value); } = 1;

  public Stats(int strength, int magic, int endurance, int agility, int luck) : this()
  {
    Strength = strength;
    Magic = magic;
    Endurance = endurance;
    Agility = agility;
    Luck = luck;
  }
}