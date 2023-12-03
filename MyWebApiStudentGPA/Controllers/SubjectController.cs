using DL.DbModels;
using Microsoft.AspNetCore.Mvc;
using MyWebApiStudentGPA.Interfaces;

[ApiController]
[Route("api/subject")]
public class SubjectController : ControllerBase
{
    private readonly IStudentClass _studentClass;

    public SubjectController(IStudentClass studentClass)
    {
        _studentClass = studentClass;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(StudentDbDto student)
    {
        var res = await _studentClass.CreateStudent(student);
        return Ok(res);
    }

    [HttpPut("{student_id}")]
    public async Task<IActionResult> EditStudent(int student_id, StudentDbDto updatedStudent)
    {
        var existingStudent = await _studentClass.UpdateStudent(student_id, updatedStudent);

        if (existingStudent == null)
            return NotFound("Student not found");
        else
            return Ok(existingStudent);
    }

    [HttpDelete("{student_id}")]
    public async Task<IActionResult> DeleteStudent(int student_id)
    {
        var student = await _studentClass.DeleteStudent(student_id);

        if (student == null)
        {
            return NotFound("Student not found");
        }
        return Ok(student);
    }

    [HttpGet("{student_id}")]
    public async Task<IActionResult> GetStudent(int student_id)
    {
        var student = await _studentClass.GetStudentById(student_id);

        if (student == null)
        {
            return NotFound("Student not found");
        }
        return Ok(student);
    }

    [HttpGet("{subjects_id}")]
    public async Task<IActionResult> GetAllSubjects()
    {
        var students = await _studentClass.GetAllStudents();
        return Ok(students);
    }
}
