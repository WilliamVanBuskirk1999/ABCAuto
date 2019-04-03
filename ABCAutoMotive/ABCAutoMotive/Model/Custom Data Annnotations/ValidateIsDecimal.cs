using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom_Data_Annnotations
{
    public class ValidateIsDecimal : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(decimal.TryParse(value.ToString(), out decimal i) != true)
            {
                return false;
            }
            return true;
        }
    }
}
