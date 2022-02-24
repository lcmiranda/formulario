using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace formulario.Models
{
    [Table("TABEL_HORARIO")]
    public class TabelaHorario
    {
        [Key]
        public int id { get; set; }

        public int id_forms { get; set; }

        public string dia { get; set; }

        public string h_inicio { get; set; }

        public string h_fim { get; set; }

        public string h_descanso { get; set; }

        public int carga_h { get; set; }
    }
}
