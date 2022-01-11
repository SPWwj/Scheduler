namespace Scheduler.Shared.Model.TicTacToe
{
    public class Square
    {
        private readonly string[] images = new string[]
        {
            "images/tic_tac_toe/circle.png",
            "images/tic_tac_toe/wrongMark.png",
            "images/tic_tac_toe/white.png",
        };
        public int ID { get; set; }
        public Player? Player { get; set; }
        public string CssClass { get; set; } = String.Empty;
        public override string ToString()
        {
            return Player == null ? images[2] : Player.ID == 0 ? images[1] : images[0];
        }

    }
}