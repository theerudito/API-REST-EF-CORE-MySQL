using EF_MySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_MySQL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        // CREAR TABLAS APARTIR DEL MODELO CHARACTERS
        public DbSet<Character> Naruto => Set<Character>();

    }
}
