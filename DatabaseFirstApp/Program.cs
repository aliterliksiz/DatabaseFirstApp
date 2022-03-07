using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            //CRUD
            //Create

            //var category = new Category();
            //category.CategoryName = "Çerezler";
            //category.Description = "Fındık, Fıstık, Ceviz...";
            //db.Categories.Add(category);
            //db.SaveChanges();

            //Read
            //var categories = db.Categories;
            //foreach (var cat in categories)
            //{
            //    Console.WriteLine(cat.CategoryName + " - " + cat.Description);
            //}

            //Update

            //var category = db.Categories.Find(9);
            //category.CategoryName = "İçecekler";
            //category.Description = "Su, Cola, Meyve suyu...";
            //db.SaveChanges();

            //Delete

            //var category = db.Categories.Find(9);
            //db.Categories.Remove(category);
            //db.SaveChanges();

            //var result = db.Categories; //method hali yazılışı --1

            //var result = from cat in db.Categories
            //select cat; //LINQ yazılışı --1

            //var result = db.Categories.Select(x=>new {
            //    Id = x.CategoryID,
            //    Name = x.CategoryName
            //}); // method hali yazılışı --2

            //var result = from cat in db.Categories
            //             select new
            //             {
            //                 Id = cat.CategoryID,
            //                 Name = cat.CategoryName
            //             }; //LINQ yazılışı --2

            //var result = db.Categories.Take(2); //method hali yazılışı --3

            //var result = db.Categories.OrderBy(x => x.CategoryName); // method hali yazılışı --4

            //var result = db.Categories.OrderByDescending(x => x.CategoryName); // method hali yazılışı --5

            //var result = db.Categories.Where(x => x.CategoryID < 5); // method hali --6

            //var result = db.Categories.Where(x => x.CategoryID == 1 || x.CategoryID == 3); // method hali --7

            //var result = db.Categories.Where(x => x.CategoryID != 4 && x.CategoryID != 7); //method hali --8

            //var result = db.Categories.Where(x => x.CategoryID >= 3 && x.CategoryID <= 6); //method hali --9

            //var result = db.Categories.Where(x => x.CategoryID < 3 || x.CategoryID > 6); //method hali --10

            //var result = db.Categories.Sum(x=> x.CategoryID); //method hali --11

            //var result = db.Categories.Average(x => x.CategoryID); //method hali --12

            //var result = db.Categories.Max(x => x.CategoryID); //method hali --13

            //var result = db.Categories.Min(x => x.CategoryID); //method hali --14

            //var result = db.Categories.Select(x => new
            //{
            //    Id = x.CategoryID,
            //    IdKare = x.CategoryID * x.CategoryID
            //}); // method hali --15

            //var result = db.Categories.Where(x => x.CategoryName.Contains("ro")); //method hali --16

            //var result = db.Categories.Where(x => x.CategoryName.StartsWith("pr")); // method hali -17

            //var result = db.Categories.Where(x => x.CategoryName.EndsWith("ts")); // method hali --18


            //JOIN ve GROUP BY SORGULARI
            //Join ve Group By sorgularında LINQ formattayazılır çünkü daha okunaklıdır

            //var result = from c in db.Categories
            //             join p in db.Products
            //             on c.CategoryID equals p.CategoryID
            //             select new
            //             {
            //                 p.ProductName,
            //                 c.CategoryName
            //             }; // LINQ format --19

            //var result = from c in db.Categories
            //             join p in db.Products
            //             on c.CategoryID equals p.CategoryID
            //             orderby p.UnitPrice descending
            //             select new
            //             {
            //                 p.ProductName,
            //                 c.CategoryName,
            //                 p.UnitPrice
            //             }; // LINQ format --20

            //var result = from p in db.Products
            //             group p by p.CategoryID into g
            //             select new
            //             {
            //                 g.Key,
            //                 NumberOfProducts = g.Count()
            //             }; // LINQ frmat --21

            //var result = from p in db.Products
            //             join c in db.Categories
            //             on p.CategoryID equals c.CategoryID
            //             group c by c.CategoryName into g
            //             select new
            //             {
            //                 g.Key,
            //                 NumberOfProducts = g.Count()
            //             }; // LINQ format --22

            //var result = from p in db.Products
            //             join c in db.Categories
            //             on p.CategoryID equals c.CategoryID
            //             group new { c, p } by new { c.CategoryName } into g
            //             select new
            //             {
            //                 g.Key.CategoryName,
            //                 NumberOfPRoducts = g.Count(),
            //                 TotalPrice = g.Sum(x=> x.p.UnitPrice),
            //                 MaxPrice = g.Max(x=> x.p.UnitPrice),
            //                 MinPrice = g.Min(x => x.p.UnitPrice)
            //             }; //LINQ format --23

            var result = (from p in db.Products
                         join c in db.Categories
                         on p.CategoryID equals c.CategoryID
                         group new { c, p } by new { c.CategoryName } into g
                         select new
                         {
                             g.Key.CategoryName,
                             NumberOfPRoducts = g.Count(),
                             TotalPrice = g.Sum(x => x.p.UnitPrice),
                             MaxPrice = g.Max(x => x.p.UnitPrice),
                             MinPrice = g.Min(x => x.p.UnitPrice)
                         }).Where(x=>x.TotalPrice>300);
            ConsoleTable.From(result).Write();
            //Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
