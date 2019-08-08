using System;
using System.Collections.Generic;
using UnityEngine;

public enum Color
{
    White,
    Black,
    Gray
}

public class Piece
{
    // Color / Team
    // Gray color means neutral location that is free to capture
    public Color color;

    // GameObject in the scene hieararchy
    public GameObject instance;

    // Return list of moves for this piece.
    public virtual List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        return null;
    }

    // Select piece if its player's turn
    // Returns bool value of success state
    public bool Select()
    {
        if(Logic.PlayerTurn == color)
        {
            Logic.SelectedPiece = this;
            Logic.SelectedPiecePosition = GetPosition();
            return true;
        }

        return false;
    }

    // Piece's coordinates on the board
    public int[] GetPosition()
    {
        if (instance == null) return null;

        int x = Mathf.FloorToInt(instance.transform.localPosition.x);
        int y = Convert.ToInt32(instance.transform.parent.name.Substring(5));
        int z = Mathf.FloorToInt(instance.transform.localPosition.z);

        return new int[] { x, y, z };
    }

}
