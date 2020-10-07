using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using prjCapelo.Models;
using Microsoft.EntityFrameworkCore;

namespace prjCapelo.DAL
{
    class AlunoDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static Aluno BuscarPorMatricula(int matricula) =>
                  _context.Aluno.FirstOrDefault(x => x.Matricula == matricula);
        public static bool Cadastrar(Aluno aluno)
        {
            if (BuscarPorMatricula(aluno.Matricula) == null)
            {
                _context.Aluno.Add(aluno);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void Remover(Aluno aluno)
        {
            _context.Aluno.Remove(aluno);
            _context.SaveChanges();
        }
        public static void Alterar(Aluno aluno)
        {
            _context.Aluno.Update(aluno);
            _context.SaveChanges();
        }
        public static List<Aluno> Listar() =>
            _context.Aluno.ToList();
        public static Aluno BuscarPorId(int id) =>
            _context.Aluno.Find(id);
    }
}