using PrimeStone.RAT.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Common.Interface
{
    public interface IStudentService
    {
        Task<List<StudentDto>> ListStudentss();
        StudentDto GetStudent(int studentId);
        int AddStudent(StudentDto student, string user);
        int UpdateStudent(StudentDto student, string user);
        int DeleteStudent(int studentoId);
    }
}
