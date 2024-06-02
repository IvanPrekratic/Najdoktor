using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najdoktor.Model
{
    public class Grad
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
