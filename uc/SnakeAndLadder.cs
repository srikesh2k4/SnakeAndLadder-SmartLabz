namespace SnakeAndLadder.uc;

public class SnakeAndLadder
{
    public static Dictionary<int, int> snakes = new Dictionary<int, int>()
    {
        { 45, 7 },
        { 38, 20 },
        { 97, 61 },
        { 91, 73 },
        { 51, 10 },
        { 65, 54 }

    };
    public static Dictionary<int, int> ladder = new Dictionary<int, int>()
    {
        { 5, 58 },
        { 14, 49 },
        { 53, 72 },
        { 75, 94 },
        { 42, 60 },
        { 64, 83 }
    };
    public static void BoardCreate()
    {
        //creating a board
        int[,] board = new int[10, 10];
        int count = 1;
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = count;
                count++;
            }
        }

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i, j] + " ");

            }

            Console.WriteLine();
        }

        //creating ladder and snake


    }
}