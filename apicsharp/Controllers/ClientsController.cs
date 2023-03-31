using apicsharp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apicsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        // GET: api/<ClientsController>
        [HttpGet]
        public List<Clients> Get()
        {
            List<Clients> clients = ClientDB.GetClients();

            return clients;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public List<Clients> Get(int id)
        {
            List<Clients> clients = ClientDB.GetClients().Where(c => c.Id == id).ToList() ;
            return clients;

        }

        [HttpDelete]
        public void Delete(string id)
        {
            ClientDB.DeleteClient(id);

        }

        [HttpPut]
        public void Put(Clients obj) 
        {

            ClientDB.UpdateClient(obj);
        }




    }
}
