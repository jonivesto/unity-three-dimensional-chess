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

        // Cube around the piece
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (j == 1) continue;

                    int xi = x - 1 + i;
                    int yj = y - 1 + j;
                    int zk = z - 1 + k;

                    target = board.GetPieceAt(xi, yj, zk);

                    // Ignore self, out of bounds, and pieces of same color
                    if (target != null && target.color != current.color) 
                    {
                        moves.Add(new int[] { xi, yj, zk });
                    }
                }
            }
        }

        target = board.GetPieceAt(x + 1, y, z);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x + 1, y, z });
        }

        target = board.GetPieceAt(x - 1, y, z);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x - 1, y, z });
        }

        target = board.GetPieceAt(x, y, z - 1);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x, y, z - 1});
        }

        target = board.GetPieceAt(x, y, z + 1);
        if (target != null && target.color != current.color)
        {
            moves.Add(new int[] { x, y, z + 1 });
        }

        this.moves = moves;
        return moves;
    }

}
