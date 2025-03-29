namespace States;

public class Team(string name) : IEquatable<Team>
{
  public string Name => name;

  public static Team GoodGuys() => new("Heroes");
  public static Team BadGuys() => new("Enemies");

  public bool Equals(Team? other)
  {
    return Name == other!.Name;
  }
  public override bool Equals(object? obj)
  {
    return Equals(obj as Team);
  }

  public static bool operator ==(Team? left, Team? right)
  {
    return left!.Equals(right);
  }
  public static bool operator !=(Team? left, Team? right)
  {
    return !left!.Equals(right);
  }

  public override int GetHashCode() => Name.GetHashCode();
}