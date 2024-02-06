namespace advent_14;

public class ReflectorDish(byte[,] dish)
{
    public void TillLever()
    {
        for (var colIndex = 0; colIndex < dish.GetLength(1); colIndex++)
        {
            bool moveUp;
            do
            {
                // keep moving the round rocks up till no move is left.
                moveUp = MoveUp(colIndex);
            } 
            while (moveUp);
        }
        
    }

    /**
     * Returns true if any round rocks are moved.
     */
    private bool MoveUp(int col)
    {
        var moves = 0;
        var colValues = Enumerable.Range(0, dish.GetLength(0)).Select(x => dish[x, col]).ToArray();

        for (var i = 1; i < colValues.Length; i++)
        {
            // move round rock north if spot is available.
            if (colValues[i] == Mirror.RoundRock && colValues[i-1] == Mirror.Empty)
            {
                dish[i - 1, col] = Mirror.RoundRock;
                dish[i, col] = Mirror.Empty;
                moves++;
            }
        }

        return moves > 0;
    }

    public int GetNorthLoad()
    {
        var totalLoad = 0;
        var load = dish.GetLength(0);
        for (var i = 0; i < dish.GetLength(0); i++)
        {
            for (var j = 0; j < dish.GetLength(1); j++)
            {
                if (dish[i, j] == Mirror.RoundRock)
                {
                    totalLoad += (load - i);
                }
            }
        }

        return totalLoad;
    }

    public void Print()
    {
        var rows = dish.GetLength(0);
        var cols = dish.GetLength(1);
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                Console.Write(Mirror.ToChar(dish[i, j]));
            }
            Console.WriteLine();
        }
    }
}