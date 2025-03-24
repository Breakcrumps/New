namespace Classes;

public class Armour
{
  public required string Name { get; init; } = "";
  public required int ArmourValue
  {
    get;
    init {
      field =
        value <= 0
        ? 1
        : value >= 100
        ? 100
        : value;
    }
  }
}