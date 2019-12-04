using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL;
using DAL;

namespace API.Controllers
{
    public class EmployWebApiController : ApiController
    {
        BAL.BussinessLogic calLogic = new BAL.BussinessLogic();


        [Route("")]
        public IHttpActionResult GET()
        {
            return Ok("Web API started");
        }

        [Route("api/getAllEmployee")]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(calLogic.GetAllEmployees());
        }


        [Route("api/createEmploy")]
        public IHttpActionResult createEmploy(EmployeeInfo employ)
        {
            calLogic.saveEmploy(employ);
            return Ok("saved");
        }


        [Route("api/edit/{id}")]
        public IHttpActionResult getUpdateData(int id)
        {
            return Ok(calLogic.getUpdateData(id));
        }

        [Route("api/update")]
        public IHttpActionResult PUT(EmployeeInfo info)
        {
            calLogic.updateData(info);
            return Ok();
        }

        [Route("api/delete/{id}")]
        public IHttpActionResult DELETE(int id)
        {
           
            calLogic.delete(id);
            return Ok();
        }


    }
}
