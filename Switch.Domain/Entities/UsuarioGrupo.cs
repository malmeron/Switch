using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class UsuarioGrupo
    {
        //Não tem chave pois é uma chave composta externa do usuário e do grupo
        //public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool EhAdministrador { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; } //propriedade de navegação

        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; } //propriedade de navegação

        //TEM QUE, OBRIGATORIAMENTE, FAZER A CONFIGURAÇÃO (UsuarioGrupoConfiguration)
        //SOMENTE POR CONVENÇÃO NÃO É SUFICIENTE!!!
    }
}
