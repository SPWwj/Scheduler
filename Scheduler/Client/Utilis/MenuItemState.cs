namespace Scheduler.Client.Utilis
{
    public class MenuItemState
    {
        private bool toggleSidebar;

        public bool ToggleSidebar
        {
            get => toggleSidebar;
            set
            {
                toggleSidebar = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public List<CustomMenuItem> MenuItems = new()
        {
            new CustomMenuItem{ Id = "1", Text = "Home" , Url = "/" },
            new CustomMenuItem{ Id = "2", Text = "Schedule" , Url = "schedule" },
            new CustomMenuItem { Id = "3", Text = "Open Chat Panel", Hidden = true },
            new CustomMenuItem { Id = "4", Text = "Tic Tac Toe", Url ="tictactoe" },
        };
        public void SetCurrentURL(string url)
        {
            MenuItems.ForEach(i => i.Disabled = false);
            MenuItems.First(i => i.Url == url).Disabled = true;
            if (url == "schedule") MenuItems.First(i => i.Id == "3").Hidden = false;
            else MenuItems.First(i => i.Id == "3").Hidden = true;
        }

    }
    public class CustomMenuItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public bool Disabled { get; set; } = false;
        public bool Hidden { get; set; } = false;

    }
}
