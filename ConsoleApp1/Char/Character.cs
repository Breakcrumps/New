using Equip;
using Managers;
using States;
using Static;

namespace Char;

public class Character : IEquatable<Character>
{
  public required string Name { get; set; } = "NoName";
  public required Team Team { get; set; }
  
  public Stats Stats { get; set; }

  public int Health { get; set => field = RangeTool.LimitValueFrom0To(value, ComputeMaxHealth()); }

  public Weapon Weapon { get; set; } = Weapons.BareHand();
  public Armour Armour { get; set; } = Armoury.RaggedCloth();

  public ActionManager ActionManager { get; init; }
  
  public async Task Attack(Character enemy) => await Weapon.Attack(this, enemy);

  private int ComputeMaxHealth() => (int)Math.Round(3.3 * Stats.Endurance + 10);
  public int ComputeDefence() => (int)Math.Round(-52 * Math.Cos(.017 * Stats.Endurance) + 52);
  public int ComputePower() => (int)Math.Round(-35 * Math.Cos((.02 * Stats.Strength) + (Math.PI / 6)) + 30.31);

  public override bool Equals(object? obj) => Equals(obj as Character);
  public bool Equals(Character? other) => Name == other!.Name;

  public static bool operator ==(Character? left, Character? right) => left!.Equals(right);
  public static bool operator !=(Character? left, Character? right) => !left!.Equals(right);

  public override int GetHashCode() => Name.GetHashCode();

  /// <summary>
  /// Construct an NPC.
  /// </summary>
  /// <param name="stats"></param>
  public Character(Stats stats)
  {
    Stats = stats;
    Health = ComputeMaxHealth();
    ActionManager = new(this);
  }
}

public class Character<TurnManager> : Character
  where TurnManager : ITurnManager, new()
{
  /// <summary>
  /// Construct a Character with the type of controls given as a generic implementing ITurnManager.
  /// </summary>
  /// <param name="stats"></param>
  public Character(Stats stats) : base(stats)
  {
    ActionManager = new(this, new TurnManager());
  }
}