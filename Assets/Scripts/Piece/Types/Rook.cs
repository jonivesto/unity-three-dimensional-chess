using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public Rook(Color color)
    {
        this.color = color;
    }

    public override List<int[]> GetMoves(int x, int y, int z, Board board)
    {
        List<int[]> moves = new List<int[]>();
        Piece current = board.GetPieceAt(x, y, z);
        Piece target;

        // Forward
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y, z + i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x, y, z + i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x, y, z + i });
                break;
            }
        }

        // Back
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y, z - i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x, y, z - i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x, y, z - i });
                break;
            }
        }

        // Right
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x + i, y, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x + i, y, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x + i, y, z });
                break;
            }
        }

        // Left
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x - i, y, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x - i, y, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x - i, y, z });
                break;
            }
        }

        // Up
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y + i, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x , y + i, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x , y + i, z });
                break;
            }
        }

        // Down
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y - i, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x, y - i, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x, y - i, z });
                break;
            }

        }

        this.moves = moves;
        return moves;
    }
}
