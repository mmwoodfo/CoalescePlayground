using System;
using System.Collections.Generic;
using System.Text;

namespace CoalescePlayground.Data.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public string MiddleName { get; set; }
    }
}
