using Equip;
using Managers;
using States;

namespace Char;

public class Character
{
  public required string Name { get; set; } = "";
  public required Team Team { get; set; }
  public int Health
  {
    get;
    set {
      field =
        value <= 0
        ? 0
        : value >= Stats.Health
        ? Stats.Health
        : value;
    }
  }

  public Stats Stats { get; set; }

  public Weapon Weapon { get; set; } = new() { Name = "Bare hands", Damage = 3 };
  public Armour Armour { get; set; } = new() { Name = "Ragged cloth", ArmourValue = 2 };

  public ActionManager ActionManager { get; init; }
  
  public void Attack(Character enemy) => Weapon.Attack(enemy);

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

  /// <summary>
  /// Construct a Character of given type.
  /// </summary>
  /// <param name="stats"></param>
  /// <param name="turnManager"></param>
  public Character(Stats stats, ITurnManager turnManager)
  {
    Stats = stats;
    Health = Stats.Health;
    ActionManager = new(this, turnManager);
  }
}