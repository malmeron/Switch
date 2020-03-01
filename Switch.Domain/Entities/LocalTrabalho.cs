using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class LocalTrabalho
    {
        public int Id { get; set; }
        public virtual int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
        public bool EmpresaAtual { get; set; }
    }
}
