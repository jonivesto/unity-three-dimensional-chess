using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public Pawn(Color color)
    {
        this.color = color;
    }

    public override List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        List<int[]> moves = new List<int[]>();
        Piece current = board.GetPieceAt(x, y, z);
        Piece target;

        int dir = (current.color == Color.White) ? 1 : -1;

        // Forward
        target = board.GetPieceAt(x, y, z + dir);
        if (target != null && target.color == Color.Gray)
        {
            moves.Add(new int[] { x, y, z + dir });
        }

        // Forward Up
        target = board.GetPieceAt(x, y + dir, z + dir);
        if (target != null && target.color == Color.Gray)
        {
            moves.Add(new int[] { x, y + dir, z + dir });
        }

        // Forward Left
        target = board.GetPieceAt(x-1, y, z + dir);
        if (target != null && target.color != Color.Gray && target.color != color)
        {
            moves.Add(new int[] { x-1, y, z + dir });
        }

        // Forward Up Left
        target = board.GetPieceAt(x-1, y + dir, z + dir);
        if (target != null && target.color != Color.Gray && target.color != color)
        {
            moves.Add(new int[] { x-1, y + dir, z + dir });
        }

        // Forward Right
        target = board.GetPieceAt(x + 1, y, z + dir);
        if (target != null && target.color != Color.Gray && target.color != color)
        {
            moves.Add(new int[] { x + 1, y, z + dir });
        }

        // Forward Up Right
        target = board.GetPieceAt(x + 1, y + dir, z + dir);
        if (target != null && target.color != Color.Gray && target.color != color)
        {
            moves.Add(new int[] { x + 1, y + dir, z + dir });
        }

        return moves;
    }
}
