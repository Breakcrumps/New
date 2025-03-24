namespace Char;

public record Stats
{
  public required int Health
  {
    get;
    set {
      field =
        value <= 0
        ? 0
        : value >= 100
        ? 100
        : value;
    }
  }
  public required float Agility { get; set; } = 1;
}