using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Builderz.Models;
using Microsoft.EntityFrameworkCore;

namespace Builderz.Data
{
    public class BuilderzContext : DbContext
    {
        public BuilderzContext (DbContextOptions<BuilderzContext> options)
            : base(options)
        {
        }

        public DbSet<Projects> Projects { get; set; }

        public DbSet<SelectedProjects> SelectedProjects { get; set; }

        public DbSet<Query> Query { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
