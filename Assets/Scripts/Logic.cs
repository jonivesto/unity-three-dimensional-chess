
using UnityEngine;

public static class Logic
{
    private static char[] Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static Color PlayerTurn = Color.White;

    public static Piece SelectedPiece = null;

    public static char XIndexChar(int i)
    {
        return char.ToLower(Alpha[i]);
    }

    public static char YIndexChar(int i)
    {
        return Alpha[i];
    }

    public static string ZIndexChar(int i)
    {
        return (i + 1).ToString();
    }

    public static string Markup(int x, int y, int z)
    {
        return YIndexChar(x) + "" + XIndexChar(y) + "" + ZIndexChar(z);
    }

    public static void FindCheck()
    {

    }

    public static void FindCheckMate()
    {

    }

    public static void EndTurn()
    {
        if (PlayerTurn == Color.Black)
        {
            PlayerTurn = Color.White;
        }
        else
        {
            PlayerTurn = Color.Black;
        }

        Debug.Log(PlayerTurn.ToString() + "'s turn.");

    }
}
