namespace SnakeAndLadder.uc;

public class PlayerWorking
{
    public PlayerWorking()
    {
        int diceRollCount = 0;
        Dictionary<int, int> playersPosition = new Dictionary<int, int>()
        {
            { 1, 0 },
            { 2, 0 }
        };
        bool switchingPlayer = true;

        while (playersPosition[1] != 100 && playersPosition[2] != 100)
        {
            // ---------------- Player 1 Turn ----------------
            if (switchingPlayer)
            {
                int diceValue = DiceRoll.DiceValue();
                diceRollCount++;
                Console.WriteLine($"Player 1 at position {playersPosition[1]} ");
                Console.Write($" Dice roll at position 0 {diceValue} ");

                if (diceValue is not 1 or 6)
                    switchingPlayer = false;

                if (diceValue == 1 || diceValue == 6)
                {
                    Console.WriteLine("\nStarted Playing Player 1");
                    while (playersPosition[1] != 100)
                    {
                        int diceValueAfterStarted = DiceRoll.DiceValue();
                        diceRollCount++;
                        Console.Write($" Throws Again Dice {diceValueAfterStarted} ");
                        int temp = playersPosition[1];
                        int temp2 = playersPosition[2];

                        playersPosition[1] += diceValueAfterStarted;
                        if (playersPosition[1] > 100)
                        {
                            playersPosition[1] = temp;
                            Console.WriteLine($"Player 1 position is {playersPosition[1]}");
                            continue;
                        }

                        if (playersPosition[2] > 100)
                        {
                            playersPosition[2] = temp2;
                            Console.WriteLine($"Player 2 position is {playersPosition[2]}");
                            continue;
                        }

                        if (SnakeAndLadder.snakes.TryGetValue(playersPosition[1], out int backPositionOfSnake))
                        {
                            Console.WriteLine($"You got snake at {playersPosition[1]}");
                            playersPosition[1] = backPositionOfSnake;
                        }

                        if (SnakeAndLadder.ladder.TryGetValue(playersPosition[1], out int frontPositionOfLadder))
                        {
                            Console.WriteLine($"You got ladder at {playersPosition[1]}");
                            playersPosition[1] = frontPositionOfLadder;
                        }

                        Console.WriteLine($"Player 1 position is {playersPosition[1]}");

                        if (playersPosition[1] != 100)
                            switchingPlayer = false;

                        if (playersPosition[1] == 100 || playersPosition[2] == 100)
                        {
                            if (playersPosition[1] == 100)
                                Console.WriteLine("Player 1 won");
                            else
                                Console.WriteLine("Player 2 won");

                            Console.WriteLine($"Total Number of dice thrown => {diceRollCount}");
                            break;
                        }
                    }
                }
            }

            // ---------------- Player 2 Turn ----------------
            else if (!switchingPlayer)
            {
                int diceValue = DiceRoll.DiceValue();
                diceRollCount++;
                Console.WriteLine($"Player 2 at position {playersPosition[2]} ");
                Console.Write($" Dice roll at position 0 {diceValue} ");

                if (diceValue is not 1 or 6)
                    switchingPlayer = true;

                if (diceValue == 1 || diceValue == 6)
                {
                    Console.WriteLine("\nStarted Playing Player 2");
                    while (playersPosition[2] != 100)
                    {
                        int diceValueAfterStarted = DiceRoll.DiceValue();
                        diceRollCount++;
                        Console.Write($" Throws Again Dice {diceValueAfterStarted} ");
                        int temp2 = playersPosition[2];
                        playersPosition[2] += diceValueAfterStarted;

                        if (playersPosition[2] > 100)
                        {
                            playersPosition[2] = temp2;
                            Console.WriteLine($"Player 2 position is {playersPosition[2]}");
                            continue;
                        }

                        if (SnakeAndLadder.snakes.TryGetValue(playersPosition[2], out int backPositionOfSnake))
                        {
                            Console.WriteLine($"You got snake at {playersPosition[2]}");
                            playersPosition[2] = backPositionOfSnake;
                        }

                        if (SnakeAndLadder.ladder.TryGetValue(playersPosition[2], out int frontPositionOfLadder))
                        {
                            Console.WriteLine($"You got ladder at {playersPosition[2]}");
                            playersPosition[2] = frontPositionOfLadder;
                        }

                        Console.WriteLine($"Player 2 position is {playersPosition[2]}");

                        if (playersPosition[2] != 100)
                            switchingPlayer = true;

                        if (playersPosition[1] == 100 || playersPosition[2] == 100)
                        {
                            if (playersPosition[1] == 100)
                                Console.WriteLine("Player 1 won");
                            else
                                Console.WriteLine("Player 2 won");

                            Console.WriteLine($"Total Number of dice thrown => {diceRollCount}");
                            break;
                        }
                    }
                }
            }
        }
    }
}
