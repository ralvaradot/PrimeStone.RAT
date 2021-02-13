using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrimeStone.RAT.Common.Interface;
using PrimeStone.RAT.DAL;
using PrimeStone.RAT.Dtos;
using PrimeStone.RAT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Common.Implement
{
    public class CursoService : ICursoService
    {
        private readonly IMapper _mapper;
        readonly PrimeStoneDbContext context = new PrimeStoneDbContext();

        public CursoService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Curso, CursoDto>();
                cfg.CreateMap<CursoDto, Curso>();
            });
            _mapper = config.CreateMapper();
        }


        public int AddCurso(CursoDto curso)
        {
            var entity = _mapper.Map<Curso>(curso);

            context.Cursos.Add(entity);
            return context.SaveChanges();
        }

        public int DeleteCurso(int cursoId)
        {
            var entity = context.Cursos.Where(c => c.CursoId == cursoId).FirstOrDefault();
            if (entity == null)
                return -1;

            context.Cursos.Remove(entity);
            return context.SaveChanges();
        }

        public CursoDto GetCurso(int cursoId)
        {
            var curso = context.Cursos.Where(c => c.CursoId == cursoId).FirstOrDefault();
            if (curso == null)
                return new CursoDto();

            var entity = _mapper.Map<CursoDto>(curso); 
            return entity;
        }

        public async Task<List<CursoDto>> ListCursos()
        {
            var lista = _mapper.Map<List<CursoDto>>(await context.Cursos.ToListAsync());
            return lista;
        }

        public int UpdateCurso(CursoDto curso)
        {
            var entity = _mapper.Map<Curso>(curso);
            context.Cursos.Update(entity);
            return context.SaveChanges();
        }
    }
}
