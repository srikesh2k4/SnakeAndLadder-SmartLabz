namespace SnakeAndLadder.uc;

public class PlayerWorking
{
    public PlayerWorking()
    {
        Dictionary<int, int> playersPosition = new Dictionary<int, int>()
        {
            { 1, 0 }
        };
        while (  playersPosition[1] != 100)
        {
            int diceValue = DiceRoll.DiceValue();
            Console.WriteLine(diceValue);
            if (diceValue == 1 || diceValue == 6)
            {
                Console.WriteLine(diceValue);
                Console.WriteLine("Won");
                break;
            }
        }

    }
}