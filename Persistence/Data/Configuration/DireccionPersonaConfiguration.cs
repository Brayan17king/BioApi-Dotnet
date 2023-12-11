using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class DireccionPersonaConfiguration : IEntityTypeConfiguration<DireccionPersona>
{
    public void Configure(EntityTypeBuilder<DireccionPersona> builder)
    {
        builder.ToTable("DireccionPersona");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.Direccion).IsRequired().HasMaxLength(50);

        builder.Property(x => x.IdPersonaFK).HasColumnType("int");
        builder.HasOne(x => x.Personas).WithMany(r => r.DireccionPersonas).HasForeignKey(x => x.IdPersonaFK);

        builder.Property(x => x.IdTipoDireccionFk).HasColumnType("int");
        builder.HasOne(x => x.TipoDirecciones).WithMany(r => r.DireccionPersonas).HasForeignKey(x => x.IdTipoDireccionFk);
    }
}