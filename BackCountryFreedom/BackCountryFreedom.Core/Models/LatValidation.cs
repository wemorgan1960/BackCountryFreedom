using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackCountryFreedom.Core.Models
{
    public class LatValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Contact contact = validationContext.ObjectInstance as Contact;

            if (value!=null)
            {

            }
            return ValidationResult.Success;
        }
    }

}