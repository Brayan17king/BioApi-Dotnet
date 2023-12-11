using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configuration;

public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        builder.ToTable("ContactoPersona");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(50);

        builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);

        builder.Property(x => x.IdPersonaFK).HasColumnType("int");
        builder.HasOne(x => x.Personas).WithMany(r => r.ContactoPersonas).HasForeignKey(x => x.IdPersonaFK);

        builder.Property(x => x.IdTipoContactoFk).HasColumnType("int");
        builder.HasOne(x => x.TipoContactos).WithMany(r => r.ContactoPersonas).HasForeignKey(x => x.IdTipoContactoFk);
    }
}