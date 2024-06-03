using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Najdoktor.Model
{
    public class Specijalizacija
    {
        [Key]
        public int ID { get; set; }
        public string NazivSpecijalizacije { get; set; }
    }
}
