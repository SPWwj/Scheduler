namespace Scheduler.Shared.TicTacToe
{
    public class TicTacToe
    {
        public Board Board { get; set; }
        public Player[] Players { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player? Winner { get; set; }

        public TicTacToe()
        {
            Players = new Player[]{
                new Player{Name = "X", ID = 0},
                new Player{Name = "O", ID = 1}
            };
            CurrentPlayer = Players.First();
            Board = new Board();
        }
        public void SetName(string name)
        {
            Players[0].Name = name;
        }
        public void Reset()
        {
            Board = new Board();
            Winner = null;
            CurrentPlayer = Players[0];
        }

        public bool PlayTurn(Square s)
        {
            if (Board.Winner == null && s.Player == null)
            {
                s.Player = CurrentPlayer;
                CurrentPlayer = Players.First(p => p.ID != CurrentPlayer.ID);
                Winner = Board.Winner;
                return true;
            }
            return false;
        }

    }
}