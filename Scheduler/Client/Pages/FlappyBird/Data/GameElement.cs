using System;

namespace Scheduler.Client.FlappyBird.Data
{
    public class GameElement
   {
        protected static readonly Random getrandom = new();
        private Guid? guidKey;
        public Guid GuidKey 
        {
            set
            {
                guidKey=value;
            } 
            get
            {
                if (guidKey==null || guidKey==Guid.Empty) guidKey = Guid.NewGuid();
                return guidKey.Value;
            }
        }
        public string Key => GuidKey.ToString();
        public string? Name {get; set;}
        public double X {set; get; }
        public double Y {set; get; }
        public double? R {set; get; }
        public virtual int Width {set; get; }
        public virtual int Height {set; get; }
        public long CssX =>Convert.ToInt32(X);
        public long CssY =>Convert.ToInt32(Y);
        public virtual string? Image { get; set; }

        public double? Opacity = null;

        private string OpacityCss => Opacity.HasValue?$"opacity: {Opacity.Value.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture)};":"";
        public string RotateTransform => this.R.HasValue?$"transform: rotate({Convert.ToInt32(R).ToString()}deg);":"";
        public virtual string CssStyle => $@"
            position: absolute;
            top: {CssY}px;
            left: {CssX}px;
            z-index: 0;
            {RotateTransform}
            {OpacityCss}";
    }

}