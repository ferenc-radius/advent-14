namespace advent_14;

public record Mirror
{
    public const byte Empty = 0;
    public const byte CubeRock = 1;
    public const byte RoundRock = 2;
    
    public static byte GetMirrorType(char x)
    {
        return x switch
        {
            '.' => Empty,
            '#' => CubeRock,
            'O' => RoundRock,
            _ => Empty
        };
    }

    public static char ToChar(byte x)
    {
        return x switch
        {
            Empty => '.',
            CubeRock => '#',
            RoundRock => 'O',
            _ => 'O'
        };
    }
}