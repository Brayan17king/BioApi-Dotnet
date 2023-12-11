using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.IdPersona).HasColumnType("int");

        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);

        builder.Property(x => x.DateReg).HasColumnType("date");

        builder.Property(x => x.IdTipoPersonaFk).HasColumnType("int");
        builder.HasOne(x => x.TipoPersonas).WithMany(r => r.Personas).HasForeignKey(x => x.IdTipoPersonaFk);

        builder.Property(x => x.IdCategoriaPersonaFk).HasColumnType("int");
        builder.HasOne(x => x.CategoriaPersonas).WithMany(r => r.Personas).HasForeignKey(x => x.IdCategoriaPersonaFk);

        builder.Property(x => x.IdCiudadFk).HasColumnType("int");
        builder.HasOne(x => x.Ciudades).WithMany(r => r.Personas).HasForeignKey(x => x.IdCiudadFk);
    }
}