using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class Postagem
    {
        public int Id { get; set; }
        public DateTime DataPubicacao { get; set; }
        public string Texto { get; set; }
        //um para muitos
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; } //propriedade de navegação
        //muitos para muitos
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; } //propriedade de navegação

        public string UrlConteudo { get; set; }
    }
}
