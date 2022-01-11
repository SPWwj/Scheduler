using System;
using System.Collections.Generic;

// THIS CODE IS "DIRECT TRANSLATION" FROM PYTHON PYGAME TO C# BLAZOR. REFACTOR PENDING

namespace Scheduler.Client.FlappyBird.Data
{
    public class TicEventArgs : EventArgs
    {
        public readonly List<Bird> Players;
        public List<Printable> PrintablePipes;
        public List<Printable> Firsts;

        public readonly Universe Universe;

        public TicEventArgs(List<Bird> players,  List<Printable> printablePipes, Universe universe, List<Printable> firsts)
        {
            Players = players;
            Universe = universe;
            PrintablePipes = printablePipes;
            Firsts = firsts;
        }
    }
}