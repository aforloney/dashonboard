namespace Dashonboard.Data.Models
{
    public class DashonboardRequest
    {
        public string Organization { get; set; }
        public string RepositoryName { get; set; }
        public string CommitHash { get; set; }
    }
}
