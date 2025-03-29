using Static;

namespace Equip;

public class Armour
{
  public required string Name { get; init; } = "";
  public required int ArmourValue { get; init => field = RangeTool.LimitFrom0To100(value); }
}