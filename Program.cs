using System;
using MixDaCasa.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MixDaCasa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new hamburgueriaContext())
            {
                var nome = db.BurguerIngrediente
                    .Include(b => b.Burguer)
                    .Include(b => b.Ingrediente)
                    .Where(b => b.Ingrediente.Nome.Contains("Burguer Mix da Casa"))
                    .OrderBy(b => b.Burguer.Preco)
                    .ThenBy(b => b.Burguer.Nome);
                
                foreach (var burguer in nome)
                {
                    Console.WriteLine($"O hamburguer {burguer.Burguer.Nome} contém o ingrediente Burguer Mix da Casa e custa {burguer.Burguer.Preco:C}");
                }
            }
        }
    }
}
