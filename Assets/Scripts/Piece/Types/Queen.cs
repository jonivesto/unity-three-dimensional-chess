using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public Queen(Color color)
    {
        this.color = color;
    }

    public override List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        List<int[]> moves = new List<int[]>();

        moves.AddRange(new Bishop(color).GetMoves(x, y, z, board));
        moves.AddRange(new Rook(color).GetMoves(x, y, z, board));
        moves.AddRange(new Unicorn(color).GetMoves(x, y, z, board));

        this.moves = moves;
        return moves;
    }
}
