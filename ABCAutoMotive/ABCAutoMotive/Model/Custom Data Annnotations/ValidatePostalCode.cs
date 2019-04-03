using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model.Custom_Data_Annnotations
{
    internal class ValidatePostalCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //Testing the postal code
            var regex = "[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]";
            var match = Regex.Match(value.ToString(), regex);

            if (!match.Success)
            {
                return false;
            }
            return true;
        }
    }
}
