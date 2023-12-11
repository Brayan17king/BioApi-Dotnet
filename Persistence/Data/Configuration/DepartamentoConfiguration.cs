using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.NombreDep).IsRequired().HasMaxLength(50);

        builder.Property(x => x.IdPaisFk).HasColumnType("int");
        builder.HasOne(x => x.Paises).WithMany(x => x.Departamentos).HasForeignKey(x => x.IdPaisFk);
    }
}