using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Najdoktor.Model
{
    public class Bolnica
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }

    }
}
