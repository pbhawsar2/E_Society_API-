namespace DALEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessageTable
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
