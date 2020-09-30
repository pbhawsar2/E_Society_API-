using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace IDatabase
{
    public interface IESocietyDALBAL
    {
        ESocietyEL SelectByID(int smid);
        string InsertNewMember(ESocietyEL el);
        string UpdateInfo(int SMID,ESocietyEL el);
        bool DeleteMember(int SMID);
        //IEnumerable<ESocietyEL> GetAllMembers();
    }
}
