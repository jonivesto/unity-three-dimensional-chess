using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public Bishop(Color color)
    {
        this.color = color;
    }

    public override List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        List<int[]> moves = new List<int[]>();
        Piece current = board.GetPieceAt(x, y, z);
        Piece target;


        return moves;
    }
}
