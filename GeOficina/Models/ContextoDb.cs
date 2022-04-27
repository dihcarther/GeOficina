
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GeOficina.Models;

namespace GeOficina.Models
{
    public class ContextoDb : IdentityDbContext
    {

        

        public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
        {

        Database.EnsureCreated();
        }



      



        public DbSet<GeOficina.Models.ServicosModel> ServicosModel { get; set; }



        public DbSet<GeOficina.Models.AgendamentoModel> AgendamentoModel { get; set; }





    }
}
