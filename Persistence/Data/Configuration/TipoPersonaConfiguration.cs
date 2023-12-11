using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class TipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
{
    public void Configure(EntityTypeBuilder<TipoDireccion> builder)
    {
        builder.ToTable("TipoDireccion");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);
    }
}