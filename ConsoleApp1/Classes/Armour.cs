namespace Classes;

public class Armour
{
  public required string Name { get; init; } = "";
  public required int ArmourValue
  {
    get;
    init {
      if (value < 0)
        field = 0;
      else if (value > 100)
        field = 100;
      field = value;
    }
  }
}