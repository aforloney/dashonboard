namespace Dashonboard.Data.Models
{
    /// <summary>
    /// Stores the configuration for accessing the Github API
    /// </summary>
    public class BasicAuthCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
