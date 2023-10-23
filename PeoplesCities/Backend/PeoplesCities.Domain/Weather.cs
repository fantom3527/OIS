using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Domain
{
    public class Weather
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public float Temperature { get; set; }
        public string Description { get; set; }
    }
}
