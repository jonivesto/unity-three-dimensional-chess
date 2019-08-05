using System;

public static class Logic
{
    static char[] ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static char XIndexChar(int i)
    {
        return char.ToLower(ALPHA[i]);
    }

    public static char YIndexChar(int i)
    {
        return ALPHA[i];
    }

    public static string ZIndexChar(int i)
    {
        return (i + 1).ToString();
    }
}
