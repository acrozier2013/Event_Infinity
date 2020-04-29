using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Event_Infinity.Models;
using Event_Infinity.Data;
using Event_Infinity.Controllers;
using Event_Infinity.Migrations;
using Event_Infinity.Validators;

namespace Event_Infinity.Validators
{
    public class DateValidatorAttribute : ValidationAttribute
    {
        readonly string dateField;
        DateTime currentDate;
        DateTime EventStartDate;
        DateTime _foo;


        public DateValidatorAttribute(string dateField)
        {
            if(dateField == "EventStartDate")
            {
                this.currentDate = DateTime.Now;

            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringEventStartDate = value.ToString();
                _foo = DateTime.Parse(stringEventStartDate);
                if ((DateTime)value <= currentDate)
                {
                    return new ValidationResult("The Event Start Date cannot be in the past");
                }

               // if ((DateTime)value <= _foo)
                //{
                  //  return new ValidationResult("The Event End Date cannot be before the Event Start Date");
                //}
            }
            return ValidationResult.Success;
        }
    }
}