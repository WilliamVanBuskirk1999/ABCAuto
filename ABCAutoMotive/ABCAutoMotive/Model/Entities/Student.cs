using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Types;
using Model.Custom_Data_Annnotations;

namespace Model
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage ="The first name may not be longer than 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30,ErrorMessage ="The last name may not be longer than 30 characters")]
        public string LastName { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="T")]
        public StudentStatus Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

 
        public DateTime EndDate { get; set; }

        [Required]
        public decimal AmountDue { get; set; }

        [Required]
        public ProgramOptions Program { get; set; }

        [Required]
        [StringLength(30,ErrorMessage ="Address May not be greater than 30 characters")]
        public string Address { get; set; }

        [Required]
        [StringLength(30,ErrorMessage ="City may not be greater than 30 characters")]
        public string City { get; set; }

        [Required]
        [StringLength(30,ErrorMessage ="Postal code may not be greater than 10 characters")]
        [ValidatePostalCode(ErrorMessage ="Invalid postal code. Please try again")]
        public string PostalCode { get; set; }

        [Required]
        [ValidatePhoneNumber(ErrorMessage ="Invalid phone number. Please try again")]
        public string TelephoneNumber { get; set; }





    }
}
