using Project.Entities;
using Project.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Console2
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductRepository repo = new ProductRepository();

            //foreach (var item in repo.FilterByName("t"))
            //{
            //    Console.WriteLine(item.Name);
            //}
            //
            //repo.Delete(6);

            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.Name+" "+item.ProductId);
            }



        }
    }
}
