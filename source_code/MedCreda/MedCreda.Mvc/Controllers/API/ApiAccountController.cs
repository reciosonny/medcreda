using MedCreda.Business.Interfaces;
using MedCreda.Business.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedCreda.Mvc.Controllers.API {

    public class ApiAccountController : ApiController {
        private IAccountManager _accountManager;
        public ApiAccountController(IAccountManager accountManager) {
            _accountManager = accountManager;
        }

        // GET api/<controller>
        public List<AccountViewModel> Get() {
            return _accountManager.GetAccounts();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id) {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value) {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}