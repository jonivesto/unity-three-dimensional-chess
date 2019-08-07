using System.Collections;
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

    // Return list of moves for this type of piece.
    // NOTE: This does not handle check situations!
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
            return true;
        }

        return false;
    }
}
