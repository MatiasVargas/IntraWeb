using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RellenoBD.Validations
{
    public class JefeCarreraValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RellenoBD.jefecarrera)validationContext.ObjectInstance;

            var db = new BD();
            string nom = model.Nombre;
            var jefecarrera = db.jefecarrera.Where(a => a.Nombre == nom).FirstOrDefault();
            if (jefecarrera != null)
            {
                return new ValidationResult("Nombre ya existente.");
            }
            return ValidationResult.Success;
        }
    }
}