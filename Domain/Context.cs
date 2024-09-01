using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Context:DbContext
    {

        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Photo> Photos{ get; set; }

    }
}
