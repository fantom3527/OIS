namespace PeoplesCities.Domain
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Ts { get; set; }
        public List<User> Users { get; set; }
    }
}
