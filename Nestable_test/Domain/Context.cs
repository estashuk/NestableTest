using System.Data.Entity;
using Nestable_test.Domain.Entities;

namespace Nestable_test.Domain
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection")
        {

        }

        public DbSet<MenuData> MenuCfg { get; set; }
    }
}