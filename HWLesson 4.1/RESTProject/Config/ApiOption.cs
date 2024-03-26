namespace Config
{
    public class ApiOption
    {
        public string Host { get; set; } = null!;

        public string ListUsers { get; set; } = null!;

        public string SingleUser { get; set; } = null!;

        public string ListResource { get; set; } = null!;

        public string SingleResource { get; set; } = null!;

        public string UserCreate { get; set; } = null!;

        public string UserUpdate { get; set; } = null!;

        public string UserDelete { get; set; } = null!;

        public string Register { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string DelayedResponce { get; set; } = null!;
    }
}
