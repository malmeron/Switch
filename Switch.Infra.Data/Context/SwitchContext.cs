using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Infra.Data.Config;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<StatusRelacionamento> StatusRelacionamento { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Identificacao> Identificacao { get; set; }
        public DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }

        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<InstituicaoEnsino> InstituicoesEnsino { get; set; }
        public DbSet<LocalTrabalho> LocaisTrabalho { get; set; }
        public DbSet<ProcurandoPor> ProcurandoPor { get; set; }

        public SwitchContext(DbContextOptions options) : base(options)
        {

        }
        //Aqui você personaliza o Mapeamento (sobrescreve o método)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            //Aqui está configuranto muitos para muitos invertido (PostagemConfiguration)
            modelBuilder.ApplyConfiguration(new PostagemConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioGrupoConfiguration());
            /*modelBuilder.Entity<Usuario>(entity => {
                entity.HasKey(u => u.Id);//opcional, pois já é feito por padrão
                entity.Property(u => u.Nome).HasColumnName("Nome")
                    .IsRequired()
                    .HasMaxLength(200);
                    //.HasColumnType();

            });*/

            modelBuilder.ApplyConfiguration(new AmigoConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());

            modelBuilder.ApplyConfiguration(new StatusRelacionamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ProcurandoPorConfiguration());
            //FALTOU FAZER AS CONFIGURAÇÕES ABAIXO
            modelBuilder.ApplyConfiguration(new StatusRelacionamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ProcurandoPorConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

