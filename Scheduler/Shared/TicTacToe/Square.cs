namespace Scheduler.Shared.TicTacToe
{
    public class Square
    {
        private readonly string[] images = new string[]
        {
            "images/circle.png",
            "images/wrongMark.png",
            "images/white.png",
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