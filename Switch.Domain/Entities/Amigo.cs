using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class Amigo //Essa classe só existe para mostrar o relacionamento entre uma pessao e outra
    {
        //public virtual int UsuarioId { get; set; }
        //public virtual Usuario Usuario { get; set; }
        //public int UsuarioAmigoId { get; set; }
        //public virtual Usuario UsuarioAmigo { get; set; }

        /*public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; } //propriedade de navegação

        public int UsuarioAmigoId { get; set; }
        public virtual Usuario UsuarioAmigo { get; set; } //propriedade de navegação*/
        //public class Amigo
        //{
            public virtual int UsuarioId { get; set; }
            public virtual Usuario Usuario { get; set; }
            public int UsuarioAmigoId { get; set; }
            public virtual Usuario UsuarioAmigo { get; set; }
        //}
    }
}
