using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Device_Specs_Assignment3.Models;

namespace Device_Specs_Assignment3.Data
{
    public class Device_Specs_Assignment3Context : DbContext
    {
        public Device_Specs_Assignment3Context (DbContextOptions<Device_Specs_Assignment3Context> options)
            : base(options)
        {
        }

        public DbSet<Device_Specs_Assignment3.Models.Devices> Devices { get; set; } = default!;
    }
}
