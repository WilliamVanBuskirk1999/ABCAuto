using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Types;
using Model.Custom_Data_Annnotations;

namespace Model.Entities
{
    public class Resource
    {
        [Required]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="The name cannot be more than 50 characters")]
        public string Title { get; set; }
        public ResourceStatus ResourceStatus {get;set;}
        public int Stock { get; set; }
        public ResourceType Type { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? CheckOutDate { get; set; }

        [Required]
        public string Image { get; set; }

        public DateTime? DueDate { get; set; }
        public PublisherReferenceNum? PublisherReferenceNumber { get; set; }
        public ReserveStatus ReserveStatus { get; set; }
        public int? StudentId { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? DateRemoved { get; set; }

        [Required]
        [ValidateIsDecimal(ErrorMessage ="Please enter a correct decimal value for price")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage ="The publishers name cannot be more than 40 characters")]
        public string Publisher { get; set; }





    }
}
