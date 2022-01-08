namespace Lib.Shared.TicTacToe
{
    public class Player
    {

        public string Name { get; set; } = "";
        public string TempName { get; set; } = "";
        public int ID { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}