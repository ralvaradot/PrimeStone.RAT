using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrimeStone.RAT.Common.Interface;
using PrimeStone.RAT.DAL;
using PrimeStone.RAT.Dtos;
using PrimeStone.RAT.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Common.Implement
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        readonly PrimeStoneDbContext context = new PrimeStoneDbContext();

        public StudentService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDto>();
                cfg.CreateMap<StudentDto, Student>();
            });
            _mapper = config.CreateMapper();
        }

        public int AddStudent(StudentDto student, string user)
        {
            var entity = _mapper.Map<Student>(student);

            context.Students.Add(entity);
            return context.SaveChanges();
        }

        public int DeleteStudent(int studentId)
        {
            var entity = context.Students.Where(c => c.StudentId == studentId).FirstOrDefault();
            if (entity == null)
                return -1;

            context.Students.Remove(entity);
            return context.SaveChanges();
        }

        public StudentDto GetStudent(int studentId)
        {
            var student = context.Students.Where(c => c.StudentId == studentId).FirstOrDefault();
            if (student == null)
                return new StudentDto();

            var entity = _mapper.Map<StudentDto>(student);
            return entity;
        }

        public async Task<List<StudentDto>> ListStudentss()
        {
            var lista = _mapper.Map<List<StudentDto>>(await context.Students.ToListAsync());
            return lista;
        }

        public int UpdateStudent(StudentDto student, string user)
        {
            var entity = _mapper.Map<Student>(student);
            context.Students.Update(entity);
            return context.SaveChanges();
        }
    }
}
