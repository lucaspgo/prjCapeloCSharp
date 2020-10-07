using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using prjCapelo.Models;

namespace prjCapelo.DAL
{
    class DisciplinaDAO
    {
        private static Context _context = SingletonContext.GetInstance();

        public static List<Disciplina> Listar() => _context.Disciplina.OrderBy(x => x.Nome).ToList();
        public static Disciplina BuscarPorId(int id) => _context.Disciplina.Find(id);
        public static Boolean Alterar(Disciplina disciplina)
        {
            try
            {
                _context.Disciplina.Update(disciplina);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }
            
        }

        public static Boolean Remover(Disciplina disciplina)
        {
            try
            {
                _context.Disciplina.Remove(disciplina);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

        }

        public static Boolean Cadastrar(Disciplina disciplina)
        {
            try
            {
                _context.Disciplina.Add(disciplina);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
