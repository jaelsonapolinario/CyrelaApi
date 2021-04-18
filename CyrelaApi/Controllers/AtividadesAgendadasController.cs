using CyrelaApi.DAL;
using CyrelaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyrelaApi.Controllers
{
    [Route("atividades-agendadas")]
    [ApiController]
    public class AtividadesAgendadasController : ControllerBase
    {
        private readonly CyrelaDBDataContext _context;
        private readonly ILogger<AtividadesAgendadasController> _logger;
        public AtividadesAgendadasController(ILogger<AtividadesAgendadasController> logger, CyrelaDBDataContext repository)
        {
            _logger = logger;
            _context = repository;
        }
        // GET: <AtividadesAgendadasController>
        [HttpGet]
        public ActionResult<IEnumerable<AtividadeAgendada>> Get()
        {
            var list = new List<AtividadeAgendada>();
            try
            {
                list = _context.AtividadeAgendada.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Get", ex);
            }

            return list;
        }

        // GET <AtividadesAgendadasController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AtividadeAgendada> Get(int id)
        {
            try
            {
                var entity = _context.AtividadeAgendada.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                    return entity;
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("GetId", ex);
                return BadRequest();
            }
        }

        // POST <AtividadesAgendadasController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AtividadeAgendada> Post([FromBody] AtividadeAgendada value)
        {
            try
            {
                _context.AtividadeAgendada.Add(value);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
            }
            catch(Exception ex)
            {
                _logger.LogError("Post", ex);
                return BadRequest();
            }
        }

        // PUT <AtividadesAgendadasController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AtividadeAgendada> Put(int id, [FromBody] AtividadeAgendada value)
        {
            try
            {
                value.Id = id;
                _context.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError("Put", ex);
                return BadRequest();
            }
        }

        // DELETE <AtividadesAgendadasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var entity = _context.AtividadeAgendada.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete", ex);
            }
        }
    }
}
