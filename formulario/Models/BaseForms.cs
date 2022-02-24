using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace formulario.Models
{
    [Table("FORMULARIO")]
    public class BaseForms
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string habilitado { get; set; }

        public string categoria { get; set; }

        public string linguaEs { get; set; }

        public string cep { get; set; }

        public string estado { get; set; }

        public string cidade { get; set; }

        public string bairro { get; set; }

        public string logradouro { get; set; }

        public string end_num { get; set; }

        public string complemento { get; set; }

        public string cargo { get; set; }

        public string salarioProp { get; set; }

        [NotMapped]
        public int idSeg { get; set; }

        [NotMapped]
        public string segunda { get; set; }

        [NotMapped]
        public string segundaIni { get; set; }
        [NotMapped]

        public string segundaFim { get; set; }
        [NotMapped]

        public string segundaDec { get; set; }
        [NotMapped]
        public int segundaCarga { get; set; }

        [NotMapped]
        public int idTer { get; set; }

        [NotMapped]
        public string terca { get; set; }

        [NotMapped]
        public string tercaIni { get; set; }
        [NotMapped]

        public string tercaFim { get; set; }
        [NotMapped]

        public string tercaDec { get; set; }
        [NotMapped]
        public int tercaCarga { get; set; }

        [NotMapped]
        public int idQuart { get; set; }

        [NotMapped]
        public string quarta { get; set; }

        [NotMapped]
        public string quartaIni { get; set; }
        [NotMapped]

        public string quartaFim { get; set; }
        [NotMapped]

        public string quartaDec { get; set; }
        [NotMapped]
        public int quartaCarga { get; set; }

        [NotMapped]
        public int idQuint { get; set; }

        [NotMapped]
        public string quinta { get; set; }

        [NotMapped]
        public string quintaIni { get; set; }
        [NotMapped]

        public string quintaFim { get; set; }
        [NotMapped]

        public string quintaDec { get; set; }
        [NotMapped]
        public int quintaCarga { get; set; }

        [NotMapped]
        public int idSext { get; set; }

        [NotMapped]
        public string sexta { get; set; }

        [NotMapped]
        public string sextaIni { get; set; }
        [NotMapped]

        public string sextaFim { get; set; }
        [NotMapped]

        public string sextaDec { get; set; }
        [NotMapped]
        public int sextaCarga { get; set; }
    }
}
