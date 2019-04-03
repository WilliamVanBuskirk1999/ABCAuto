using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model.Custom_Data_Annnotations
{
    internal class ValidatePhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string regex = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            var match = Regex.Match(value.ToString(), regex);

            if (!match.Success)
            {
                return false;
            }
            return true;
        }
    }
}
