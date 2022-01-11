using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Scheduler.Client.FlappyBird.Data;
using Scheduler.Client.Utilis;

// THIS CODE IS "DIRECT TRANSLATION" FROM PYTHON PYGAME TO C# BLAZOR. REFACTOR PENDING

namespace Scheduler.Client.Pages.FlappyBird
{

    public class Statistics
    {
        public int fps;
        public int totalPlayers;
        public string? totalSessions;
        public string? startedAt;

        public int maxScore;
        public string maxScorePlayer = "** none **";
    }

    public class FlappyBirdPageBase : ComponentBase, IDisposable
    {
        [Inject] protected MenuItemState? MenuItemState { get; set; }


        Universe Universe { get; set; } = new Universe();// For blazor server inject this as singleton to enable multi player
        // [Inject] protected IJSRuntime JSRuntime {get; set; }       

        protected void KeyDown(KeyboardEventArgs e)
        {
            if (e.Key == " " || e.Key == "p")
            {
                CheckIsRunning();
                MyBird!.KeyPressed.Enqueue(e);
            }
        }
        protected void OnClick()
        {

            CheckIsRunning();
            var e = new KeyboardEventArgs
            {
                Key = MyBird!.IsDead ? "p" : "ArrowUp"
            };
            MyBird.KeyPressed.Enqueue(e);
        }

        protected void CheckIsRunning()
        {
            if (MyBird!.IsDead)
            {
                Universe.PleaseWeakUp();
                PleaseStopSent = false;
            }
        }

        protected ElementReference OuterDiv;
        protected Bird? MyBird = null;

        protected override void OnInitialized()
        {
            MenuItemState!.SetCurrentURL("flappybird");

        }

        protected bool MyBirdIsSet = false;
        protected string Birdname { set; get; } = "";

        protected void OnNickIsSet()
        {
            if (string.IsNullOrWhiteSpace(Birdname)) return;

            MyBird = new Bird(Universe)
            {
                Name = Birdname
            };

            MyBirdIsSet = true;
            Universe.PleaseWeakUp();
            Universe.Tic += Render!;
            PleaseStopSent = false;
        }

        protected Statistics Statistics = new() { };
        protected bool PleaseStopSent = false;


        protected List<Printable> ToRender = new();
        protected List<Printable> Firsts = new();

        private void Render(object sender, TicEventArgs e)
        {
            var toRender = new List<Printable>();

            // background
            var background = e.Universe.PrintableBackground;
            toRender.Add(background);

            // pipes
            var pipes = e.PrintablePipes;

            if (MyBird!.IsDead || MyBird.CurrentGraceInterval > 0)
            {
                pipes = pipes.Select(p => new Printable(p.X, p.Y, p.Image, Convert.ToInt32(p.R), 0.4, p.GuidKey)).ToList();
            }
            toRender.AddRange(pipes);


            // the base
            var theBase = e.Universe.TheBase;
            toRender.Add(theBase);

            // score
            toRender.AddRange(GetPrintableScore(MyBird.score));

            //
            var otherImages = Universe.PLAYERS_LIST[1];
            var myImage = Universe.PLAYERS_LIST[0];

            // other players
            foreach (var bird in e.Players)
            {
                if (bird != MyBird)
                {
                    var otherBirdIndex = bird.IsDead ? 0 : bird.playerIndex;
                    var otherBird = new Printable(bird.playerx, bird.playery, otherImages[otherBirdIndex], -bird.visibleRot, opacity: 0.5, guidKey: bird.GuidKey);
                    toRender.Add(otherBird);
                }
            }

            Firsts = e.Firsts.ToList();

            // myBird
            var myBirdIndex = MyBird.IsDead ? 0 : MyBird.playerIndex;
            var ocell = new Printable(MyBird.playerx, MyBird.playery, myImage[myBirdIndex], -MyBird.visibleRot, null, MyBird.GuidKey);
            toRender.Add(ocell);

            // play again
            if (MyBird.IsDead && MyBird.CurrentPenaltyTime == 0)
            {
                var playAgain = e.Universe.PlayAgain;
                toRender.Add(playAgain);
                if (!PleaseStopSent)
                {
                    PleaseStopSent = true;
                    Universe.PleaseStop();
                }
            }
            else if (MyBird.IsDead && MyBird.CurrentPenaltyTime > 0)
            {
                var gameOver = e.Universe.GameOver;
                toRender.Add(gameOver);
            }

            Statistics.totalPlayers = e.Players.Count;
            Statistics.fps = Universe.CurrentFps;
            Statistics.totalSessions = Universe.TotalSessions.ToString();
            Statistics.startedAt = Universe.StartedAt;
            Statistics.maxScore = Universe.MaxScore;
            Statistics.maxScorePlayer = Universe.MaxScorePlayer;
            lock (ToRender)
            {
                ToRender.Clear();
                ToRender.AddRange(toRender);
            }

            InvokeAsync(StateHasChanged);
            GoToSetFocus = true;
        }

        private bool GoToSetFocus = false;
        private bool GoToSetFocusAlreadySet = false;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (GoToSetFocus && !GoToSetFocusAlreadySet)
            {
                await OuterDiv.FocusAsync();
                GoToSetFocusAlreadySet = true;
            }
        }

        private int previousScore = -1;
        private List<Printable>? previousPrintableScore = null;
        private List<Printable> GetPrintableScore(int score)
        {
            if (score == previousScore) return previousPrintableScore!;
            previousScore = score;

            var result = new List<Printable>();
            var scoreDigits = score.ToString().ToCharArray().Select(x => x - '0');
            var totalWidth = 0;
            foreach (var digit in scoreDigits) totalWidth += Universe.GetDigitWidth(digit);

            var Xoffset = (Universe.SCREENWIDTH - totalWidth) / 2;
            foreach (var digit in scoreDigits)
            {
                result.Add(
                    new Printable(Xoffset, Convert.ToInt32(Universe.SCREENHEIGHT * 0.1), Universe.IMAGESS["numbers"][digit], null, null, Guid.NewGuid())
                );
                Xoffset += Universe.GetDigitWidth(digit);
            }
            previousPrintableScore = result;
            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Universe.Tic -= Render!;
                    Universe.Players.Remove(MyBird!);
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

    }

}