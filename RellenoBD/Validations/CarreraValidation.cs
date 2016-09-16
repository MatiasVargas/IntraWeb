using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RellenoBD.Validations
{
    public class CarreraValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RellenoBD.carrera)validationContext.ObjectInstance;

            var db = new BD();
            string nom = model.Nombre;
            var carrera = db.carrera.Where(a => a.Nombre == nom).FirstOrDefault();
            if (carrera != null)
            {
                return new ValidationResult("Nombre ya existente.");
            }
            return ValidationResult.Success;
        }
    }
}