using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using prjCapelo.Models;

namespace prjCapelo.DAL
{
    class PessoaDAO
    {
        private static Context _context = SingletonContext.GetInstance();
                
        public static bool Cadastrar(Pessoa pessoa)
        {            
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
            return true;         
            
        }
        public static void Remover(Pessoa pessoa)
        {
            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();
        }
        public static void Alterar(Pessoa pessoa)
        {
            _context.Pessoa.Update(pessoa);
            _context.SaveChanges();
        }
        public static List<Pessoa> Listar() =>
            _context.Pessoa.ToList();
        public static Pessoa BuscarPorId(int id) =>
            _context.Pessoa.Find(id);
    }
}
