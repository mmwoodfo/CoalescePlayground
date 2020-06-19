using IntelliTect.Coalesce;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoalescePlayground.Data.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public string MiddleName { get; set; }

        [Coalesce]
        public void SaveWithDelay(AppDbContext dbContext)
        {
            var result = dbContext.Person.Find(PersonId);
            result.Name = this.Name;
            result.BirthDate = this.BirthDate;
            result.MiddleName = this.MiddleName;

            Task.Delay(3000).Wait();
        }
    }
}
