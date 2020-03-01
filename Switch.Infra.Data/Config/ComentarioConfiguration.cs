using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataPublicacao).IsRequired();
            builder.Property(c => c.Texto)
                .IsRequired()
                .HasMaxLength(600);
            /*DESNECESSÁRIO PORQUE FOI CONFIGURADA DO LADO DO USUÁRIO (UsuarioConfiguration)
            builder.HasOne(c => c.Usuario)//propriedade do comentário
                .WithMany(u => u.Comentarios);//propriedade do usuário*/
        }
    }
}
