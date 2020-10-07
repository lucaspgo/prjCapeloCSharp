using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using prjCapelo.Models;
using Microsoft.EntityFrameworkCore;

namespace prjCapelo.DAL
{
    class ProfessorDAO
    {
        private static Context _context = SingletonContext.GetInstance();

        public static Professor BuscarPorMatricula(int matricula) =>
            _context.Professor.FirstOrDefault(x => x.Matricula == matricula);

        public static List<Professor> BuscarPorDisciplina(int idDisciplina) =>
            _context.Professor.Include(x => x.Disciplina)
            .Where(x => x.Disciplina.Id == idDisciplina)
            .Where(x => x.Matricula != 200)
            .OrderBy(x => x.NomeCompleto).ToList();

        public static bool Cadastrar(Professor professor)
        {
            if (BuscarPorMatricula(professor.Matricula) == null)
            {
                _context.Professor.Add(professor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void Remover(Professor professor)
        {
            _context.Professor.Remove(professor);
            _context.SaveChanges();
        }
        public static void Alterar(Professor professor)
        {
            _context.Professor.Update(professor);
            _context.SaveChanges();
        }
        public static List<Professor>Listar()=>
            _context.Professor.Include(x=> x.Disciplina)
            .Where(x => x.Matricula != 200)
            .ToList();
        public static Professor BuscarPorId(int id) =>
            _context.Professor.Find(id);
    }
}
