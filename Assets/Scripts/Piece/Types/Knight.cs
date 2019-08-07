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
                    // Ignore self, out of bounds, and pieces of same color
                    if (target != null && target.color != color)
                    {
                        moves.Add(new int[] { x, y, z });
                    }
                }
            }
        }

        return moves;
    }


}
