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
    public class MessageDAL : IMessageDALBAL
    {
        ESocietyDBEntities db = new ESocietyDBEntities();
        public bool DeleteMessages(int SMID)
        {
            var data = db.MessageTables.Where(x => x.SMID == SMID);
            if (data == null)
                return false;
            else
            {
                foreach (var row in data)
                {
                   db.MessageTables.Remove(row);
                }
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            return false;
        }

        public IEnumerable<MessageTable> GetAllMessages()
        {
            try
            {
                return db.MessageTables.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MessageTable> GetMyMessages(int SMID)
        {
            try
            {
                var res = db.MessageTables.Where(x => x.SMID == SMID).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MessageTable> GetByType(string AccType)
        {
            try
            {
                var res = db.MessageTables.Where(x => x.AccountType == AccType).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertMessage(MessageEL Mel)
        {
            try
            {
                MessageTable newrow = new MessageTable();
                newrow.SMID = Mel.SMID;
                newrow.Name = Mel.Name;
                newrow.AccountType = Mel.AccountType;
                newrow.MessageTitle = Mel.MessageTitle;
                newrow.Message = Mel.Message;
                newrow.DateTime = DateTime.Now.ToString();
                db.MessageTables.Add(newrow);
                var res = db.SaveChanges();
                if (res > 0)
                    return "Message sent.";
                else
                    return "Message not sent.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
