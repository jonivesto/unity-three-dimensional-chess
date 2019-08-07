using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public King(Color color)
    {
        this.color = color;
    }

    public override List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        List<int[]> moves = new List<int[]>();
        Piece current = board.GetPieceAt(x, y, z);
        Piece target;

        // Left
        target = board.GetPieceAt(x - 1, y, z);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x - 1, y, z });
        }

        // Right
        target = board.GetPieceAt(x + 1, y, z);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x + 1, y, z });
        }

        // Down
        target = board.GetPieceAt(x, y - 1, z);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x, y - 1, z });
        }

        // Up
        target = board.GetPieceAt(x, y + 1, z);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x, y + 1, z });
        }

        // Back
        target = board.GetPieceAt(x, y, z - 1);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x, y, z - 1 });
        }

        // Forward
        target = board.GetPieceAt(x, y, z + 1);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x, y, z + 1 });
        }

        // TODO: Rest of the moves

        return moves;
    }

}
