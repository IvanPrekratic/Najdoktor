using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Najdoktor.Model
{
    public class Pacijent
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; } 
        public string Telefon { get; set; }
        [Required]
        public string Email { get; set; }
        public string Adresa { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }
        public string ImePrezime=> $"{Ime} {Prezime}";
    }
}
