using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ni.Models;

namespace Ni.Data
{
    public class NiDbContext : IdentityDbContext<NiUser>
    {
        private readonly IConfiguration _configuration;

        public DbSet<NiComment> NiComments { get; set; }

        public DbSet<NiCommentWebsite> NiWebsites { get; set; }


        public NiDbContext(
            DbContextOptions<NiDbContext> options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


    }
}
