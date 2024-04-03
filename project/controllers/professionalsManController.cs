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
        public ActionResult<ProfessionalsManToclients> AddProfessionalsMan(ProfessionalsManToclients professionalsMan)
        {
            ProfessionalsManToclients add = professionalsManRepo.Add(professionalsMan);
            if (add != null)
            {
                return add;
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult<ProfessionalsManToclients> UpDateProfessionalsMan(int id, ProfessionalsManToclients professionalsMan)
        {
            ProfessionalsManToclients Update =  professionalsManRepo.Update(id, professionalsMan);
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
