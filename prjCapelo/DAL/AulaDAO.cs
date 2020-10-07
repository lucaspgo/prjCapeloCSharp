using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using prjCapelo.Models;
using Microsoft.EntityFrameworkCore;

namespace prjCapelo.DAL
{
    class AulaDAO
    {
        private static Context _context = SingletonContext.GetInstance();

        public static bool Cadastrar(Aula aula)
        {
            try
            {
                _context.Aula.Add(aula);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static Boolean Remover(Aula aula)
        {
            try
            {
                _context.Aula.Remove(aula);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static void Alterar(Aula aula)
        {
            _context.Aula.Update(aula);
            _context.SaveChanges();
        }
        public static List<Aula> Listar() =>
            _context.Aula.ToList();
        public static Aula BuscarPorId(int id) =>
            _context.Aula.Find(id);

        public static List<Aula> BuscarPorProfessoreData(int idAluno, int idProfessor, DateTime data) =>
            _context.Aula.Include(x => x.Professor)
            .Where(x => x.Aluno.Matricula == idAluno)
            .Where(x => x.Data == data)
            .ToList();

        public static List<Aula> BuscarPorMatriculaAluno(int matricula) =>
            _context.Aula
            .Include(x => x.Aluno)
            .Include(x => x.Sala)
            .Include(x => x.Professor.Disciplina)
            .Where(x => x.Aluno.Matricula == matricula).OrderByDescending(x => x.DataInicio).ThenBy(x => x.DataFim)
            .AsNoTracking()
            .ToList();

        public static List<Aula> BuscarPorMatriculaProfessor(int matricula) =>
            _context.Aula
            .Include(x => x.Aluno)
            .Include(x => x.Sala)
            .Include(x => x.Professor.Disciplina)
            .Where(x => x.Professor.Matricula == matricula).OrderByDescending(x => x.DataInicio).ThenBy(x => x.DataFim)
            .AsNoTracking()
            .ToList();


    }
}
