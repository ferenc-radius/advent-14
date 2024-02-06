namespace advent_14;

public class DishParser
{
    /**
     * Converts a dish into a matrix of mirrors
     *  
     * 
     */
    public static byte[,] Parse(string inputFile)
    {
        var lines = File.ReadAllLines(inputFile);
        if (lines.Length == 0)
        {
            throw new InvalidOperationException("No lines found in dish file");
        }
        
        var rowCount = lines.Length;
        var colCount = lines[0].Length;
        var dish = new byte[rowCount, colCount];

        foreach (var (line, rowIndex) in lines.Select((value, i) => (value, i)))
        {
            var mirrors = line.ToCharArray().Select(Mirror.GetMirrorType).ToArray();
            if (mirrors.Length != colCount)
            {
                throw new InvalidOperationException("Lines should have the same length");
            }

            for (var colIndex = 0; colIndex < mirrors.Length; colIndex++)
            {
                dish[rowIndex, colIndex] = mirrors[colIndex];
            }
        }

        return dish;
    }
}