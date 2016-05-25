using MedCreda.Business.Interfaces;
using MedCreda.Business.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedCreda.WebApi.Controllers {
    [RoutePrefix("api/account")]
    public class ApiAccountController : ApiController {

        private IAccountManager _accountManager;
        public ApiAccountController(IAccountManager accountManager) {
            _accountManager = accountManager;
        }

        // GET api/<controller>
        [Route("")]
        public List<AccountViewModel> Get() {
            return _accountManager.GetAccounts();
        }
        
        [HttpPost]
        [Route("doctors/register")]
        public IHttpActionResult RegisterAsDoctor(RegisterDoctorViewModel vm) {
            return Ok(_accountManager.RegisterAsDoctor(vm));
        }

        [HttpGet]
        [Route("doctors")]
        public IHttpActionResult GetDoctors() {
            return Ok(_accountManager.GetDoctors());
        }

        [HttpPost]
        [Route("patients/register")]
        public IHttpActionResult RegisterAsPatient(RegisterPatientViewModel vm) {
            return Ok(_accountManager.RegisterAsPatient(vm));
        }

        [HttpGet]
        [Route("patients")]
        public IHttpActionResult GetPatients() {
            return Ok(_accountManager.GetPatients());
        }




    }
}