using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Data;

using Microsoft.AspNetCore.Mvc;
using Models;

namespace Assignment2API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonsController : ControllerBase
    {
        
       
            private IAddPersonService AddPersonService;
        
            public PersonsController(IAddPersonService AddPersonService)
            {
                this.AddPersonService = AddPersonService;
            }

            [HttpGet]
            public async Task<ActionResult<IList<Person>>> GetPeople(){
                try
                {
                    IList<Person> people = await AddPersonService.GetPersonsAsync();
                    return Ok(people);
                } catch (Exception e) {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult> DeletePerson([FromRoute] int id) {
                try
                {
                    await AddPersonService.RemovePersonAsync(id);
                    return Ok();
                } catch (Exception e) {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Person>> AddPerson([FromBody] Person person) {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    await AddPersonService.AddPersonAsync(person);
                    return Ok();
                } catch (Exception e) {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPatch]
            [Route("{id:int}")]
            public async Task<ActionResult<Person>> UpdatePerson([FromBody] Person person) {
                try
                {
                    await AddPersonService.UpdatePersonAsync(person);
                    return Ok(); 
                } catch (Exception e) {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }
            
            
            
        }
    }
