using Equip;
using Managers;
using States;
using Static;

namespace Char;

public class Character : IEquatable<Character>
{
  public required string Name { get; set; } = "NoName";
  public required Team Team { get; set; }
  public required int BaseHealth { get; init => field = RangeTool.LimitFrom1(value); }
  public required int BaseDefence { get; set => field = RangeTool.LimitFrom1To100(value); }
  public int Health { get; set => field = RangeTool.LimitValueFrom0To(value, Stats.Endurance); }

  public Stats Stats { get; set; }

  public Weapon Weapon { get; set; } = Weapons.BareHand();
  public Armour Armour { get; set; } = Armoury.RaggedCloth();

  public ActionManager ActionManager { get; init; }
  
  public async Task Attack(Character enemy) => await Weapon.Attack(this, enemy);

  public override bool Equals(object? obj)
  {
    return Equals(obj as Character);
  }
  public bool Equals(Character? other)
  {
    return Name == other!.Name;
  }

  public static bool operator ==(Character? left, Character? right)
  {
    return left!.Equals(right);
  }
  public static bool operator !=(Character? left, Character? right)
  {
    return !left!.Equals(right);
  }

  public override int GetHashCode() => Name.GetHashCode();

  /// <summary>
  /// Construct an NPC.
  /// </summary>
  /// <param name="stats"></param>
  public Character(Stats stats)
  {
    Stats = stats;
    Health = Stats.Endurance;
    ActionManager = new(this);
  }
}

public class Character<TurnManager> : Character
  where TurnManager : ITurnManager, new()
{
  /// <summary>
  /// Construct a Character the type of controls given as a generic implementing ITurnManager.
  /// </summary>
  /// <param name="stats"></param>
  public Character(Stats stats) : base(stats)
  {
    ActionManager = new(this, new TurnManager());
  }
}