using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Message> Messages { get; set; }
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
