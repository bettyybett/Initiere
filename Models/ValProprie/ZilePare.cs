using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
namespace Initiere.Models.ValProprie
{
    public class ZilePare:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            var prog = (Programari) validationContext.ObjectInstance; 
            int zi = prog.Zi;
            bool cond = true;
            if (zi % 2 == 1)
                { cond = false;  } 
            
            return cond? ValidationResult.Success: new ValidationResult("Aceasta nu e o zi para!"); }
    }
}