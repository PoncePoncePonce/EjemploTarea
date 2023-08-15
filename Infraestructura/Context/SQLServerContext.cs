using Business.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Context
{
    public class SQLServerContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public SQLServerContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            //Tabla y condiciones de cliente
            builder.Entity<Persona>().ToTable("Personas", "cat").HasKey(e => e.Id);
            builder.Entity<Persona>().Property(p => p.Nombre).HasMaxLength(50).IsRequired().HasColumnName("nombre");
            builder.Entity<Persona>().Property(p => p.Apellido).HasMaxLength(50).IsRequired().HasColumnName("apellido");
            builder.Entity<Persona>().Property(p => p.Edad).IsRequired().HasColumnName("edad");
        }
    }
}
