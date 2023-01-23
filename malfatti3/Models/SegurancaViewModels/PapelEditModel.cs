using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using malfatti.Models.Seguranca;
using Models.Sistema;

namespace malfatti.Models.SegurancaViewModels
{
    public class PapelEditModel
    {
        public Papel Papel { get; set; }
        public IEnumerable<UsuarioAdm> Membros { get; set; }
        public IEnumerable<UsuarioAdm> NaoMembros { get; set; }
    }
}