using Char;

namespace Static;

public static class RangeTool
{
  public static int LimitFrom0To100(int value)
  {
    return (
      value <= 0
      ? 0
      : value >= 100
      ? 100
      : value
    );
  }
  public static float LimitFrom0To100(float value)
  {
    return (
      value <= 0
      ? 0
      : value >= 100
      ? 100
      : value
    );
  }
  public static int LimitFrom1To100(int value)
  {
    return (
      value <= 1
      ? 1
      : value >= 100
      ? 100
      : value
    );
  }
  public static float LimitFrom1To100(float value)
  {
    return (
      value <= 1
      ? 1
      : value >= 100
      ? 100
      : value
    );
  }
  public static int LimitValueFromTo(int value, int from, int to)
  {
    return (
      value <= from
      ? from
      : value >= to
      ? to
      : value
    );
  }
  public static int LimitValueFrom0To(int value, int to)
  {
    return (
      value <= 0
      ? 0
      : value >= to
      ? to
      : value
    );
  }
  public static int LimitFrom1(int value)
  {
    return (
      value <= 1
      ? 1
      : value
    );
  }
  public static float LimitFrom1(float value)
  {
    return (
      value <= 1
      ? 1
      : value
    );
  }

  public static bool ValidAttackInput(string input, List<Character> activeCharacters, out int enemyNumber)
  {
    bool validAttackInput = (
      int.TryParse(input, out int index)
      && (index - 1) < activeCharacters.Count
      && (index - 1) >= -1
    );

    enemyNumber = index - 1;

    return validAttackInput;
  }
}