using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using DataBaseAccess;
using static Business.GettersAndSetters;
namespace SweetnSaltyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweetnSaltyAPIController : ControllerBase
    {
        private readonly IBusinessClass _businessClass;
        public SweetnSaltyAPIController(BusinessClass IBusinessClass)
        {
            this._businessClass = IBusinessClass;
        }


        [HttpPost]
        [Route("printtheflavor/{flavor}")]
        public async Task<ActionResult<Flavor>> PostFlavor(string flavor)
        {
            Flavor fvr = await this._businessClass.PrintFlavor(flavor);
            if (fvr != null)
                return Created($"http://5001/sweetnsalty/postaflavor/{fvr.flavorID}", fvr);
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("printperson/{fName}/{lName}")]
        public async Task<ActionResult<Person>> PrintPerson(string fName, string lName)
        {
            Person person = await this._businessClass.PrintPerson(fName, lName);
            if (person != null)
                return Created($"http://5001/sweetnsalty/postaperson/{person.personID}", person);
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("getperson/{fName}/{lName}")]
        public async Task<ActionResult<Person>> GetPerson(string fName, string lName)
        {
            Person person = await this._businessClass.GetPerson(fName, lName);
            if (person != null)
                return Ok(person);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("getfulllist")]
        public async Task<ActionResult<List<Flavor>>> GetAllFlavors()
        {
            List<Flavor> flavors = await this._businessClass.GetFlavors();
            if (flavors.Count > 0)
                return Ok(flavors);
            else
                return NotFound();
        }
        
        [HttpGet]
        [Route("getpersonandflavor/{PersonID}")]
        public async Task<ActionResult<Flavor>> FindPersonFlavor(int PersonID)
        {
            List<Flavor> flavors = await this._businessClass.FindPersonFlavor(PersonID);
            if (flavors != null)
                return Ok(flavors);
            else
                return NotFound();
        }
    }
}
