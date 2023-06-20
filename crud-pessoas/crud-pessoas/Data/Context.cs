using crud_pessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_pessoas.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> op):base(op)
        {

        }

        public DbSet<PessoaModel> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
