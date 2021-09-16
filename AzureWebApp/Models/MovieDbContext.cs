using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebApp.Models
{
    public class MovieDbContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }
    }
}
