using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using formulario.Models;

namespace formulario.Data
{
    public class Context : DbContext
    {
        public DbSet<BaseForms> formulario { get; set; }
        public DbSet<TabelaHorario> tabHora { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }
    }
}
