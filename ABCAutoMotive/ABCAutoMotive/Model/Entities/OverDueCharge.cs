using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Model.Entities
{
    public class OverDueCharge
    {
        public string ResourceDescription { get; set; }

        public ResourceType ResourceType { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public decimal Price { get; set; }

        public int ResourceId { get; set; }
    }
}
