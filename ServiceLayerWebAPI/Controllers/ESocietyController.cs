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
    
    public class ESocietyController : ApiController
    {
        ESocietyDAL dal = new ESocietyDAL();

        [HttpGet]
        [Route("api/ESociety/{smid}")]
        public ESocietyEL Get(int smid)
        {
            return dal.SelectByID(smid);
        }

        [HttpGet]
        public IEnumerable<SocietyMemberInfo>Get()
        {
            return dal.GetAllMembers();
        }

        [HttpGet]
        [Route("api/ESociety/GetBy/{AccType}")]
        public IEnumerable<SocietyMemberInfo>GetByType([FromUri] string AccType)
        {
            return dal.GetByType(AccType);
        }

        [HttpPost]
        public string Post([FromBody] ESocietyEL el)
        {
            return dal.InsertNewMember(el);
        }

        [HttpPut]
        [Route("api/ESociety/UpdateInfo/{SMID}")]
        public string UpdateInfo([FromUri]int SMID,ESocietyEL el)
        {
            return dal.UpdateInfo(SMID,el);
        }

        [HttpDelete]
        [Route("api/ESociety/Delete/{SMID}")]
        public bool DeleteMember(int SMID)
        {
            return dal.DeleteMember(SMID);
        }
    }
}