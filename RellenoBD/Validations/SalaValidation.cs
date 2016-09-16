using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RellenoBD.Validations
{
    public class SalaValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RellenoBD.sala)validationContext.ObjectInstance;

            var db = new BD();
            string nom = model.Nombre;
            var sala = db.sala.Where(a => a.Nombre == nom).FirstOrDefault();
            if (sala != null)
            {
                return new ValidationResult("Nombre ya existente.");
            }
            return ValidationResult.Success;
        }
    }
}