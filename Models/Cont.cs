using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Initiere.Models.ValProprie;
namespace Initiere.Models
{
    [Table("Cont")]
    public class Cont
    {
        [ForeignKey("Client")]
        [Key, Column("cont_id")]

        public int IdCont { get; set; }
        [Required,EmailAddress]
        //[Required,RegularExpression(@"([a-zA-Z0-9]{3,})[@]([a-z]{3,})[.]com$", ErrorMessage = "Email-ul introdus este gresit!")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        //[Required,RegularExpression(@"[a-zA-Z]{3,}[0-9]$", ErrorMessage ="Parola Introdusa este gresita")]
        public string Password { get; set; }
        //one to one
        public virtual Client Client { get; set; }
    }
}