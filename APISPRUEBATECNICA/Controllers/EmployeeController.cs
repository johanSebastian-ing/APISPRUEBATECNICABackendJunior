using APISPRUEBATECNICA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Xml.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISPRUEBATECNICA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext context;
        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }
        // GET: api/<EmployeeController>

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblEmployee.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


      
        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult Get(int employeeID)

        {
            try
            {
                var employee = context.tblEmployee.FirstOrDefault(g => g.employeeID == employeeID);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


     
        [HttpPost]
        public ActionResult Post([FromBody] Employee Employee)
        {
            try
            {
                context.tblEmployee.Add(Employee);
                context.SaveChanges();
                return CreatedAtRoute("GetEmployee", new { id = Employee.employeeID }, Employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{employeeID}")]
        public ActionResult Put(int employeeID, [FromBody] Employee employee)
        {
            try
            {
                if (employee.employeeID == employeeID)
                {
                    context.Entry(employee).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEmployee", new { id = employee.employeeID }, employee);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("search")]
        public ActionResult<IEnumerable<Employee>> GetByCriteria([FromBody] string strCriteria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strCriteria))
                {
                       var allEmployees = context.tblEmployee.ToList();
                    return Ok(allEmployees);
                }
                else
                {
                    var filteredEmployees = context.tblEmployee
                        .Where(e => e.Nombre.Contains(strCriteria) || e.Apellidos.Contains(strCriteria))
                        .ToList();

                    return Ok(filteredEmployees);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    }
