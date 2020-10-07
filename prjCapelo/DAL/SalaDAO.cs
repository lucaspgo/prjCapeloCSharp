using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using prjCapelo.Models;

namespace prjCapelo.DAL
{
    class SalaDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static Sala BuscarPorNome(string nome) =>
           _context.Sala.FirstOrDefault(x => x.Nome == nome);
        public static bool Cadastrar(Sala sala)
        {
            if (BuscarPorNome(sala.Nome) == null)
            {
                _context.Sala.Add(sala);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
       
        public static List<Sala> Listar() =>
            _context.Sala.OrderBy(x => x.Nome).ToList();
        public static Sala BuscarPorId(int id) =>
            _context.Sala.Find(id);

        public static Boolean Remover(Sala sala)
        {
            try
            {
                _context.Sala.Remove(sala);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public static Boolean Alterar(Sala sala)
        {
            try
            {
                _context.Sala.Update(sala);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
