using PrimeStone.RAT.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Common.Interface
{
    public interface ICursoService
    {
        Task<List<CursoDto>> ListCursos();
        CursoDto GetCurso(int cursoId);
        int AddCurso(CursoDto curso);
        int UpdateCurso(CursoDto curso);
        int DeleteCurso(int cursoId);
    }
}
