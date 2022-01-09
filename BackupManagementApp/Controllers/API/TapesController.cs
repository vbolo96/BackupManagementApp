using BackupManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BackupManagementApp.Dtos;
using System.Data.Entity;

namespace BackupManagementApp.Controllers.API
{
    public class TapesController : ApiController
    {
        public ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TapesController(IMapper mapper)
        {
            _context = new ApplicationDbContext();
            _mapper = mapper;
        }
        // GET api/tapes
        public IHttpActionResult GetTapes()
        {
            var tapesDto = _context.Tapes
                .Include(t=>t.BackupSystem)
                .Include(t=>t.BackupTypes)
                .ToList()
                .Select(_mapper.Map<Tape,TapeDto>);
            return Ok(tapesDto);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetTape(int id)
        {
            var tape = _context.Tapes
                 .Include(t => t.BackupSystem)
                .Include(t => t.BackupTypes)
                .SingleOrDefault(t => t.Id == id);

            if (tape == null)
                return NotFound();
            return Ok(_mapper.Map<Tape, TapeDto>(tape));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageTapes)]
        public IHttpActionResult CreateTape(TapeDto tapeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var tape = _mapper.Map<TapeDto, Tape>(tapeDto);
            _context.Tapes.Add(tape);
            _context.SaveChanges();
            tapeDto.Id = tape.Id;
            return Created(new Uri(Request.RequestUri + "/" + tape.Id), tapeDto);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageTapes)]
        public IHttpActionResult UpdateTape(int id, TapeDto tapeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var tapeInDb = _context.Tapes.SingleOrDefault(c => c.Id == id);
            if (tapeInDb == null)
                return NotFound();
            _mapper.Map(tapeDto, tapeInDb);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageTapes)]
        public IHttpActionResult DeleteTape(int id)
        {
            var tapeInDb = _context.Tapes.SingleOrDefault(c => c.Id == id);
            if (tapeInDb == null)
                return NotFound();
            _context.Tapes.Remove(tapeInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}