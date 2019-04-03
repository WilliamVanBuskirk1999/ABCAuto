using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Model.Entities
{
    public class Loans
    {
        public int ResourceId { get; set; }
        public int StudentId { get; set; }
        public bool OverDue { get; set; }

        public decimal OverDueCharge { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public DateTime? CheckInDate { get; set; }

        public LoanStatus LoanStatus { get; set; }

        public string Title { get; set; }

        public ResourceType Type { get; set; }

        public ResourceStatus ResourceStatus { get; set; }

        public DateTime? DateRemoved { get; set; }
    }

   
}
