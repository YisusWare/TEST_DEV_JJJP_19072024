using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST_DEV_API.Models;

namespace TEST_DEV.Data.Data
{
    public partial class SPDbContext : DbContext
    {
        public SPDbContext()
        {
        }

        public SPDbContext(DbContextOptions<SPDbContext> options)
            : base(options)
        {
        }

        public DbSet<TbPersonasFisica> tbPersonasFisicas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //                if (!optionsBuilder.IsConfigured)
            //                {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                    optionsBuilder.UseSqlServer("Server=localhost;Database=PruebaTecnica;Trusted_Connection=True;");
            //                }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
