using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaApi.Models
{
    [Table("OCORRENCIA")]
    public class Ocorrencia
    {
        [Key]
        public int Id { get; set; }

        [Column("ticketnumber")]
        [Required]
        public string TicketNumber { get; set; }

        [Column("pjo_clientedaunidade")]
        [Required]
        public string PjoClienteDaUnidade { get; set; }

        [Column("pjo_empreendimentoid")]
        [Required]
        public string PjoEmpreendimentoId { get; set; }

        [Column("pjo_bloco")]
        [Required]
        public string PjoBloco { get; set; }

        [Column("pjo_unidade")]
        [Required]
        public int PjoUnidade { get; set; }

        [Column("pjo_bandeira")]
        [Required]
        public string PjoBandeira { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
