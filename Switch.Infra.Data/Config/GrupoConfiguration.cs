using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        

        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(g => g.Descricao)
                .HasMaxLength(400)
                .IsRequired();
            builder.Property(g => g.UrlFoto)
                .HasMaxLength(1000)
                .IsRequired();
            builder.HasMany(g => g.Postagens)
                    .WithOne(p => p.Grupo);
                    
        }
    }
}
