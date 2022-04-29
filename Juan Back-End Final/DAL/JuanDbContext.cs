using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.DAL
{
    public class JuanDbContext : DbContext
    {
        public JuanDbContext(DbContextOptions<JuanDbContext> options): base(options)
        {

        }
    }
}
