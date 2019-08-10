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

    // Position when this piece was last selected
    public int[] position;

    // Available moves when this piece was last selected
    public List<int[]> moves;

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

    public bool ContainsMove(int x, int y, int z)
    {
        if (moves == null) return false;

        foreach (int[] move in moves)
        {
            if (x == move[0] && y == move[1] && z == move[2]) return true;
        }

        return false;
    }

    // Piece's coordinates on the board
    public int[] GetPosition()
    {
        Board board = Logic.board;
        int x = 0, y = 0, z = 0;

        for (x = 0; x < board.boardSize; x++)
        {
            for (y = 0; y < board.boardSize; y++)
            {
                for (z = 0; z < board.boardSize; z++)
                {
                    if(board.GetPieceAt(x, y, z) == this)
                    {
                        position = new int[] { x, y, z };
                        return position;
                    }
                }
            }
        }

        Debug.LogError("Piece not found!");
        return null;
    }

}
