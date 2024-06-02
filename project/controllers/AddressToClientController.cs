using Bl;
using Bl.BlApi;
using Bl.BlImplemntion;
using Bl.BlObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressToClientController : ControllerBase
    {
        IRepoAddress AddressToClientRepo;
        public AddressToClientController(BlManger manager)
        {
            this.AddressToClientRepo = manager.addressForClientRepo;
        }
        [HttpGet]
        public ActionResult<List<AddressToClient>> GetAllAdresses()
        {
            List<AddressToClient> get = AddressToClientRepo.GetAll();
            if (get != null)
            {
                return get;
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<AddressToClient> GetByIdAdresses(int id)
        {
            AddressToClient getbyid = AddressToClientRepo.GetById(id);
            if (getbyid != null)
            {
                return getbyid;
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<AddressToClient> AddAdresses([FromForm] AddressToClient professionalsMan, [FromQuery] string street, [FromQuery] int apartment)
        {
            AddressToClient add = AddressToClientRepo.Add(professionalsMan, street, apartment);
            if (add != null)
            {
                return add;
            }
            return NotFound();
        }
        [HttpPut]
        public ActionResult<AddressToClient> UpDateAdresses([FromForm] int id, [FromForm] AddressToClient address, [FromForm] string street, [FromForm] int apartment)
        {
            AddressToClient Update = AddressToClientRepo.Update(id, address, street, apartment);
            if (Update != null)
            {
                return Update;
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult<AddressToClient> DeleteAdresses(int id)
        {
            AddressToClient delete = AddressToClientRepo.Delete(id);
            if (delete != null)
            {
                return delete;
            }
            return NotFound();
        }
    }
}
