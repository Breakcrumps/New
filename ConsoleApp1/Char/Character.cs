using Equip;
using Managers;
using States;
using Static;

namespace Char;

public class Character : IEquatable<Character>
{
  public required string Name { get; set; } = "NoName";
  public required Team Team { get; set; }
  public int Health
  {
    get;
    set => field = RangeTool.LimitValueFrom0To(value, Stats.Health);
  }

  public Stats Stats { get; set; }

  public Weapon Weapon { get; set; } = new() { Name = "Bare hands", Damage = 3 };
  public Armour Armour { get; set; } = new() { Name = "Ragged cloth", ArmourValue = 2 };

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
    Health = Stats.Health;
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
  /// <param name="turnManager"></param>
  public Character(Stats stats) : base(stats)
  {
    ActionManager = new(this, new TurnManager());
  }
}