using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreMSSQL.Models;

namespace ASPNETCoreMSSQL.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }
        public DbSet<ASPNETCoreMSSQL.Models.Attendee> Attendee { get; set; }
    }
}
