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
        Piece current = board.GetPieceAt(x, y, z);
        Piece target;

        // Forward Up Right
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x + i, y + i, z + i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x + i, y + i, z + i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x + i, y + i, z + i });
                break;
            }
        }

        // Forward Up Left
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x - i, y + i, z + i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x - i, y + i, z + i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x - i, y + i, z + i });
                break;
            }
        }

        // Back Up Right
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x + i, y + i, z - i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x + i, y + i, z - i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x + i, y + i, z - i });
                break;
            }
        }

        // Back Up Left
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x - i, y + i, z - i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x - i, y + i, z - i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x - i, y + i, z - i });
                break;
            }
        }

        // Forward Down Right
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x + i, y - i, z + i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x + i, y - i, z + i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x + i, y - i, z + i });
                break;
            }
        }

        // Forward Down Left
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x - i, y - i, z + i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x - i, y - i, z + i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x - i, y - i, z + i });
                break;
            }
        }

        // Back Down Right
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x + i, y - i, z - i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x + i, y - i, z - i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x + i, y - i, z - i });
                break;
            }
        }

        // Back Down Left
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x - i, y - i, z - i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x - i, y - i, z - i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x - i, y - i, z - i });
                break;
            }
        }

        return moves;
    }
}
