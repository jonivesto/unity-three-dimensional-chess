using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBoardLayout : BoardLayout
{
    public DefaultBoardLayout()
    {
        layoutName = "Default 5x5";

        boardSize = 5;

        pieces = new Piece[boardSize, boardSize, boardSize];

        pieces[0, 0, 2] = new King(Color.WHITE);
        pieces[4, 4, 2] = new King(Color.BLACK);
    }
}
