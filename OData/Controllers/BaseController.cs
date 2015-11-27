using OData.Context;
using OData.Models;
using System.Linq;
using System.Web.OData;
using System.Web.OData.Query;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using OData.Middleware;

namespace OData.Controllers
{
    [LoggingFilter]
    public class BaseController<T> : ODataController where T : class, IDataModel
    {
        private readonly ODataDbContext db;
        private readonly DbSet<T> set;

        public BaseController()
        {
            this.db = new ODataDbContext();
            this.set = this.db.Set<T>();
        }
        
        [EnableQuery]
        public IQueryable<T> Get(ODataQueryOptions options)
        {                        
            return this.set.AsQueryable();
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Post(T entity)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.set.Add(entity);

            await this.db.SaveChangesAsync();

            return this.Created<T>(entity);
        }
    }
}
