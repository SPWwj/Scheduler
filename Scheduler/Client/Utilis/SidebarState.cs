namespace Scheduler.Client.Utilis
{
    public class SidebarState
    {
        private bool _open = false;
        public bool Open
        {
            get => _open;
            set { _open = value; NotifyStateChanged(); }
        }
        private bool _hidden = true;
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; NotifyStateChanged(); }
        }
        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
