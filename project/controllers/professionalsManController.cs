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
    public class professionalsManController : ControllerBase
    {
        IProfessionalsManToclientsRepo professionalsManRepo;
        public professionalsManController(BlManger blManger)
        {
            this.professionalsManRepo = blManger.professionalsManToclientsRepo;
        }
        [HttpGet]
        public ActionResult<List<ProfessionalsManToclients>> GetAllProfessionalsMan()
        {
            List<ProfessionalsManToclients> get = professionalsManRepo.GetAll();
            if (get != null)
            {
                return get;
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<ProfessionalsManToclients> GetByIdProfessionalsMan(int id)
        {
            ProfessionalsManToclients getbyid = professionalsManRepo.GetById(id);
            if (getbyid != null)
            {
                return getbyid;
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<ProfessionalsManToclients> AddProfessionalsMan(ProfessionalsManToclients t, AddressToClient address, int appartment, string street, string typeProfession)
        {
            ProfessionalsManToclients add = professionalsManRepo.Add( t,  address,  appartment,  street,  typeProfession);
            if (add != null)
            {
                return add;
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult<ProfessionalsManToclients> UpDateProfessionalsMan(ProfessionalsManToclients t, string street, int building)
        {
            ProfessionalsManToclients Update =  professionalsManRepo.Update( t,  street,  building);
            if (Update != null)
            {
                return Update;
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult<ProfessionalsManToclients> DeleteProfessionalsMan(int id)
        {
            ProfessionalsManToclients delete = professionalsManRepo.Delete(id);
            if (delete != null)
            {
                return delete;
            }
            return NotFound();
        }
    }
}
