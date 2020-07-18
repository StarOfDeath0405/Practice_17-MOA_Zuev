using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace practice.Models
{
    public class GroupsContext : DbContext
    {
        public GroupsContext(DbContextOptions<GroupsContext> options)
            : base(options) 
        { 
        }

        public DbSet<Groups> Groups { get; set; }


    }
}
