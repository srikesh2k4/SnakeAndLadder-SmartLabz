namespace SnakeAndLadder.uc;

public class PlayerWorking
{
    public PlayerWorking()
    {
        int diceRollCount = 0;
        Dictionary<int, int> playersPosition = new Dictionary<int, int>()
        {
            { 1, 0 }
        };
        while (  playersPosition[1] != 100)
        {
            int diceValue = DiceRoll.DiceValue();
            diceRollCount++;
            Console.WriteLine($"Player at position {playersPosition[1]} ");
            Console.Write($" Dice roll at position 0 {diceValue} ");
            if (diceValue == 1 || diceValue == 6)
            {
                Console.WriteLine();
                Console.WriteLine("Started Playing Player 1");
                while (playersPosition[1] != 100)
                {
                    int diceValueAfterStarted = DiceRoll.DiceValue();
                    diceRollCount++;
                    Console.Write($" Throws Again Dice {diceValueAfterStarted} ");
                    int temp = playersPosition[1];
                    playersPosition[1] += diceValueAfterStarted;
                    if (playersPosition[1] > 100)
                    {
                        playersPosition[1] = temp;
                        Console.WriteLine($"Player position is {playersPosition[1]}");
                        continue;
                    }
                    
                    if (SnakeAndLadder.snakes.TryGetValue(playersPosition[1],out int backPositionOfSnake))
                    {
                        Console.WriteLine($"You got snake at {playersPosition[1]}");
                        playersPosition[1] = backPositionOfSnake;
                        
                    }

                    if (SnakeAndLadder.ladder.TryGetValue(playersPosition[1],out int frontPositionOfLadder))
                    {
                        Console.WriteLine($"You got ladder at {playersPosition[1]}");
                        playersPosition[1] = frontPositionOfLadder;
                    }
                    Console.WriteLine($"Player position is {playersPosition[1]}");
                    //winning condition
                    if (playersPosition[1] == 100)
                    {
                        Console.WriteLine("Player won");
                        Console.WriteLine($"Total Number of dice throwed => {diceRollCount}");
                        break;
                    }
                }
            }
        }

    }
}