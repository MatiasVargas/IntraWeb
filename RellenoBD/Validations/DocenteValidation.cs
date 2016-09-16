using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RellenoBD.Validations
{
    public class DocenteValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RellenoBD.docente)validationContext.ObjectInstance;

            var db = new BD();
            string nom = model.Nombre;
            var docente = db.docente.Where(a => a.Nombre == nom).FirstOrDefault();
            if (docente != null)
            {
                return new ValidationResult("Nombre ya existente.");
            }
            return ValidationResult.Success;
        }

    }
}