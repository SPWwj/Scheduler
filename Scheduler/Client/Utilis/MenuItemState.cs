namespace Scheduler.Client.Utilis
{
    public class MenuItemState
    {
        public List<CustomMenuItem> MenuItems = new List<CustomMenuItem>
        {
            new CustomMenuItem{ Id = "parent1", Text = "Home" , Url = "/" },
            new CustomMenuItem{ Id = "parent2", Text = "Chat", Url = "chat" },
            new CustomMenuItem{ Id = "parent3", Text = "Schedule" , Url = "schedule" },
            new CustomMenuItem{ Id = "parent3", Text = "Counter", Url = "counter" },
        };
        public void SetCurrentURL(string url)
        {
            MenuItems.ForEach(i => i.Disabled = false);
            MenuItems.First(i => i.Url == url).Disabled = true;
        }

    }
    public class CustomMenuItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public bool Disabled { get; set; } = false;

    }
}
