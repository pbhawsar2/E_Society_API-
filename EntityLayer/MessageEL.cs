using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntityLayer
{
    public class MessageEL
    {
        public int MsgID { get; set; }
        public int SMID { get; set; }
        public string Name { get; set; }
        public string AccountType { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
        public string DateTime { get; set; }
    }
}
