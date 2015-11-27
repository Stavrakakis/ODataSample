using OData.Models;
using System.Data.Entity;

namespace OData.Context
{
    public class ODataDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public ODataDbContext() : base("name=ODataDbContext")
        {

        }
    }
}
