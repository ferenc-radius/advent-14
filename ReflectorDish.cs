namespace advent_14;

public class ReflectorDish(byte[,] dish)
{
    public void TillLever()
    {
        SlideRocksNorth();
    }

    public void SpinCycle()
    {
        for (var i = 0; i < 4; i++)
        {
            SlideRocksNorth();
            RotateDish();
        }
    }

    public int GetNorthLoad()
    {
        var totalLoad = 0;
        var rows = dish.GetLength(0);
        for (var i = 0; i < dish.GetLength(0); i++)
        {
            var load = (rows - i);
            for (var j = 0; j < dish.GetLength(1); j++)
            {
                if (dish[i, j] == Mirror.RoundRock)
                {
                    totalLoad += load;
                }
            }
        }

        return totalLoad;
    }

    public int MultipleSpinCycles(int cycles)
    {
        // There is a repeated pattern here, we assume that can be found in 300 iterations. 
        var results = new List<int>();
        for (var i = 0; i < 300; i++)
        {
            SpinCycle();
            var load = GetNorthLoad();
            results.Add(load);
        }

        // Assumes the last number only occurs once in the cycle
        int cycleLength = 0;
        for (var i = results.Count - 2; i >= 0; i--)
        {
            if (results[i] == results[^1])
            {
                cycleLength = results.Count - 1 - i;
                break;
            }
        }

        // get the value by getting the remainder which then should be the iteration asked for.
        var rem = cycles % cycleLength;
        var loadAfterCycles = 0;
        for (var i = results.Count - 2; i >= 0; i--)
        {
            if (i % cycleLength == rem)
            {
                loadAfterCycles = results[i-1];
                break;
            }
        }
        
        return loadAfterCycles;
    }

    private void RotateDish()
    {
        // rotate in place clock wise
        var n = dish.GetLength(0);
        for (var i = 0; i < n / 2; i++)
        {
            for (var j = i; j < n - i - 1; j++)
            {
                var temp = dish[i, j];
                dish[i, j] = dish[n - j - 1, i];
                dish[n - j - 1, i] = dish[n - i - 1, n - j - 1];
                dish[n - i - 1, n - j - 1] = dish[j, n - i - 1];
                dish[j, n - i - 1] = temp;
            }
        }
    }

    private void SlideRocksNorth()
    {
        bool hasMoved;
        do
        {
            hasMoved = false;
            for (var rowIndex = 1; rowIndex < dish.GetLength(0); rowIndex++)
            {
                for (var colIndex = 0; colIndex < dish.GetLength(1); colIndex++)
                {
                    // move round rock north if spot is available
                    if (dish[rowIndex, colIndex] == Mirror.RoundRock && dish[rowIndex - 1, colIndex] == Mirror.Empty)
                    {
                        dish[rowIndex - 1, colIndex] = Mirror.RoundRock;
                        dish[rowIndex, colIndex] = Mirror.Empty;
                        hasMoved = true;
                    }
                }
            }
        } while (hasMoved);
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