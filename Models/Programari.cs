using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Initiere.Models.ValProprie;
namespace Initiere.Models
{
    [Table("Programari")]
    public class Programari
    {
        [Key, Column("Programari_id")]
        public int IdProgramari { get; set; }
        //[NotMapped]
        //public DateTime LoadedFromDatabase { get; set; }
        [ZilePare]
        [RegularExpression(@"^(([1-9])|([12]\d)|(3[01]))$")]
        public int Zi { get; set; }
        [RegularExpression(@"^([1-9])|(1[012])$")]
        public int Luna { get; set; }
        [RegularExpression(@"^2(\d{3})$")]
        public int An { get; set; }
        //one to many 1.0
       [ForeignKey("Antrenori")]
        public int IdAntrenori { get; set; }
        public Antrenori Antrenori { get; set; }

        [ForeignKey("Client")]
        public int IdClient { get; set; }
        //one to many 2.0
        public Client Client { get; set; }
        public IEnumerable <SelectListItem> AntrenoriList { get; set; }
        public IEnumerable<SelectListItem> ClientList { get; set; }

    }
}