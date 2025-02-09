using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class FrazzesPlatslageriDB : DbContext
    {
        public FrazzesPlatslageriDB(DbContextOptions<FrazzesPlatslageriDB> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
