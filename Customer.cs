using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Isabella_Grigolla
{
    public partial class Customer
    {
        public Customer()
        {

        }

        public int customerId { get; set; }
        public string customerName { get; set; }
        public Address addressId { get; set; }
        public int active { get; set; }
        public DateTime createDate { get; set; }
        public string createBy { get; set; }
        public DateTime lastUpdated { get; set; }
        public string lastUpdatedBy { get; set; }




    }

}
