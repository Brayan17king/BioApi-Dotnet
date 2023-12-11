using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.ToTable("programacion");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.IdContratoFk).HasColumnType("int");
        builder.HasOne(x => x.Contratos).WithMany(r => r.Programacions).HasForeignKey(x => x.IdContratoFk);

        builder.Property(x => x.IdTurnoFk).HasColumnType("int");
        builder.HasOne(x => x.Turnos).WithMany(r => r.Programacions).HasForeignKey(x => x.IdTurnoFk);

        builder.Property(x => x.IdPersonaFk).HasColumnType("int");
        builder.HasOne(x => x.Personas).WithMany(r => r.Programacions).HasForeignKey(x => x.IdPersonaFk);
    }
}