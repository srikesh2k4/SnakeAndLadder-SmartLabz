namespace SnakeAndLadder.uc;

public class DiceRoll
{
    public static int DiceValue()
    {
        Random random = new Random();
        int diceValue = random.Next(1,7);
        return diceValue;
    }
}