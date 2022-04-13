using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDb_API_demo.Models;
using MongoDb_API_demo.Services;

namespace MongoDb_API_demo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _studentService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _studentService.GetById(id));
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Student student)
    {
        return Ok(await _studentService.Add(student));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Student student)
    {
        return Ok(await _studentService.Update(student));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return Ok(await _studentService.Delete(id));
    }
}
