using CyrelaApi.DAL;
using CyrelaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyrelaApi.Controllers
{
    [Route("ocorrencias")]
    [ApiController]
    public class OcorrenciasController : ControllerBase
    {
        private readonly CyrelaDBDataContext _context;
        private readonly ILogger<OcorrenciasController> _logger;
        public OcorrenciasController(ILogger<OcorrenciasController> logger, CyrelaDBDataContext repository)
        {
            _logger = logger;
            _context = repository;
        }
        // GET: <AtividadesAgendadasController>
        [HttpGet]
        public ActionResult<IEnumerable<Ocorrencia>> Get()
        {
            var list = new List<Ocorrencia>();
            try
            {
                list = _context.Ocorrencia.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Get", ex);
            }

            return list;
        }

        // GET <AtividadesAgendadasController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Ocorrencia> Get(int id)
        {
            try
            {
                var entity = _context.Ocorrencia.FirstOrDefault(x => x.Id == id);
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
        public ActionResult<Ocorrencia> Post([FromBody] Ocorrencia value)
        {
            try
            {
                _context.Ocorrencia.Add(value);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
            }
            catch (Exception ex)
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
        public ActionResult<Ocorrencia> Put(int id, [FromBody] Ocorrencia value)
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
                var entity = _context.Ocorrencia.FirstOrDefault(x => x.Id == id);
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
