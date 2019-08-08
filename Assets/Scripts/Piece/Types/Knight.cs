using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public Knight(Color color)
    {
        this.color = color;
    }

    public override List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        List<int[]> moves = new List<int[]>();
        Piece target = board.GetPieceAt(x, y, z);

        // Cube around the piece
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if ((i > 0 && i < 4) && (j > 0 && j < 4) && (k > 0 && k < 4)) continue;

                    if ((k == 2 && Pattern(i + 1))
                       || (k == 2 && Pattern(j + 1))
                       || (j == 2 && Pattern(k + 1))
                       || (j == 2 && Pattern(i + 1))
                       || (i == 2 && Pattern(j + 1))
                       || (i == 2 && Pattern(k + 1)))
                    {
                        int xx = x - 2 + i;
                        int yy = y - 2 + j;
                        int zz = z - 2 + k;

                        target = board.GetPieceAt(xx, yy, zz);

                        // Ignore self, out of bounds, and pieces of same color
                        if (target != null && target.color != color)
                        {
                            moves.Add(new int[] { xx, yy, zz });
                        }
                    }
                }
            }
        }

        this.moves = moves;
        return moves;
    }

    private bool Pattern(int i)
    {
        int[] pattern = { 2, 4, 6, 10, 16, 10, 22, 24 };

        foreach (var p in pattern)
        {
            if (i == p) return true;
        }

        return false;
    }

}
