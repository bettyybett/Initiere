using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Initiere.Models
{
    
    public class Client
    {
        [Key, Column("client_id")]
        
        public int IdClient { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Numele nu poate fi mai mic de 3 litere")]
        public string Nume { get; set; }
       // [RegularExpression(@"^(?i)(true|false)$")]
       // public bool AreCont { get; set; }
        //[Required]
        //public int ContId { get; set; }
        //one to one
        public virtual Cont Cont { get; set; }
        //many-to one
        public virtual ICollection<Programari> Programari { get; set; }
        //many to many
       // public virtual ICollection<Antrenori> Antr { get; set; }
        

    }
}