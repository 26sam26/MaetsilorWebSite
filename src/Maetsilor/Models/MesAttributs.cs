using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models
{
    public class TypeFichierAttribute:ValidationAttribute
    {
        public List<string> Types { get; set; }
        public TypeFichierAttribute(List<string> types)
        {
            Types = types;
        }
        public TypeFichierAttribute()
        {

        }

        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            IFormFile fichier = value as IFormFile;
            if(fichier != null)
            {
                foreach (string s in Types) s.ToUpper();

                if (Types.Contains(fichier.ContentType))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Fichier Non Valide");
            //return base.IsValid(value,validationContext);
        }
    }
}
