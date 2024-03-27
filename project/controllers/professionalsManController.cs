using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class professionalsManController : ControllerBase
    {
        IRepo<ProfessionalsMan> professionalsManRepo;
        public professionalsManController( IRepo<ProfessionalsMan> professionalsManRepo)
        {
            this.professionalsManRepo = professionalsManRepo;
        }
        [HttpGet]
        public ActionResult<List<ProfessionalsMan>> GetAllProfessionalsMan()
        {
            List<ProfessionalsMan> get = professionalsManRepo.GetAll();
            if (get != null)
            {
                return get;
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<ProfessionalsMan> GetByIdProfessionalsMan(int id)
        {
            ProfessionalsMan getbyid = professionalsManRepo.GetById(id);
            if (getbyid != null)
            {
                return getbyid;
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<ProfessionalsMan> AddProfessionalsMan(ProfessionalsMan professionalsMan)
        {
            ProfessionalsMan add = professionalsManRepo.Add(professionalsMan);
            if (add != null)
            {
                return add;
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult<ProfessionalsMan> UpDateProfessionalsMan(int id, ProfessionalsMan professionalsMan)
        {
            ProfessionalsMan Update =  professionalsManRepo.Update(id, professionalsMan);
            if (Update != null)
            {
                return Update;
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult<ProfessionalsMan> DeleteProfessionalsMan(int id)
        {
            ProfessionalsMan delete = professionalsManRepo.Delete(id);
            if (delete != null)
            {
                return delete;
            }
            return NotFound();
        }
    }
}
