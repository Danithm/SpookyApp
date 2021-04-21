using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpookyApp.Models;
using SpookyApp.Data;
using SpookyApp.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace SpookyApp.Controllers
{
    //api/spooky
    [Route("api/spooky")]
    [ApiController]
    public class SpookyAppsController : Controller
    {
        private readonly ISpookyAppRepo _repository;
        private readonly IMapper _mapper;

        public SpookyAppsController(ISpookyAppRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/spooky
        [HttpGet]

        public ActionResult <IEnumerable<SpookyReadDto>> GetAllSpooky()
        {
            var spookyItems = _repository.GetAllSpooky();

            //Status 200 Ok return
            return Ok(_mapper.Map<IEnumerable<SpookyReadDto>>(spookyItems));
        }

        //Get api/spooky/{id}
        [HttpGet("{id}", Name ="GetSpookyById")]

        public ActionResult <SpookyReadDto> GetSpookyById(int id)
        {
            var spookyItem = _repository.GetSpookyById(id);
            if(spookyItem != null)
            {
                return Ok(_mapper.Map<SpookyReadDto>(spookyItem));
            }
            return NotFound();
        }

        //Post api/spooky
        //Todo: add validation
        [HttpPost]

        public ActionResult<SpookyReadDto> CreateSpooky(SpookyCreateDto spookyCreateDto)
        {
            var spookyModel = _mapper.Map<Spooky>(spookyCreateDto);
            _repository.CreateSpooky(spookyModel);
            _repository.SaveChanges();

            var spookyReadDto = _mapper.Map<SpookyReadDto>(spookyModel);

            return CreatedAtRoute(nameof(GetSpookyById), new { Id = spookyReadDto.Id }, spookyReadDto);
        }

        //Put api/spooky/{id}
        [HttpPut("{id}")]

        public ActionResult UpdateSpooky(int id, SpookyUpdateDto spookyUpdateDto)
        {
            var spookyModelFromRepo = _repository.GetSpookyById(id);
            if(spookyModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(spookyUpdateDto, spookyModelFromRepo);

            _repository.UpdateSpooky(spookyModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/spooky/{id}
        [HttpPatch("{id}")]

        public ActionResult PartialSpookyUpdate(int id, JsonPatchDocument<SpookyUpdateDto> patchDoc)
        {
            var spookyModelFromRepo = _repository.GetSpookyById(id);
            if(spookyModelFromRepo == null)
            {
                return NotFound();
            }

            var spookyToPatch = _mapper.Map<SpookyUpdateDto>(spookyModelFromRepo);
            patchDoc.ApplyTo(spookyToPatch, ModelState);

            if (!TryValidateModel(spookyToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(spookyToPatch, spookyModelFromRepo);
            _repository.UpdateSpooky(spookyModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/spooky/{id}
        [HttpDelete]

        public ActionResult DeleteSpooky(int id)
        {
            var spookyModelFromRepo = _repository.GetSpookyById(id);
            if(spookyModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteSpooky(spookyModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
