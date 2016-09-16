using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RellenoBD.Validations
{
    public class RUTValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RellenoBD.alumno)validationContext.ObjectInstance;

            if (model.Rut == null)
            {
                return new ValidationResult("RUT es requerido.");
            }
            var rutStr = model.Rut;
            rutStr = rutStr.ToUpper();
            rutStr = rutStr.Replace(".", "");

            string []arrRut = rutStr.Split('-');
            if(arrRut.Length != 2)
            {
                return new ValidationResult("RUT debe contener un guión.");
            }

            try
            {
                string rutStr0 = arrRut[0];
                int rut = Convert.ToInt32(rutStr0);

                


                string dvStr = arrRut[1];
                int dv = -1;
                try
                {
                    dv = Convert.ToInt16(dvStr);
                }
                catch (Exception)
                {
                    if(dvStr.ToUpper() != "K")
                    {
                        return new ValidationResult("El guión debe ser numérico o una K.");
                    }
                }
                var db = new BD();
                string rutAl = rut + "-" + dv;
                var alumno = db.alumno.Where(a => a.Rut == rutAl).FirstOrDefault();
                if (alumno != null)
                {
                    return new ValidationResult("RUT ya existente.");
                }

                var validado = false;
                if(digitoVerificador(rut)== dv+"")
                {
                    validado = true;
                }
                if (!validado)
                {
                    return new ValidationResult("El RUT no es válido.");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Error: El RUT debe contener sólo números antes del guión.");
            }
            return ValidationResult.Success;
        }

        private string digitoVerificador(int rut)
        {
            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;
            string RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }

            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }
            return (RutDigito);
        }

    }
}