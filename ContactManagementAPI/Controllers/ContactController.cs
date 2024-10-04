using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContactManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IEmployee _iEmployee;
        public ContactController(IEmployee iEmployee)
        {
            _iEmployee = iEmployee;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _iEmployee.Get();
                if (data.Any())
                {
                    return Ok(data);
                }
                else
                {
                    return Ok(new List<Contact>());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Insert(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var isInserted = _iEmployee.Create(contact);
                return Ok(isInserted);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }                
        }

        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var isUpdated = _iEmployee.Update(contact);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }            
        }

        [HttpDelete]
        public IActionResult Delete([Required] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var isDeleted = _iEmployee.Delete(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
