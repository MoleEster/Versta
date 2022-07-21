namespace VerstaTest.Options.Options
{
    public class PostgresOptions
    {
        public const string SectionName = "Postgres";

        public string Database { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
