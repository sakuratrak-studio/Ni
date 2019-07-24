using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ni.Models;

namespace Ni.Data
{
    public class NiDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<NiComment> NiComments { get; set; }

        public DbSet<NiUser> NiUsers { get; set; }

        public DbSet<NiWebsite> NiWebsites { get; set; }


        public NiDbContext(
            DbContextOptions<NiDbContext> options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


    }
}
