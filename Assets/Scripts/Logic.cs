
using System;
using System.Collections.Generic;
using UnityEngine;

public static class Logic
{
    private static char[] Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static Color PlayerTurn = Color.White;

    public static Piece WhiteKing, BlackKing;

    public static Piece SelectedPiece = null;

    public static int[] SelectedPiecePosition = null;

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

    public static bool Check(Color player, Board board)
    {
        Piece king = BlackKing;
        Color enemies = Color.White;

        if (player == Color.White)
        {
            king = WhiteKing;
            enemies = Color.Black;
        }

        foreach (Piece piece in board.positions)
        {
            if (piece!=null&&piece.color == enemies)
            {
                int[] enemyPos = piece.GetPosition();
                int[] kingPos = king.GetPosition();

                piece.GetMoves(enemyPos[0], enemyPos[1], enemyPos[2], board);
                if (piece.ContainsMove(kingPos[0], kingPos[1], kingPos[2]))
                {
                    return true;
                }
            }
        }

        return false;
    }


    public static void EndTurn(Board board)
    {       
        // Change turn
        if (PlayerTurn == Color.Black)
        {
            PlayerTurn = Color.White;
        }
        else
        {
            PlayerTurn = Color.Black;
        }

        // Notify if check
        if (Check(PlayerTurn, board))
        {
            Debug.Log("Check!");
        }

        Debug.Log(PlayerTurn.ToString() + "'s turn.");
    }


}
