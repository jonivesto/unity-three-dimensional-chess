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

        // Forward Up
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y + i, z + i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x, y + i, z + i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x, y + i, z + i });
                break;
            }
        }

        // Back Up
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y + i, z - i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x, y + i, z - i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x, y + i, z - i });
                break;
            }
        }

        // Right Up
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x + i, y + i, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x + i, y + i, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x + i, y + i, z });
                break;
            }
        }

        // Left Up
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x - i, y + i, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x - i, y + i, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x - i, y + i, z });
                break;
            }
        }

        // Forward Down
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y - i, z + i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x, y - i, z + i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x, y - i, z + i });
                break;
            }
        }

        // Back Down
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x, y - i, z - i);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x, y - i, z - i });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x, y - i, z - i });
                break;
            }
        }

        // Right Down
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x + i, y - i, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x + i, y - i, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x + i, y - i, z });
                break;
            }
        }

        // Left Down
        for (int i = 1; i < board.boardSize; i++)
        {
            target = board.GetPieceAt(x - i, y - i, z);

            if (target == null || target.color == color) // Not allowed
            {
                break;
            }
            else if (target.color == Color.Gray) // Free to capture
            {
                moves.Add(new int[] { x - i, y - i, z });
            }
            else if (target.color != current.color) // Enemy to capture
            {
                moves.Add(new int[] { x - i, y - i, z });
                break;
            }
        }

        return moves;
    }
}
