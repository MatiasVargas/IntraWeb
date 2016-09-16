using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RellenoBD.Validations
{
    public class PagoValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RellenoBD.pago)validationContext.ObjectInstance;

            var db = new BD();
            string nom = model.Estado;
            if (nom != "Pagado" && nom != "Deuda" )
            {
                return new ValidationResult("Ingrese valores como se muestra en el ejemplo.");
            }
            return ValidationResult.Success;
        }
    }
}