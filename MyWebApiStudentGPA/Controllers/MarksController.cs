using DL.DbModels;
using Microsoft.AspNetCore.Mvc;
using MyWebApiStudentGPA.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class MarksController : ControllerBase
{
    private readonly IStudentClass _studentClass;

    public MarksController(IStudentClass studentClass)
    {
        _studentClass = studentClass;
    }
    [HttpGet("{student_id}")]
    public async Task<IActionResult> GetMarks()
    {
        var students = await _studentClass.GetAllStudents();
        return Ok(students);
    }
    [HttpGet("{GPA}")]
    public async Task<IActionResult> GetGpa()
    {
        var students = await _studentClass.GetAllStudents();
        return Ok(students);
    }
}
