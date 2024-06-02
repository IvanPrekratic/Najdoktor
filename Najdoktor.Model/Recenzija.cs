using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Najdoktor.Model
{
    public class Recenzija
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Doktor))]
        public int DoktorID { get; set; }
        public virtual Doktor Doktor { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentID { get; set; }
        public Pacijent Pacijent { get; set; }
        [Required]
        public string Komentar { get; set; }
        [Required]
        [Range(1, 5)]
        public int Ocjena { get; set; }
    }
}
