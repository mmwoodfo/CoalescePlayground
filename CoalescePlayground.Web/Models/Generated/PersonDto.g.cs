using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CoalescePlayground.Web.Models
{
    public partial class PersonDtoGen : GeneratedDto<CoalescePlayground.Data.Models.Person>
    {
        public PersonDtoGen() { }

        private int? _PersonId;
        private string _Name;
        private System.DateTimeOffset? _BirthDate;
        private string _MiddleName;
        private int? _SecurityLevel;
        private System.DateTimeOffset? _Modified;
        private System.DateTimeOffset? _Created;

        public int? PersonId
        {
            get => _PersonId;
            set { _PersonId = value; Changed(nameof(PersonId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public System.DateTimeOffset? BirthDate
        {
            get => _BirthDate;
            set { _BirthDate = value; Changed(nameof(BirthDate)); }
        }
        public string MiddleName
        {
            get => _MiddleName;
            set { _MiddleName = value; Changed(nameof(MiddleName)); }
        }
        public int? SecurityLevel
        {
            get => _SecurityLevel;
            set { _SecurityLevel = value; Changed(nameof(SecurityLevel)); }
        }
        public System.DateTimeOffset? Modified
        {
            get => _Modified;
            set { _Modified = value; Changed(nameof(Modified)); }
        }
        public System.DateTimeOffset? Created
        {
            get => _Created;
            set { _Created = value; Changed(nameof(Created)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CoalescePlayground.Data.Models.Person obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.PersonId = obj.PersonId;
            this.Name = obj.Name;
            this.BirthDate = obj.BirthDate;
            this.MiddleName = obj.MiddleName;
            this.SecurityLevel = obj.SecurityLevel;
            this.Modified = obj.Modified;
            this.Created = obj.Created;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CoalescePlayground.Data.Models.Person entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(PersonId))) entity.PersonId = (PersonId ?? entity.PersonId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(BirthDate))) entity.BirthDate = BirthDate;
            if (ShouldMapTo(nameof(MiddleName))) entity.MiddleName = MiddleName;
            if (ShouldMapTo(nameof(SecurityLevel))) entity.SecurityLevel = (SecurityLevel ?? entity.SecurityLevel);
            if (ShouldMapTo(nameof(Modified))) entity.Modified = (Modified ?? entity.Modified);
            if (ShouldMapTo(nameof(Created))) entity.Created = (Created ?? entity.Created);
        }
    }
}
