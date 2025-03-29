namespace Equip;

public static class Weapons
{
  public static Weapon BareHand() => new() { Name = "Bare Hands", Damage = 3 };
  public static Weapon SturdyBlade() => new() { Name = "Sturdy Blade", Damage = 12 };
  public static Weapon PhoenixAsh() => new() { Name = "Phoenix' Ash", Damage = 68 };
}