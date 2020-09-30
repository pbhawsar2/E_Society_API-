using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityLayer;
using DALEF;
using System.Web.Http.Cors;

namespace ServiceLayerWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessageController : ApiController
    {
        MessageDAL mdal = new MessageDAL();

        [HttpGet]
        public IEnumerable<MessageTable> GetAllMessages()
        {
            return mdal.GetAllMessages();
        }

        [HttpGet]
        [Route("api/Message/{SMID}")]
        public IEnumerable<MessageTable> GetMyMessages(int SMID)
        {
            return mdal.GetMyMessages(SMID);
        }

        [HttpGet]
        [Route("api/Message/GetBy/{AccType}")]
        public IEnumerable<MessageTable> GetByType([FromUri] string AccType)
        {
            return mdal.GetByType(AccType);
        }

        [HttpPost]
        public string InsertMessage(MessageEL Mel)
        {
            return mdal.InsertMessage(Mel);
        }

        [HttpDelete]
        [Route("api/Message/DeleteMessage/{SMID}")]
        public bool DeleteMessages([FromUri]int SMID)
        {
            return mdal.DeleteMessages(SMID);
        }
    }
}
