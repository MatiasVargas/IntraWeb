using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RellenoBD.Validations
{
    public class AsignaturaValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RellenoBD.asignatura)validationContext.ObjectInstance;

            var db = new BD();
            string nom = model.Nombre;
            var asignatura = db.asignatura.Where(a => a.Nombre == nom).FirstOrDefault();
            if (asignatura != null)
            {
                return new ValidationResult("Nombre ya existente.");
            }
            return ValidationResult.Success;
        }
    }
}

