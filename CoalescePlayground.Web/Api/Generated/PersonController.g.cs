
using CoalescePlayground.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoalescePlayground.Web.Api
{
    [Route("api/Person")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class PersonController
        : BaseApiController<CoalescePlayground.Data.Models.Person, PersonDtoGen, CoalescePlayground.Data.AppDbContext>
    {
        public PersonController(CoalescePlayground.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CoalescePlayground.Data.Models.Person>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PersonDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<PersonDtoGen>> List(
            ListParameters parameters,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<PersonDtoGen>> Save(
            PersonDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource,
            IBehaviors<CoalescePlayground.Data.Models.Person> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PersonDtoGen>> Delete(
            int id,
            IBehaviors<CoalescePlayground.Data.Models.Person> behaviors,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        /// <summary>
        /// Downloads CSV of PersonDtoGen
        /// </summary>
        [HttpGet("csvDownload")]
        [Authorize]
        public virtual Task<FileResult> CsvDownload(
            ListParameters parameters,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource)
            => CsvDownloadImplementation(parameters, dataSource);

        /// <summary>
        /// Returns CSV text of PersonDtoGen
        /// </summary>
        [HttpGet("csvText")]
        [Authorize]
        public virtual Task<string> CsvText(
            ListParameters parameters,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource)
            => CsvTextImplementation(parameters, dataSource);

        /// <summary>
        /// Saves CSV data as an uploaded file
        /// </summary>
        [HttpPost("csvUpload")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvUpload(
            IFormFile file,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource,
            IBehaviors<CoalescePlayground.Data.Models.Person> behaviors,
            bool hasHeader = true)
            => CsvUploadImplementation(file, dataSource, behaviors, hasHeader);

        /// <summary>
        /// Saves CSV data as a posted string
        /// </summary>
        [HttpPost("csvSave")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvSave(
            string csv,
            IDataSource<CoalescePlayground.Data.Models.Person> dataSource,
            IBehaviors<CoalescePlayground.Data.Models.Person> behaviors,
            bool hasHeader = true)
            => CsvSaveImplementation(csv, dataSource, behaviors, hasHeader);

        // Methods from data class exposed through API Controller.

        /// <summary>
        /// Method: SaveWithDelay
        /// </summary>
        [HttpPost("SaveWithDelay")]
        [Authorize]
        public virtual async Task<ItemResult> SaveWithDelay([FromServices] IDataSourceFactory dataSourceFactory, int id)
        {
            var dataSource = dataSourceFactory.GetDataSource<CoalescePlayground.Data.Models.Person, CoalescePlayground.Data.Models.Person>("Default");
            var (itemResult, _) = await dataSource.GetItemAsync(id, new ListParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult(itemResult);
            }
            var item = itemResult.Object;
            item.SaveWithDelay(Db);
            await Db.SaveChangesAsync();
            var result = new ItemResult();
            return result;
        }

        /// <summary>
        /// Method: FilterPeople
        /// </summary>
        [HttpPost("FilterPeople")]
        [Authorize]
        public virtual ItemResult<ICollection<PersonDtoGen>> FilterPeople(string filter)
        {
            IncludeTree includeTree = null;
            var methodResult = CoalescePlayground.Data.Models.Person.FilterPeople(Db, filter);
            var result = new ItemResult<ICollection<PersonDtoGen>>();
            var mappingContext = new MappingContext(User, "");
            result.Object = methodResult?.ToList().Select(o => Mapper.MapToDto<CoalescePlayground.Data.Models.Person, PersonDtoGen>(o, mappingContext, includeTree)).ToList();
            return result;
        }
    }
}
