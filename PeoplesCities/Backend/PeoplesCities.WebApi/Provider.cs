namespace PeoplesCities.WebApi
{
    public record Provider(string Name, string Assembly)
    {
        public static Provider Sqlite = new(nameof(Sqlite), typeof(Sqlite.Marker).Assembly.GetName().Name!);
        public static Provider PostgreSql = new(nameof(PostgreSql), typeof(PostgreSql.Marker).Assembly.GetName().Name!);
    }
}
