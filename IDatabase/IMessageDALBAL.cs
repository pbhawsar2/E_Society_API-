using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace IDatabase
{
    public interface IMessageDALBAL
    {
        string InsertMessage(MessageEL Mel);

        // IEnumerable<MessageEL> GetMyMessage(int SMID);

       // IEnumerable<MessageEL> GetAllMessage();

        bool DeleteMessages(int SMID);
    }
}
