using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntityLayer
{

    public class ESocietyEL
    {
        public int SMID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long ContactNumber { get; set; }
        public string AccountType { get; set; }
        public string HouseNo { get; set; }
        public string BusinessName { get; set; }
        public long Rent { get; set; }

    }

}
