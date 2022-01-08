namespace Lib.Shared.TicTacToe
{
    public class Board
    {
        public Square[] Squares { get; set; } = new Square[9];
        public Player Winner
        {
            get
            {
                int[,] lines = new int[8, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
                for (int x = 0; x < lines.GetLength(0); x += 1)
                {
                    var a = lines[x, 0];
                    var b = lines[x, 1];
                    var c = lines[x, 2];
                    if (Squares[a].Player == Squares[b].Player
                    && Squares[a].Player == Squares[c].Player
                    && Squares[a].Player != null)
                    {
                        Squares[a].CssClass = "winner_square";
                        Squares[b].CssClass = "winner_square";
                        Squares[c].CssClass = "winner_square";
                        return Squares[a].Player!;
                    }
                }
                if(Squares.FirstOrDefault(p => p.Player == null) == null) {
                    return new Player { ID = 3, Name = "Draw" };
                }
                return null!;
            }
        }

        public Board()
        {
            Squares = Squares.Select((s, i) => new Square() { ID = i }).ToArray();
        }


    }
}