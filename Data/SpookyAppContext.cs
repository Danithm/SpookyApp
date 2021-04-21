using SpookyApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpookyApp.Data
{
    public class SpookyAppContext : DbContext
    {
        public SpookyAppContext(DbContextOptions<SpookyAppContext> opt) : base(opt)
        {

        }

        //Maps the Spooky model to the db w/ DbContext
        public DbSet<Spooky> Spookys { get; set; }
    }
}
