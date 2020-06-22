using IntelliTect.Coalesce;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.Utilities;

namespace CoalescePlayground.Data.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public string MiddleName { get; set; }

        public int SecurityLevel { get; set; }

        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset Created { get; set; }

        [Coalesce]
        public void SaveWithDelay(AppDbContext dbContext)
        {
            var result = dbContext.Person.Find(PersonId);
            result.Name = this.Name;
            result.BirthDate = this.BirthDate;
            result.MiddleName = this.MiddleName;
            Task.Delay(3000).Wait();
        }



        [Coalesce]
        public static ICollection<Person> FilterPeople(AppDbContext dbContext, string filter) 
            => dbContext.Person.Where(x => x.Name.Contains(filter)).ToList();


        [DefaultDataSource]
        public class FilterOutUsersAboveClassification : StandardDataSource<Person, AppDbContext>
        {
            public FilterOutUsersAboveClassification(CrudContext<AppDbContext> context) : base(context) { }

            public override IQueryable<Person> GetQuery(IDataSourceParameters parameters)
                => Db.Person.Where(x => x.SecurityLevel <= 3);
        }



        [Coalesce]
        public class PersonAuditFieldBehavior : StandardBehaviors<Person, AppDbContext>
        {
            public PersonAuditFieldBehavior(CrudContext<AppDbContext> context) : base(context) { }

            public override ItemResult BeforeSave(SaveKind kind, Person oldItem, Person item)
            {
                if (kind == SaveKind.Update)
                {
                    item.Modified = DateTimeOffset.Now;
                    return true;
                }
                else if (kind == SaveKind.Create)
                {
                    item.Created = DateTimeOffset.Now;
                    item.Modified = DateTimeOffset.Now;
                }
                return true;
            }

        }

    }
}
