using CyrelaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaApi.DAL
{
    public class CyrelaDBDataContext : DbContext
    {
        public CyrelaDBDataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AtividadeAgendada> AtividadeAgendada { get; set; }
        public virtual DbSet<Ocorrencia> Ocorrencia { get; set; }
    }
}
