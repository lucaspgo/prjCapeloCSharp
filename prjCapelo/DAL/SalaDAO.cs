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
        public static void Remover(Sala sala)
        {
            _context.Sala.Remove(sala);
            _context.SaveChanges();
        }
        public static void Alterar(Sala sala)
        {
            _context.Sala.Update(sala);
            _context.SaveChanges();
        }
        public static List<Sala> Listar() =>
            _context.Sala.ToList();
        public static Sala BuscarPorId(int id) =>
            _context.Sala.Find(id);
    }
}
