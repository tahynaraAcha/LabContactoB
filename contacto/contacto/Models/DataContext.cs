
namespace contacto.Models
{
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<contacto.Models.Contact> Contacts { get; set; }
    }
}