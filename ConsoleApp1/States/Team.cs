namespace States;

public class Team
{
  public string Name { get; }

  public static Team GoodGuys => new("Heroes");
  public static Team BadGuys => new("Enemies");

  public Team(string name)
  {
    Name = name;
  }
}