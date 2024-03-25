using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBatDongSan.Models;

namespace BDS.Data
{
    public class BDSContext : DbContext
    {
        public BDSContext (DbContextOptions<BDSContext> options)
            : base(options)
        {
        }

        public DbSet<WebBatDongSan.Models.BDS> BDS { get; set; } = default!;
    }
}
