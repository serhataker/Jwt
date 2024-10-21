
using Jwt.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jwt.Data
{

    // Our services DB Context
    public class JwtContext : DbContext
    {

        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
        }

        // DbSet defined
        public DbSet<UserEntity> Users { get; set; }

        
    }
}
