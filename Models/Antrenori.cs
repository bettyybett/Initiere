using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Initiere.Models
{
    [Table("Antrenori")]
    public class Antrenori
    {
        [Key, Column("antrenor_id")]
        public int IdAntrenori { get; set; }
        [MinLength(3, ErrorMessage = "Numele nu poate fi mai mic de 3 litere")]
        public string Nume { get; set; }
        //one to many
        public virtual ICollection<Programari> Programari { get; set; }
        //many to many
        public virtual ICollection<Client> Clnt { get; set; }
        //public ICollection<Programari> progr { get; set; }
     

    }
}