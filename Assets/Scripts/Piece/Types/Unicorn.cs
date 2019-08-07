using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicorn : Piece
{
    public Unicorn(Color color)
    {
        this.color = color;
    }

    public override List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        List<int[]> moves = new List<int[]>();


        return moves;
    }
}
