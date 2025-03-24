namespace Classes;

public class TurnManager
{
  public List<Character> ActiveCharacters
  {
    get;
    set => field = [.. value.OrderBy(node => node.Stats.Agility)];
  } = [];
}