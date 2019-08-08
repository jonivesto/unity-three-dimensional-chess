
public class Raumschach : ChessVariant
{
    public Raumschach()
    {
        layoutName = "5x5x5 Raumschach";

        boardSize = 5;

        pieces = new Piece[boardSize, boardSize, boardSize];

        pieces[2, 0, 0] = new King(Color.White);
        pieces[2, 1, 0] = new Queen(Color.White);
        pieces[2, 4, 4] = new King(Color.Black);
        pieces[2, 3, 4] = new Queen(Color.Black);

        pieces[3, 1, 0] = new Bishop(Color.White);
        pieces[0, 1, 0] = new Bishop(Color.White);
        pieces[1, 3, 4] = new Bishop(Color.Black);
        pieces[4, 3, 4] = new Bishop(Color.Black);

        pieces[1, 1, 0] = new Unicorn(Color.White);
        pieces[4, 1, 0] = new Unicorn(Color.White);
        pieces[3, 3, 4] = new Unicorn(Color.Black);
        pieces[0, 3, 4] = new Unicorn(Color.Black);

        pieces[1, 0, 0] = new Knight(Color.White);
        pieces[3, 0, 0] = new Knight(Color.White);
        pieces[3, 4, 4] = new Knight(Color.Black);
        pieces[1, 4, 4] = new Knight(Color.Black);

        pieces[0, 0, 0] = new Rook(Color.White);
        pieces[4, 0, 0] = new Rook(Color.White);
        pieces[0, 4, 4] = new Rook(Color.Black);
        pieces[4, 4, 4] = new Rook(Color.Black);

        for (int i = 0; i < 5; i++)
        {
            pieces[i, 0, 1] = new Pawn(Color.White);
            pieces[i, 1, 1] = new Pawn(Color.White);

            pieces[i, 4, 3] = new Pawn(Color.Black);
            pieces[i, 3, 3] = new Pawn(Color.Black);
        }
    }
}
