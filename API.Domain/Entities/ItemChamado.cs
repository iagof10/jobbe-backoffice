using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class ItemChamado : BaseEntity
    {
        public long NroItemChamado { get; set; }
        public long NroChamado { get; set; }
        public string DescricaoItemChamado { get; set; }
        public DateTime DtAcaoItem { get; set; }
        public long NroFuncionarioJobbe { get; set; }
        public string GrupoAtuacao { get; set; }
        public long IdStatusAtividade { get; set; }
    }
}
