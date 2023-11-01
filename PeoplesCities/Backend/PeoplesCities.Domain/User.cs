﻿namespace PeoplesCities.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Ts { get; set; }
        public City City { get; set; }
    }
}
