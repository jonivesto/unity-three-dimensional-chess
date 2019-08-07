using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Color
{
    White,
    Black,
    Gray // Neutral, used by free to captures
}

public class Piece
{
    public Color color;
    public GameObject instance;

    public virtual List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        Debug.LogError("GetMoves() does not exist for " + GetType().ToString());
        return null;
    }
}
