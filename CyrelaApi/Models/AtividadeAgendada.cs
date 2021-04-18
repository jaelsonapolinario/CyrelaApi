using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaApi.Models
{
    [Table("ATIVIDADE_AGENDADA")]
    public class AtividadeAgendada
    {
        [Key]
        public int Id { get; set; }

        [Column("actualstart")]

        public DateTime? ActualStart { get; set; }

        [Column("actualend")]
        public DateTime? ActualEnd { get; set; }

        [Column("pjo_tipodeatividade")]
        [Required]
        public string PjoTipoDeAtividade { get; set; }
        public string Subject { get; set; }

        [Column("pjo_empreendimentoid")]
        [Required]
        public string PjoEmpreendimentoId { get; set; }

        [Column("pjo_blocoid")]
        [Required]
        public string PjoBlocoId { get; set; }

        [Column("pjo_unidadeid")]
        [Required]
        public int PjoUnidadeId { get; set; }

    }
}
