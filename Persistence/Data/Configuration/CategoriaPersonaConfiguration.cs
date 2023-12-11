using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
{
    public void Configure(EntityTypeBuilder<CategoriaPersona> builder)
    {
        builder.ToTable("CategoriaPersona");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.NombreCategoria).IsRequired().HasMaxLength(50);
    }
}