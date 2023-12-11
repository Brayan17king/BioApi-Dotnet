using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("contrato");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.FechaContrato).HasColumnType("date");

        builder.Property(x => x.FechaFin).HasColumnType("date");

        builder.Property(x => x.IdClientesFk).HasColumnType("int");
        builder.HasOne(x => x.Personas).WithMany(r => r.Contratos).HasForeignKey(x => x.IdClientesFk);

        builder.Property(x => x.IdEmpleadosFk).HasColumnType("int");
        builder.HasOne(x => x.Personas).WithMany(r => r.Contratos).HasForeignKey(x => x.IdEmpleadosFk);

        builder.Property(x => x.IdEstadoFK).HasColumnType("int");
        builder.HasOne(x => x.Estados).WithMany(r => r.Contratos).HasForeignKey(x => x.IdEstadoFK);
    }
}