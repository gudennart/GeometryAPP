using GeometryAPP.Model;
using Microsoft.EntityFrameworkCore;

namespace GeometryAPP.Context
{
    public class GeoContext : DbContext
    {
        public DbSet<Square> Square { get; set; }
        public DbSet<Line> Line { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(System.IO.File.ReadAllText(@"..\..\..\..\DBConectionString.txt"));   // Necessário informar a senha do Banco
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Line>(entity =>
            {
                entity.HasKey(e => e.LineId);
                entity.Property(e => e.LineId).ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.StartX).IsRequired();
                entity.Property(e => e.StartY).IsRequired();
                entity.Property(e => e.EndX).IsRequired();
                entity.Property(e => e.EndY).IsRequired();
            });

            modelBuilder.Entity<Square>(entity =>
            {
                entity.HasKey(e => e.SquareId);
                entity.Property(e => e.SquareId).ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.StartX).IsRequired();
                entity.Property(e => e.StartY).IsRequired();
                entity.Property(e => e.Size).IsRequired();
            });

            
        }
    }
}

