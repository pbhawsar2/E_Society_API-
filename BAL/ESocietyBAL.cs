using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;
using EntityLayer;
using IDatabase;
using DALEF;

namespace BAL
{
    public class ESocietyBAL : IESocietyDALBAL
    {
        ESocietyDAL dal = new ESocietyDAL();
        public ESocietyEL SelectByID(int smid)
        {
            return SelectByID(smid);
        }

        public bool InsertNewMember(ESocietyEL el)
        {
            bool result = ValidationRegistration(el);
            if (result)
            {
                return dal.InsertNewMember(el);
            }
             return false;
        }

        public string UpdatePassword(int SMID,string NewPassword)
        {
            return UpdatePassword(SMID,NewPassword);
        }
        private bool ValidationRegistration(ESocietyEL rd)
        {
            Regex emailpattern = new Regex(@"^\S+@\S+$");
            if (emailpattern.IsMatch(rd.Email))
            {

            }
            else
            {
                throw new Exception("Invalid Email Address");
            }
            Regex mobnopattern = new Regex(@"\d{10}");
            if (mobnopattern.IsMatch((rd.ContactNumber).ToString()))
            {
            }
            else
            {
               throw new Exception("Mobile No has to be 10 digits");
            }
            return true;
        }
    }
}
