using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class TurnosConfiguration : IEntityTypeConfiguration<Turnos>
{
    public void Configure(EntityTypeBuilder<Turnos> builder)
    {
        builder.ToTable("turnos");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.NombreTurno).IsRequired().HasMaxLength(50);
        builder.Property(x => x.HoraTurnoI).HasColumnType("date");
        builder.Property(x => x.HoraTurnoF).HasColumnType("date");
    }
}