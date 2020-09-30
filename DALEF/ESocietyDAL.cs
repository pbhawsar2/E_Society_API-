using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using EntityLayer;
using IDatabase;

namespace DALEF
{
    public class ESocietyDAL : IESocietyDALBAL
    {
        ESocietyDBEntities db = new ESocietyDBEntities();

        public ESocietyEL SelectByID(int smid)
        {
            ESocietyEL el = new ESocietyEL();
            try
            {
                var res = db.SocietyMemberInfoes.Where(x => x.SMID == smid).SingleOrDefault();
                if (res == null)
                {
                    return null;
                }
                else
                {
                    el.SMID = res.SMID;
                    el.Password = res.Password;
                    el.Name = res.Name;
                    el.Address = res.Address;
                    el.Email = res.Email;
                    el.ContactNumber = res.ContactNumber;
                    el.AccountType = res.AccountType;
                    el.HouseNo = res.HouseNo;
                    el.BusinessName = res.BusinessName;
                    el.Rent = res.Rent;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return el;
        }
        public string GetSMID(long ContactNo)
        {
           var res = db.SocietyMemberInfoes.Where(x => x.ContactNumber == ContactNo).SingleOrDefault();
           return res.SMID.ToString();
        }

        public string InsertNewMember(ESocietyEL el)
        {
            try
            {
                SocietyMemberInfo newrow = new SocietyMemberInfo();
                newrow.Password = Membership.GeneratePassword(8, 0);
                newrow.Name = el.Name;
                newrow.Address = el.Address;
                newrow.Email = el.Email;
                newrow.ContactNumber = el.ContactNumber;
                newrow.AccountType = el.AccountType;
                newrow.HouseNo = el.HouseNo;
                newrow.BusinessName = el.BusinessName;
                newrow.Rent = el.Rent;
                db.SocietyMemberInfoes.Add(newrow);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    string s = GetSMID(newrow.ContactNumber);
                    return "SMID : "+ s +" Password : "+newrow.Password;
                }
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Member not inserted";
        }

        public string UpdateInfo(int SMID,ESocietyEL el)
        {
            try
            {
               var res = db.SocietyMemberInfoes.Where(x => x.SMID == SMID).SingleOrDefault();
                 if (res == null)
                 {
                   return "Invalid SMID";
                 }
                 if(res.Password != el.Password && el.Password != null)
                 {
                   res.Password = el.Password;
                   var op = db.SaveChanges();
                   if (op > 0)
                    return "Password Updated";
                 }
                 else
                 {
                    res.Name = el.Name;
                    res.Address = el.Address;
                    res.Email = el.Email;
                    res.ContactNumber = el.ContactNumber;
                    res.AccountType = el.AccountType;
                    res.HouseNo = el.HouseNo;
                    res.BusinessName = el.BusinessName;
                    res.Rent = el.Rent;
                    var op = db.SaveChanges();
                    if (op > 0)
                     return "Information Updated";
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Information not Updated";
        }
        public IEnumerable<SocietyMemberInfo>GetByType(string AccType)
        {
            try
            {
                 var res = db.SocietyMemberInfoes.Where(x => x.AccountType == AccType).ToList();
                 return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<SocietyMemberInfo> GetAllMembers()
        {
            
            try
            {
                return db.SocietyMemberInfoes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteMember(int SMID)
        {
            var data = db.SocietyMemberInfoes.Where(x => x.SMID == SMID).SingleOrDefault();
            if (data == null)
                return false;
            else
            {
                db.SocietyMemberInfoes.Remove(data);
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            return false;
        }
    }
}
