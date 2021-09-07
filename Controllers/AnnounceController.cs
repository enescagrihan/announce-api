using Microsoft.AspNetCore.Mvc;
using PublicAnnounceV2.Data.Models;
using PublicAnnounceV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PublicAnnounceV2.Controllers
{
    [Route("")]
    [ApiController]
    public class AnnounceController : ControllerBase
    {
        private readonly IDataService _dataService;
        

        public AnnounceController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<AnnounceController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //return _dataService.getAllAnnounces();
                var announces = _dataService.getAllAnnounces();
                return Ok(announces);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AnnounceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //return _dataService.GetAnnounceById(id);
                var announce = _dataService.GetAnnounceById(id);
                return Ok(announce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AnnounceController>
        [HttpPost]
        public IActionResult Post([FromBody] Announce announce)
        {
            try
            {
                _dataService.AnnounceTableInsert(announce);
                return Ok(announce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AnnounceController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Announce announce)
        {
            try
            {
                _dataService.AnnounceTableUpdate(announce);
                return Ok(announce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AnnounceController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
