



using FundooModelJS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FundooRepository.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<RegisterModel> Users { get; set; }
    }
}
