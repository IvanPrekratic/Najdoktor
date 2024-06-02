using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Najdoktor.Model
{
    public class Doktor
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Specijalizacija { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        [ForeignKey(nameof(Bolnica))]
        public int BolnicaID { get; set; }
        public Bolnica Bolnica { get; set; }
    }
}
